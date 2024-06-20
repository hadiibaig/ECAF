using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Enums
{
    public enum EventStatus
    {
        [Description("green:ENQUIRY")]
        Enquiry = 0,
        [Description("orange:BOOKED")]
        Booked,
        [Description("red:CONFIRMED")]
        Confrmed
    }
}
