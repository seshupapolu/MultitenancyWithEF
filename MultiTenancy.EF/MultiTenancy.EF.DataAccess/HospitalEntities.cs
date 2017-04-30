using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.EF.DataAccess
{
    public partial class HospitalEntities : DbContext
    {
        public HospitalEntities(string existingConnection)
            : base(existingConnection)
        {
        }
    }
}
