using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MonitorCLClassLibrary.Model
{
    public class UsersGroup
    {
        /// <summary>
        /// Идентефикатор записи в БД
        /// </summary>
        public int UsersGroupId { get; set; }
        /// <summary>
        /// Имя для отображения
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Информация
        /// </summary>
        public string Information { get; set; }
        /// <summary>
        /// Уровень
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Родительськая группа
        /// </summary>
        public UsersGroup Parent { get; set; }

        /// <summary>
        /// NotImplementedException
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            throw new NotImplementedException();

            var db = new MonitoringDB();
            UsersGroup currentGroup = db.UserGroups.Where(x => x.UsersGroupId == id).First();
            if (currentGroup == null)
                return false;
            /*
            var fullEntries = dbContext.tbl_EntryPoint
    .Join(
        dbContext.tbl_Entry,
        entryPoint => entryPoint.EID,
        entry => entry.EID,
        (entryPoint, entry) => new { entryPoint, entry }
    )


            //try
            //{
            if (db.Users.Join(db.UserGroups,
        entryPoint => entryPoint.Group,
        entry => entry.UsersGroupId,
        (entryPoint, entry) => new { entryPoint, entry }))
            //.Count() > 0)
            {
                foreach (var item in db.Users.Where(x=>x.Group==currentGroup))
                {
                    db.Users.Remove(item);
                }
                db.SaveChanges();
            }
            else
            {*/

            db.UserGroups.Remove(db.UserGroups.Where(x => x.UsersGroupId == id).First());
            //}
            db.SaveChanges();
            return true;
            /* }
             catch (Exception err)
             {
                 Debug.WriteLine(err.Message);
                 return false;
             }*/
        }
    }
}
