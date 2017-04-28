using System.Data.Common;
using System.Data.Entity;

namespace MultiTenancy.EF.DataAccess
{
    public partial class CommonEntities : DbContext
    {
        public CommonEntities(DbConnection existingConnection)
            : base(existingConnection, false)
        {
        }


    }
}
