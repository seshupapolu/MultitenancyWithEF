using System.Data.Common;
using System.Data.Entity;

namespace MultiTenancy.EF.DataAccess
{
    public partial class PracticeEntities : DbContext
    {
        public PracticeEntities(DbConnection existingConnection)
            : base(existingConnection, false)
        {
        }
    }
}
