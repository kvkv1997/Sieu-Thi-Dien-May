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
     //   SieuThiDienMayDbContext db = null;

        public long Insert(Employee model
            )
        {
            using (var db = new SieuThiDienMayDbContext())
            {
                db.Employees.Add(model);
                db.SaveChanges();
                return model.ID_Employee;
            }
        }
        public void Delete(string id)
        {
            using(var db = new SieuThiDienMayDbContext())
            {
                var emp = db.Employees.FirstOrDefault(l => l.ID_Employee.Equals(id));
                if (emp == null) throw new Exception("Mã nhân viên không tồn tại");
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
        }
        public void Update(Employee model)
        {
            using (var db = new SieuThiDienMayDbContext())
            {
                var emp = db.Employees.FirstOrDefault(l => l.ID_Employee.Equals(model.ID_Employee));
                if (emp == null) throw new Exception("Mã nhân viên không tồn tại");
                emp.UserName = model.UserName;
                emp.Password = emp.Password;
                emp.Phone = model.Phone;
                emp.Address = model.Address;
                emp.Email = model.Email;
                emp.Status = model.Status;
                emp.ModifiedBy = model.ModifiedBy;
                emp.CreateBy = model.CreateBy;
                emp.CreateDate = model.CreateDate;
                emp.ModifiedDate = model.ModifiedDate;
                emp.Type_Emp = model.Type_Emp;
                db.SaveChanges();
            }
        }

        public List<Employee> GetAll()
        {
            using( var db = new SieuThiDienMayDbContext())
            {
                return db.Employees.ToList();
            }
        }
        public Employee getByID(string username)
        {
            using (var db = new SieuThiDienMayDbContext())
            {
                return db.Employees.SingleOrDefault(t => t.UserName == username);
            }
        }
        public int Login(string userName, string passWord)
        {
            using (var db = new SieuThiDienMayDbContext())
            {
                var result = db.Employees.SingleOrDefault(t => t.UserName == userName);
                if (result == null)
                {
                    return 0;
                }
                else
                {
                    if (result.Status == false)
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
}
