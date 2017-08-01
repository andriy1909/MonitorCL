using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MonitorCLClient
{
    public static class LogList
    {
        static string file;

        static LogList()
        {
            try
            {
          //      file = Application.CommonAppDataPath;
                file = file.Remove(file.LastIndexOf('\\')) + "\\Log.txt";
                if (!File.Exists(file))
                    File.Create(file);
            }
            catch (Exception err)
            {
          //      Properties.Settings.Default.ErrorList += Environment.NewLine + DateTime.Now.ToString() + " : " + err.Message;
            }
        }

        public static void Add(string message)
        {
            try
            {
                File.WriteAllText(file, DateTime.Now.ToString() + " : " + message+ Environment.NewLine);
            }
            catch (Exception err)
            {
     //           Properties.Settings.Default.ErrorList += Environment.NewLine + DateTime.Now.ToString() + " : " + err.Message + " (error : "+message+")";
            }
        }

        public static void Clear()
        {
            try
            {
                if (File.Exists(file))
                    File.Delete(file);
                File.Create(file);
            }
            catch (Exception err)
            {
      //          Properties.Settings.Default.ErrorList += Environment.NewLine + DateTime.Now.ToString() + " : " + err.Message;
            }
        }
    }
}
