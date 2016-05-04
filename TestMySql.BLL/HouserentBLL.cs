using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMySql.EF;

namespace TestMySql.BLL
{
    public class HouserentBLL
    {
        public static List<houserent> GetHouseRentList()
        {
            List<houserent> houserentlist = new List<houserent>();
            using (testEntities context = new testEntities())
            {  
                houserentlist = context.houserent.ToList<houserent>();
            }
            return houserentlist;
        }
    }
}
