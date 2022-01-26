using AutoMapper;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Onboarding.Domain.DTOs;
using OnBoarding.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnBoarding.Infrastructure.Services
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        private readonly IMapper _mapper;
        private UserCredential _credential;
        private readonly IEmployeeRepository _employeeRepository;

        public GoogleCalendarService(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _credential = GetUserCredential();
        }

        private static UserCredential GetUserCredential()
        {
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                           new ClientSecrets
                           {
                               ClientId = "your-client-id",
                               ClientSecret = "your-client-secret",
                           },
                           new[] { CalendarService.Scope.Calendar },
                           "user",
                           CancellationToken.None).Result;

            return credential;
        }

        private async Task<IList<EventAttendee>> GetListOfAllAttendees()
        {
            var employees = _employeeRepository.GetAllAsync().GetAwaiter().GetResult();

            var attendees = new List<EventAttendee>();

            foreach (var employee in employees)
            {
                attendees.Add(new EventAttendee { Email = employee.WorkEmail });
            }

            return attendees;
        }

        private async Task<IList<EventAttendee>> GetListOfNewAttendees()
        {
            var employees = _employeeRepository.GetNewEmployeesAsync().GetAwaiter().GetResult();

            var attendees = new List<EventAttendee>();

            foreach (var employee in employees)
            {
                attendees.Add(new EventAttendee { Email = employee.WorkEmail });
            }

            return attendees;
        }

        private async Task<IList<EventAttendee>> GetAttendee(string employeeId)
        {

            var employee = _employeeRepository.GetEmpByIdAsync(employeeId).GetAwaiter().GetResult();

            var attendees = new List<EventAttendee>
            {
                new EventAttendee { Email = employee.WorkEmail }
            };

            return attendees;
        }

        public async Task InviteAllEmployees(GoogleCalendarEventInviteDto eventInvite)
        {

            // Create the service.
            var service = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = _credential,
                ApplicationName = "Calendar",
            });

            var eventmeeting = _mapper.Map<Event>(eventInvite);
            eventmeeting.Start = new EventDateTime
            {
                DateTime = new DateTime(eventInvite.StartYear, eventInvite.StartMonth, eventInvite.StartDay, eventInvite.StartHour, eventInvite.StartMinute, eventInvite.StartSecond),
                TimeZone = "Africa/Lagos",
            };
            eventmeeting.End = new EventDateTime
            {
                DateTime = new DateTime(eventInvite.StartYear, eventInvite.StartMonth, eventInvite.StartDay, eventInvite.StartHour, eventInvite.StartMinute, eventInvite.StartSecond),
                TimeZone = "Africa/Lagos",
            };
            eventmeeting.Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO" };

            eventmeeting.Attendees = await GetListOfAllAttendees();


            var recurringEvent = service.Events.Insert(eventmeeting, "primary");
            recurringEvent.SendNotifications = true;
            recurringEvent.Execute();


        }



        public async Task InviteNewEmployees(GoogleCalendarEventInviteDto eventInvite)
        {
            // Create the service.
            var service = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = _credential,
                ApplicationName = "Calendar",
            });

            var eventmeeting = _mapper.Map<Event>(eventInvite);
            eventmeeting.Start = new EventDateTime
            {
                DateTime = new DateTime(eventInvite.StartYear, eventInvite.StartMonth, eventInvite.StartDay, eventInvite.StartHour, eventInvite.StartMinute, eventInvite.StartSecond),
                TimeZone = "Africa/Lagos",
            };
            eventmeeting.End = new EventDateTime
            {
                DateTime = new DateTime(eventInvite.StartYear, eventInvite.StartMonth, eventInvite.StartDay, eventInvite.StartHour, eventInvite.StartMinute, eventInvite.StartSecond),
                TimeZone = "Africa/Lagos",
            };
            eventmeeting.Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO" };

            eventmeeting.Attendees = await GetListOfNewAttendees();


            var recurringEvent = service.Events.Insert(eventmeeting, "primary");
            recurringEvent.SendNotifications = true;
            recurringEvent.Execute();
        }

        public async Task InviteEmployee(string employeeId, GoogleCalendarEventInviteDto eventInvite)
        {

            // Create the service.
            var service = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = _credential,
                ApplicationName = "Calendar",
            });

            var eventmeeting = _mapper.Map<Event>(eventInvite);
            eventmeeting.Start = new EventDateTime
            {
                DateTime = new DateTime(eventInvite.StartYear, eventInvite.StartMonth, eventInvite.StartDay, eventInvite.StartHour, eventInvite.StartMinute, eventInvite.StartSecond),
                TimeZone = "Africa/Lagos",
            };
            eventmeeting.End = new EventDateTime
            {
                DateTime = new DateTime(eventInvite.StartYear, eventInvite.StartMonth, eventInvite.StartDay, eventInvite.StartHour, eventInvite.StartMinute, eventInvite.StartSecond),
                TimeZone = "Africa/Lagos",
            };
            eventmeeting.Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO" };

            eventmeeting.Attendees = await GetAttendee(employeeId);


            var recurringEvent = service.Events.Insert(eventmeeting, "primary");
            recurringEvent.SendNotifications = true;
            recurringEvent.Execute();
        }
    }
}
