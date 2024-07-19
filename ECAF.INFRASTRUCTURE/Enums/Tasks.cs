using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Enums
{
    public enum Tasks
    {
        [Description("GREEN:InProgress")]
        InProgress = 1,
        [Description("BLUE:Completed")]
        Completed,
        [Description("RED:Due")]
        Due
    }
}
