using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace MonitorCLClassLibrary
{
    [Serializable]
    public class UserAccount : Monitoring
    {
        /// <summary>
        /// Флаги, описывающие характеристики учетной записи пользователя Windows.
        /// </summary>
        public uint AccountType;
        /// <summary>
        /// Домен и имя пользователя учетной записи.
        /// </summary>
        public string Caption;
        /// <summary>
        /// Описание учетной записи.
        /// </summary>
        public string Description;
        /// <summary>
        /// Учетная запись пользователя Windows отключена.
        /// </summary>
        public bool Disabled;
        /// <summary>
        /// Имя домена Windows, к которому принадлежит учетная запись пользователя, например: «NA-SALES».
        /// </summary>
        public string Domain;
        /// <summary>
        /// Полное имя локального пользователя, например: «Дэн Уилсон».
        /// </summary>
        public string FullName;
        /// <summary>
        /// Дата установки объекта. 
        /// </summary>
        public DateTime InstallDate;
        /// <summary>
        /// Если значение true , учетная запись определена на локальном компьютере.
        /// </summary>
        public bool LocalAccount;
        /// <summary>
        /// Если значение true , учетная запись пользователя заблокирована из операционной системы Windows.
        /// </summary>
        public bool Lockout;
        /// <summary>
        /// Имя учетной записи пользователя Windows в домене, которое указывает свойство домена этого класса.
        /// Пример: «danwilson».
        /// </summary>
        public string Name;
        /// <summary>
        /// Если значение true , пароль в этой учетной записи пользователя можно изменить.
        /// </summary>
        public bool PasswordChangeable;
        /// <summary>
        /// Если true , пароль в этой учетной записи пользователя истекает.
        /// </summary>
        public bool PasswordExpires;
        /// <summary>
        /// Если значение true , для учетной записи пользователя Windows требуется пароль.Если false , эта учетная запись не требует пароля.
        /// </summary>
        public bool PasswordRequired;
        /// <summary>
        /// Идентификатор безопасности (SID) для этой учетной записи. SID - это строковое значение переменной длины, которое используется для идентификации доверительного управляющего.
        /// </summary>
        public string SID;
        /// <summary>
        /// Перечислимое значение, определяющее тип SID.
        /// </summary> 
        /*SidTypeUser (1) 
SidTypeGroup(2)
SidTypeDomain(3)
SidTypeAlias(4)
SidTypeWellKnownGroup(5)
SidTypeDeletedAccount(6)
SidTypeInvalid(7)
SidTypeUnknown(8)
SidTypeComputer(9)*/
        public byte SIDType;
        /// <summary>
        /// Текущее состояние объекта. 
        /// </summary>
        public string Status;

        public List<UserAccount> GetData()
        {
            List<UserAccount> users = new List<UserAccount>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_UserAccount");

            foreach (ManagementObject item in searcher.Get())
            {
                users.Add(new UserAccount()
                {
                    AccountType = (uint)item["AccountType"],
                    Caption = (string)item["Caption"],
                    Description = (string)item["Description"],
                    Disabled = (bool)item["Disabled"],
                    Domain = (string)item["Domain"],
                    FullName = (string)item["FullName"],
                    InstallDate = (item["InstallDate"]==null)?DateTime.MinValue: Convert.ToDateTime(item["InstallDate"]),
                    LocalAccount = (bool)item["LocalAccount"],
                    Lockout = (bool)item["Lockout"],
                    Name = (string)item["Name"],
                    PasswordChangeable = (bool)item["PasswordChangeable"],
                    PasswordExpires = (bool)item["PasswordExpires"],
                    PasswordRequired = (bool)item["PasswordRequired"],
                    SID = (string)item["SID"],
                    SIDType = (byte)item["SIDType"],
                    Status = (string)item["Status"]
                });
            }
            return users;
        }

        public override string GetFields()
        {
            return "AccountType;Caption;Description;Disabled;Domain;FullName;InstallDate;LocalAccount;Lockout;Name;"+
                "PasswordChangeable;PasswordExpires;PasswordRequired;SID;SIDType;Status";
        }

        public override string GetDescriptionFields()
        {
            return "Тип записи;Домен и имя;Описание;Отключена;Имя домена;Полное имя;Дата установки;"+
                "Локальная уч.запись;Заблокирован;Имя учетной записи;Пароль можно изменить;Пароль истекает;"+
                "Требуется пароль;Идентификатор безопасности;тип SID;Состояние";
        }
    }
}
