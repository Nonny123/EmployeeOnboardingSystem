using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Domain.DTOs
{
    public class GoogleCalendarEventInviteDto
    {
        public string Summary { get; set; }
        public string Location { get; set; }
        public int StartDay { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int StartSecond { get; set; }
        //public DateTime EndDate { get; set; }
        //public string StartTimeZone { get; set; }
        //public string EndTimeZone { get; set; }
        //public string[] Recurrence { get; set; }

    }
}
