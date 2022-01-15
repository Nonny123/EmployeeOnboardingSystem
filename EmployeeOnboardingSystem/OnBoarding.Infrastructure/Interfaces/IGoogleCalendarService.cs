using System;
using System.Collections.Generic;
using Onboarding.Domain.DTOs;


namespace OnBoarding.Infrastructure.Interfaces
{
    public interface IGoogleCalendarService
    {
        int InviteEmployee(GoogleCalendarEventInviteDto eventInvite);
    }
}
