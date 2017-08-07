using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MonitorCLClassLibrary.Model
{
    public class UsersGroup
    {
        public int UsersGroupId { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public int Level { get; set; }
        public UsersGroup Parent { get; set; }

        public static bool Delete(int id)
        {
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
