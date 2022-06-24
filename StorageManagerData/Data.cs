using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagerData
{
    public class Data
    {
        static List<Emploee> emploes = new List<Emploee>();

        public List<Emploee> LoadData()
        {
            try
            {
                using (var db = new StorageDbContext())
                {
                    emploes = db.emploees.ToList();
                }
                return emploes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
   

        public  void AddEmploee(string name, string secondName, string contacts , string job)
        {
            using(var db = new StorageDbContext())
            {
                db.Add(new Emploee { Name = name, SecondName = secondName, Hiredate = DateTime.Now, Contacts = contacts, AlocatedJob = job });
                db.SaveChanges();
            }
            
        }
        public void DeleteEmploee(int id)
        {
            using(var db = new StorageDbContext())
            {
                var employee = db.emploees.FirstOrDefault(emp => emp.Id == id);
                if(employee != null)
                {
                    db.emploees.Remove(employee);
                    db.SaveChanges();
                }    
                
            }
        }
        public void UpdateEmploeeJob(int id, string job)
        {
            using (var db = new StorageDbContext())
            {
                var employee = db.emploees.FirstOrDefault(emp => emp.Id == id);
                if (employee != null)
                {
                    employee.AlocatedJob = job;
                    db.SaveChanges();
                }

            }
        }


    }
}
