using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace MonitorCLClassLibrary.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Information { get; set; }
        public string TypePC { get; set; }
        public UsersGroup Group { get; set; }
        public DateTime DateReg { get; set; }

        public static bool Delete(int id)
        {
            var db = new MonitoringDB();
            //try
            //{
                db.Users.Remove(db.Users.Where(x => x.UserId == id).First());
                return true;
            /*}
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }*/
        }

        public void Edit()
        {
            var db = new MonitoringDB();
            var user = db.Users.SingleOrDefault(x => x.UserId == UserId);
            if(user != null)
            {
                db.Users.Attach(this);
                db.Entry(this).State = EntityState.Modified;
                db.SaveChanges();
            }
            
        }
    }
}
