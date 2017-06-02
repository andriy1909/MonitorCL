using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitorCLClassLibrary
{
    public enum Metods
    {
        Regisration,
        Login,
        Query,
        SendMessage
    }

    public enum ResultCode
    {
        Ok,
        NotAuthorizate,
        NotRegister,
        Login,
        Blocked,
        NotValidPassw,
        NotValidLogin,
        LoginExist,
        Error
    }
    
}
