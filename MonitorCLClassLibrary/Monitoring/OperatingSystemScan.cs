using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace MonitorCLClassLibrary
{
    public class OperatingSystemScan : Monitoring
    {
        /// <summary>
        /// Номер сборки операционной системы.
        /// </summary>
        public string BuildNumber;
        /// <summary>
        /// Краткое описание объекта - однострочная строка. Строка содержит версию операционной системы. Например, «Microsoft Windows 7 Enterprise». Это свойство может быть локализовано.
        /// </summary>
        public string Caption;
        /// <summary>
        /// NULL - завершена строка, которая указывает последний пакет обновления, установленный на компьютере. 
        /// Если пакет обновления не установлен, строка будет NULL .
        /// Пример: «Service Pack 3»
        /// </summary>
        public string CSDVersion;
        /// <summary>
        /// Название компьютерной системы обзора.
        /// </summary>
        public string CSName;
        /// <summary>
        /// Число, в минутах, операционная система смещена от среднего времени по Гринвичу (GMT). Число положительное, отрицательное или ноль.
        /// </summary>
        public short CurrentTimeZone;
        /// <summary>
        /// Предотвращение выполнения данных - это аппаратная функция, предотвращающая атаки переполнения буфера, прекращая выполнение кода на страницах памяти типа данных. Если True , то эта функция доступна. На 64-битных компьютерах функция предотвращения выполнения данных настроена в хранилище BCD, и соответственно устанавливаются свойства в Win32_OperatingSystem .
        /// </summary>
        public bool DataExecutionPrevention_Available;
        /// <summary>
        /// Когда доступна аппаратная функция предотвращения выполнения данных, это свойство указывает, что функция настроена на работу для 32-разрядных приложений, если True . На 64-битных компьютерах функция предотвращения выполнения данных настроена в хранилище данных конфигурации загрузки (BCD), а свойства в Win32_OperatingSystem установлены соответственно.
        /// </summary>
        public bool DataExecutionPrevention_32BitApplications;
        /// <summary>
        /// Когда доступна аппаратная функция предотвращения выполнения данных, это свойство указывает, что функция настроена на работу драйверов, если True . На 64-битных компьютерах функция предотвращения выполнения данных настроена в хранилище BCD, и соответственно устанавливаются свойства в Win32_OperatingSystem .
        /// </summary>
        public bool DataExecutionPrevention_Drivers;
        /// <summary>
        /// Уровень шифрования для защищенных транзакций: 40-разрядный, 128-разрядный или n -бит .
        /// 
        /// 40-бит (0)
        /// 128-бит(1)
        /// N-бит(2)
        /// </summary>
        public uint EncryptionLevel;
        /// <summary>
        /// Число в килобайтах физической памяти в настоящее время не используется и доступно.
        /// </summary>
        public ulong FreePhysicalMemory;
        /// <summary>
        /// Число в килобайтах, которое может быть отображено в файлы подкачки операционной системы, не вызывая замены других страниц.
        /// </summary>
        public ulong FreeSpaceInPagingFiles;
        /// <summary>
        /// Число в килобайтах виртуальной памяти в настоящее время не используется и доступно.
        /// </summary>
        public ulong FreeVirtualMemory;
        /// <summary>
        /// Дата установки.
        /// </summary>
        public DateTime InstallDate;
        /// <summary>
        /// Дата и время последней загрузки операционной системы.
        /// </summary>
        public DateTime LastBootUpTime;
        /// <summary>
        /// Версия операционной системы локальной даты и времени суток.
        /// </summary>
        public DateTime LocalDateTime;
        /// <summary>
        /// Максимальное количество в килобайтах памяти, которое может быть выделено процессу.
        /// </summary>
        public ulong MaxProcessMemorySize;
        /// <summary>
        /// Количество сеансов пользователя, для которых операционная система хранит информацию о состоянии в настоящее время.
        /// </summary>
        public uint NumberOfUsers;
        /// <summary>
        /// Архитектура операционной системы, в отличие от процессора.
        /// </summary>
        public string OSArchitecture;
        /// <summary>
        /// Дополнительная системная информация.
        /// </summary>
        /*
        Рабочая станция (1)
        Контроллер домена (2)
        Сервер (3)
        */
        public uint ProductType;
        /// <summary>
        /// Имя зарегистрированного пользователя операционной системы.
        /// </summary>
        public string RegisteredUser;
        /// <summary>
        /// Серийный идентификационный номер продукта операционной системы.
        /// </summary>
        public string SerialNumber;
        /// <summary>
        /// Общее количество килобайт, которые могут быть сохранены в файлах подкачки операционной системы - 0 (ноль), указывает на отсутствие файлов подкачки. Имейте в виду, что это число не отражает фактический физический размер файла подкачки на диске.
        /// </summary>
        public ulong SizeStoredInPagingFiles;
        /// <summary>
        /// Текущее состояние объекта. 
        /// </summary>
        /*
        OK («OK»)
        Ошибка(«Error»)
        Деградированные(«Degraded»)
        Неизвестно(«Unknown»)
        Pred Fail(«Pred Fail»)
        Запуск(«Starting»)
        Остановка(«Stopping»)
        Сервис(«Service»)
        Подчеркнутый(«Stressed»)
        NonRecover(«NonRecover»)
        Нет контакта(«No Contact»)
        Lost Comm(«Lost Comm»)
        */
        public string Status;
        /// <summary>
        /// Буква диска, на котором находится операционная система. Пример: "C:"
        /// </summary>
        public string SystemDrive;
        /// <summary>
        /// Число в килобайтах виртуальной памяти. 
        /// </summary>
        public ulong TotalVirtualMemorySize;
        /// <summary>
        /// Общее количество в килобайтах физической памяти, доступной операционной системе.
        /// </summary>
        public ulong TotalVisibleMemorySize;
        /// <summary>
        /// Номер версии операционной системы.
        /// </summary>
        public string Version;


        public override string Fields
        {
            get
            {
                return "BuildNumber;Caption;CSDVersion;CSName;CurrentTimeZone;DataExecutionPrevention_Available;DataExecutionPrevention_32BitApplications;" +
               "DataExecutionPrevention_Drivers;EncryptionLevel;FreePhysicalMemory;FreeSpaceInPagingFiles;FreeVirtualMemory;InstallDate;LastBootUpTime;" +
               "LocalDateTime;MaxProcessMemorySize;NumberOfUsers;OSArchitecture;ProductType;RegisteredUser;SerialNumber;SizeStoredInPagingFiles;Status;" +
               "SystemDrive;TotalVirtualMemorySize;TotalVisibleMemorySize;Version";
            }
        }

        public override string GetSign()
        {
            return "OperatingSystem";
        }
        
        public void GetData()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + this.Fields.Replace(';', ',') + " FROM Win32_OperatingSystem");
            
            foreach (ManagementObject item in searcher.Get())
            {
                foreach (string field in this.Fields.Split(';'))
                {
                   this[field] = item[field];
                }
            }
        }

        public static string GetNamePC()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + "CSName" + " FROM Win32_OperatingSystem");

            foreach (ManagementObject item in searcher.Get())
            {
                return item["CSName"].ToString();
            }
            return null;
        }

        public object this[string name]
        {
            get
            {
                switch (name)
                {
                    case "BuildNumber": return BuildNumber;
                    case "Caption": return Caption;
                    case "CSDVersion": return CSDVersion;
                    case "CSName": return CSName;
                    case "CurrentTimeZone": return CurrentTimeZone;
                    case "DataExecutionPrevention_Available": return DataExecutionPrevention_Available;
                    case "DataExecutionPrevention_32BitApplications": return DataExecutionPrevention_32BitApplications;
                    case "DataExecutionPrevention_Drivers": return DataExecutionPrevention_Drivers;
                    case "EncryptionLevel": return EncryptionLevel;
                    case "FreePhysicalMemory": return FreePhysicalMemory;
                    case "FreeSpaceInPagingFiles": return FreeSpaceInPagingFiles;
                    case "FreeVirtualMemory": return FreeVirtualMemory;
                    case "InstallDate": return InstallDate;
                    case "LastBootUpTime": return LastBootUpTime;
                    case "LocalDateTime": return LocalDateTime;
                    case "MaxProcessMemorySize": return MaxProcessMemorySize;
                    case "NumberOfUsers": return NumberOfUsers;
                    case "OSArchitecture": return OSArchitecture;
                    case "ProductType": return ProductType;
                    case "RegisteredUser": return RegisteredUser;
                    case "SerialNumber": return SerialNumber;
                    case "SizeStoredInPagingFiles": return SizeStoredInPagingFiles;
                    case "Status": return Status;
                    case "SystemDrive": return SystemDrive;
                    case "TotalVirtualMemorySize": return TotalVirtualMemorySize;
                    case "TotalVisibleMemorySize": return TotalVisibleMemorySize;
                    case "Version": return Version;
                    default:
                        return null;
                }
            }
            protected set
            {
                switch (name)
                {
                    case "BuildNumber": BuildNumber = (string)value; break;
                    case "Caption": Caption = (string)value; break;
                    case "CSDVersion": CSDVersion = (string)value; break;
                    case "CSName": CSName = (string)value; break;
                    case "CurrentTimeZone": CurrentTimeZone = (short)value; break;
                    case "DataExecutionPrevention_Available": DataExecutionPrevention_Available = (bool)value; break;
                    case "DataExecutionPrevention_32BitApplications": DataExecutionPrevention_32BitApplications = (bool)value; break;
                    case "DataExecutionPrevention_Drivers": DataExecutionPrevention_Drivers = (bool)value; break;
                    case "EncryptionLevel": EncryptionLevel = (uint)value; break;
                    case "FreePhysicalMemory": FreePhysicalMemory = (ulong)value; break;
                    case "FreeSpaceInPagingFiles": FreeSpaceInPagingFiles = (ulong)value; break;
                    case "FreeVirtualMemory": FreeVirtualMemory = (ulong)value; break;
                    case "InstallDate": InstallDate = ConvertDate((string)value); break;
                    case "LastBootUpTime": LastBootUpTime = ConvertDate((string)value); break;
                    case "LocalDateTime": LocalDateTime = ConvertDate((string)value); break;
                    case "MaxProcessMemorySize": MaxProcessMemorySize = (ulong)value; break;
                    case "NumberOfUsers": NumberOfUsers = (uint)value; break;
                    case "OSArchitecture": OSArchitecture = (string)value; break;
                    case "ProductType": ProductType = (uint)value; break;
                    case "RegisteredUser": RegisteredUser = (string)value; break;
                    case "SerialNumber": SerialNumber = (string)value; break;
                    case "SizeStoredInPagingFiles": SizeStoredInPagingFiles = (ulong)value; break;
                    case "Status": Status = (string)value; break;
                    case "SystemDrive": SystemDrive = (string)value; break;
                    case "TotalVirtualMemorySize": TotalVirtualMemorySize = (ulong)value; break;
                    case "TotalVisibleMemorySize": TotalVisibleMemorySize = (ulong)value; break;
                    case "Version": Version = (string)value; break;
                    default:
                        break;
                }
            }
        }
    }
}