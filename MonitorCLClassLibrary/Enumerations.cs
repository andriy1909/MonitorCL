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
        OK,
        NotAuthorizate,
        NotRegister,
        Login,
        Blocked,
        NotValidKey,
        NoConnection,
        LoginExist,
        Error,
        KeyTimeout,
        Timeout
    }

    public enum EncriptLevel
    {
        VeryLow,
        Low,
        Normal,
        High,
        VeryHigh,
        None
    }
}
