using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace MonitorCLClassLibrary.Model
{
    public class User
    {
        /// <summary>
        /// идентефикатор записи в БД
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Имя для отображения
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Компания
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Информация
        /// </summary>
        public string Information { get; set; }
        /// <summary>
        /// Тип устройства
        /// </summary>
        public int TypePC { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public UsersGroup Group { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime DateReg { get; set; }

        /// <summary>
        ///  NotImplementedException();
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            throw new NotImplementedException();

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

        /// <summary>
        ///  NotImplementedException();
        /// </summary>
        public void Edit()
        {
            throw new NotImplementedException();

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
