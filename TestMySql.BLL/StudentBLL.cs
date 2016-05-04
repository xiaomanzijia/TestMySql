using System.Collections.Generic;
using TestMySql.EF;

namespace TestMySql.BLL
{
    public class StudentBLL
    {
        public static List<student> GetAllStudent() 
        {
            using(testEntities context = new testEntities())
            {
                List<student> studentlist = new List<student>();
                
                return studentlist;
            }
        }
    }
}
