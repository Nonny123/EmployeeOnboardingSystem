using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Onboarding.Domain.DTOs;


namespace OnBoarding.Infrastructure.Interfaces
{
    public interface IGoogleCalendarService
    {
        Task InviteAllEmployees(GoogleCalendarEventInviteDto eventInvite);

        Task InviteNewEmployees(GoogleCalendarEventInviteDto eventInvite);

        Task InviteEmployee(string employeeId, GoogleCalendarEventInviteDto eventInvite);
    }
}
