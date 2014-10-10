using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace JWL.Service
{
    public enum CarType
    {
        [Description("平板车")]
        pbc = 0,
        [Description("平板车2")]
        dlc=1,
        [Description("平板车3")]
        glc = 2,
        [Description("平板车4")]
        bfbc = 3
    }
}
