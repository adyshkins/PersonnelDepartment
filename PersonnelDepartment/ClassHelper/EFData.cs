using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelDepartment.ClassHelper
{
    internal class EFData
    {
        public static EF.Entities Context { get; } = new EF.Entities();
    }
}
