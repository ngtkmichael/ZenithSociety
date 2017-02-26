using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZenithWebSite.Models
{
    public class EventsDto
    {
        public DateTime EventStartDateTime { get; set; }
        public DateTime EventEndDateTime { get; set; }
        public string ActivityDesc { get; set; }
    }
}
