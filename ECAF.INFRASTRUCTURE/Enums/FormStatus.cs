using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Enums
{
    public enum FormStatus

    {
        [Description("InProgress")]
        InProgress = 1,
        [Description("Completed")]
        Completed,
        [Description("Rejected")]
        Rejected,
    }
}
