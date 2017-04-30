using System.Data.Common;
using System.Data.Entity;

namespace MultiTenancy.EF.DataAccess
{
    public partial class PracticeEntities : DbContext
    {
        public PracticeEntities(string existingConnection)
            : base(existingConnection)
        {
        }
    }
}
