using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.DAO
{
    public class EmployeeDao
    {
        SieuThiDienMayDbContext db = null;
        public EmployeeDao(){
            db = new SieuThiDienMayDbContext();
        }
        public long Insert(Employee entity)
        {
            db.Employees.Add(entity);
            db.SaveChanges();
            return entity.ID_Employee;
        }

        public Employee getByID( string username){
            return db.Employees.SingleOrDefault(t => t.UserName == username);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Employees.SingleOrDefault(t => t.UserName == userName);
            if (result== null)
            {
                return 0;
            }
            else
            {
                if(result.Status ==false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                        return -2;
                }
            }
        }

    }
}
