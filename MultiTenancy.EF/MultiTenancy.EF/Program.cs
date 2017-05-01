using MultiTenancy.EF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.EF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number 1 or 2");
            int input = Convert.ToInt32(Console.ReadLine());
            CommonEntities en = new CommonEntities();
            var val = en.MasterDatas.First(x => x.Id == input);

            PracticeEntities pn = new PracticeEntities(DbFactory.GetConnection(val.DbName, "Practice"));

            pn.Practices.Add(new Practice()
            {
                Id = 5,
                Name = "papolu"
            });

            pn.SaveChanges();





        }
    }
}
