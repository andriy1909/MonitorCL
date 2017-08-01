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
        Query
    }

    public enum StateUser
    {
        NotRegister,
        Login,
        Block,
        NotValidPassw,
        NotValidLogin,
        LoginExist,
        Error
    }
    
}
