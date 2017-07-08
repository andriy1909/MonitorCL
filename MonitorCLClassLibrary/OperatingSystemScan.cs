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
        /// Имя диска, с которого запускается операционная система Windows.
        /// </summary>
        string BootDevice;
        /// <summary>
        /// Номер сборки операционной системы.
        /// </summary>
        string BuildNumber;
        /// <summary>
        /// Тип сборки, используемый для операционной системы.
        /// </summary>
        string BuildType;
        /// <summary>
        /// Краткое описание объекта - однострочная строка. Строка содержит версию операционной системы. Например, «Microsoft Windows 7 Enterprise». Это свойство может быть локализовано.
        /// </summary>
        string Caption;
        /// <summary>
        /// Значение кодовой страницы, используемое операционной системой. 
        /// Кодовая страница содержит таблицу символов, которую операционная система использует для перевода строк для разных языков. Американский национальный институт стандартов (ANSI) перечисляет значения, которые представляют собой определенные кодовые страницы. Если операционная система не использует кодовую страницу ANSI, этот член устанавливается в 0 (ноль). Codeset строка может использовать максимум шести символов для определения значения кодовой страницы.
        /// Пример: "1255"
        /// </summary>
        string CodeSet;
        /// <summary>
        /// Код для страны / региона, который использует операционная система. 
        /// Значения основаны на префиксах международного телефонного набора, также называемых кодами стран / регионов IBM. Это свойство может использовать не более шести символов для определения значения кода страны / региона.
        /// Пример: «1» (Соединенные Штаты)
        /// </summary>
        string CountryCode;
        //string CreationClassName;
        //string CSCreationClassName;
        /// <summary>
        /// NULL - завершена строка, которая указывает последний пакет обновления, установленный на компьютере. 
        /// Если пакет обновления не установлен, строка будет NULL .
        /// Пример: «Service Pack 3»
        /// </summary>
        string CSDVersion;
        /// <summary>
        /// Название компьютерной системы обзора.
        /// </summary>
        string CSName;
        /// <summary>
        /// Число, в минутах, операционная система смещена от среднего времени по Гринвичу (GMT). Число положительное, отрицательное или ноль.
        /// </summary>
        short CurrentTimeZone;
        /// <summary>
        /// Предотвращение выполнения данных - это аппаратная функция, предотвращающая атаки переполнения буфера, прекращая выполнение кода на страницах памяти типа данных. Если True , то эта функция доступна. На 64-битных компьютерах функция предотвращения выполнения данных настроена в хранилище BCD, и соответственно устанавливаются свойства в Win32_OperatingSystem .
        /// </summary>
        bool DataExecutionPrevention_Available;
        /// <summary>
        /// Когда доступна аппаратная функция предотвращения выполнения данных, это свойство указывает, что функция настроена на работу для 32-разрядных приложений, если True . На 64-битных компьютерах функция предотвращения выполнения данных настроена в хранилище данных конфигурации загрузки (BCD), а свойства в Win32_OperatingSystem установлены соответственно.
        /// </summary>
        bool DataExecutionPrevention_32BitApplications;
        /// <summary>
        /// Когда доступна аппаратная функция предотвращения выполнения данных, это свойство указывает, что функция настроена на работу драйверов, если True . На 64-битных компьютерах функция предотвращения выполнения данных настроена в хранилище BCD, и соответственно устанавливаются свойства в Win32_OperatingSystem .
        /// </summary>
        bool DataExecutionPrevention_Drivers;
        //byte DataExecutionPrevention_SupportPolicy;
        /// <summary>
        /// Операционная система - это проверенная (отладочная) сборка. Если True , версия для отладки установлена. Проверенные сборки обеспечивают проверку ошибок, проверку аргументов и код отладки системы. Дополнительный код в проверенном двоичном файле генерирует сообщение об ошибке отладчика ядра и разбивается на отладчик. Это помогает сразу определить причину и место ошибки. Производительность может быть затронута в проверенной сборке из-за выполнения дополнительного кода.
        /// </summary>
        bool Debug;
        /// <summary>
        /// Описание операционной системы Windows.
        /// </summary>
        string Description;
        /// <summary>
        /// Если True , операционная система распределена между несколькими узлами компьютерной системы. Если это так, эти узлы должны быть сгруппированы в кластер.
        /// </summary>
        bool Distributed;
        /// <summary>
        /// Уровень шифрования для защищенных транзакций: 40-разрядный, 128-разрядный или n -бит .
        /// 
        /// 40-бит (0)
        /// 128-бит(1)
        /// N-бит(2)
        /// </summary>
        uint EncryptionLevel;
        /// <summary>
        /// Число в килобайтах физической памяти в настоящее время не используется и доступно.
        /// </summary>
        ulong FreePhysicalMemory;
        /// <summary>
        /// Число в килобайтах, которое может быть отображено в файлы подкачки операционной системы, не вызывая замены других страниц.
        /// </summary>
        ulong FreeSpaceInPagingFiles;
        /// <summary>
        /// Число в килобайтах виртуальной памяти в настоящее время не используется и доступно.
        /// </summary>
        ulong FreeVirtualMemory;
        /// <summary>
        /// Дата установки.
        /// </summary>
        DateTime InstallDate;
        //uint LargeSystemCache;
        /// <summary>
        /// Дата и время последней загрузки операционной системы.
        /// </summary>
        DateTime LastBootUpTime;
        /// <summary>
        /// Версия операционной системы локальной даты и времени суток.
        /// </summary>
        DateTime LocalDateTime;
        /// <summary>
        /// Идентификатор языка, используемый операционной системой. 
        /// </summary>
        string Locale;
        /// <summary>
        /// Название производителя операционной системы.
        /// </summary>
        string Manufacturer;
        /// <summary>
        /// Максимальное количество контекстов процесса, поддерживаемых операционной системой.
        /// </summary>
        uint MaxNumberOfProcesses;
        /// <summary>
        /// Максимальное количество в килобайтах памяти, которое может быть выделено процессу.
        /// </summary>
        ulong MaxProcessMemorySize;
        /// <summary>
        /// Многоязычный интерфейс пользовательского интерфейса (MUI Pack), установленный на компьютере. 
        /// </summary>
        string[] MUILanguages;
        /// <summary>
        /// Экземпляр операционной системы в компьютерной системе.
        /// </summary>
        string Name;
        /// <summary>
        /// Количество пользовательских лицензий для операционной системы. Если значение равно неограниченному, введите 0 (ноль). Если неизвестно, введите -1.
        /// </summary>
        uint NumberOfLicensedUsers;
        /// <summary>
        /// Количество загружаемых или работающих в операционной системе контекстов процессов.
        /// </summary>
        uint NumberOfProcesses;
        /// <summary>
        /// Количество сеансов пользователя, для которых операционная система хранит информацию о состоянии в настоящее время.
        /// </summary>
        uint NumberOfUsers;
        /*
         PRODUCT_UNDEFINED (0)
    Неопределенный
    PRODUCT_ULTIMATE (1)
    Ultimate Edition, например, Windows Vista Ultimate.
    PRODUCT_HOME_BASIC (2)
    Главная Basic Edition
    PRODUCT_HOME_PREMIUM (3)
    Home Premium Edition
    PRODUCT_ENTERPRISE (4)
    Enterprise Edition
    PRODUCT_BUSINESS (6)
    Бизнес-издание
    PRODUCT_STANDARD_SERVER (7)
    Стандартная версия Windows Server (установка рабочего стола)
    PRODUCT_DATACENTER_SERVER (8)
    Windows Server Datacenter Edition (установка рабочего стола)
    PRODUCT_SMALLBUSINESS_SERVER (9)
    Малый бизнес-сервер
    PRODUCT_ENTERPRISE_SERVER (10)
    Enterprise Server Edition
    PRODUCT_START (11)
    Версия для начинающих
    PRODUCT_DATACENTER_SERVER_CORE (12)
    Datacenter Server Core Edition
    PRODUCT_STANDARD_SERVER_CORE (13)
    Стандартный серверный Core Edition
    PRODUCT_ENTERPRISE_SERVER_CORE (14)
    Корпоративный сервер Core Edition
    PRODUCT_WEB_SERVER (17)
    Web Server Edition
    PRODUCT_HOME_SERVER (19)
    Home Server Edition
    PRODUCT_STORAGE_EXPRESS_SERVER (20)
    Storage Express Server Edition
    PRODUCT_STORAGE_STANDARD_SERVER (21)
    Стандартная версия Windows Storage Server (установка рабочего стола)
    PRODUCT_STORAGE_WORKGROUP_SERVER (22)
    Windows Workgroup Edition для Windows Server (установка рабочего стола)
    PRODUCT_STORAGE_ENTERPRISE_SERVER (23)
    Storage Enterprise Server Edition
    PRODUCT_SERVER_FOR_SMALLBUSINESS (24)
    Сервер для малого бизнеса
    PRODUCT_SMALLBUSINESS_SERVER_PREMIUM (25)
    Малый бизнес-сервер Premium Edition
    PRODUCT_ENTERPRISE_N (27)
    Windows Enterprise Edition
    PRODUCT_ULTIMATE_N (28)
    Windows Ultimate Edition
    PRODUCT_WEB_SERVER_CORE (29)
    Windows Server Web Server Edition (установка Server Core)
    PRODUCT_STANDARD_SERVER_V (36)
    Стандартная версия Windows Server без Hyper-V
    PRODUCT_DATACENTER_SERVER_V (37)
    Windows Server Datacenter Edition без Hyper-V (полная установка)
    PRODUCT_ENTERPRISE_SERVER_V (38)
    Windows Server Enterprise Edition без Hyper-V (полная установка)
    PRODUCT_DATACENTER_SERVER_CORE_V (39)
    Windows Server Datacenter Edition без Hyper-V (установка Server Core)
    PRODUCT_STANDARD_SERVER_CORE_V (40)
    Стандартная версия Windows Server без Hyper-V (установка Server Core)
    PRODUCT_ENTERPRISE_SERVER_CORE_V (41)
    Windows Server Enterprise Edition без Hyper-V (установка Server Core)
    PRODUCT_HYPERV (42)
    Сервер Microsoft Hyper-V
    PRODUCT_STORAGE_EXPRESS_SERVER_CORE (43)
    Storage Server Express Edition (установка Server Core)
    PRODUCT_STORAGE_STANDARD_SERVER_CORE (44)
    Стандартная версия сервера хранения данных (установка Server Core)
    PRODUCT_STORAGE_WORKGROUP_SERVER_CORE (45)
    Сервер Workgroup Edition сервера хранения (установка сервера ядра)
    PRODUCT_STORAGE_ENTERPRISE_SERVER_CORE (46)
    Storage Server Enterprise Edition (установка Server Core)
    PRODUCT_SB_SOLUTION_SERVER (50)
    Windows Server Essentials (установка рабочего стола)
    PRODUCT_SMALLBUSINESS_SERVER_PREMIUM_CORE (63)
    Премия Small Business Server Premium (установка Server Core)
    PRODUCT_CLUSTER_SERVER_V (64)
    Windows Compute Cluster Server без Hyper-V
    PRODUCT_CORE_ARM (97)
    Windows RT
    PRODUCT_CORE (101)
    Windows Home
    PRODUCT_PROFESSIONAL_WMC (103)
    Windows Professional с Media Center
    PRODUCT_MOBILE_CORE (104)
    Windows Mobile
    PRODUCT_IOTUAP (123)
    Windows IoT (Internet of Things) Core
    PRODUCT_DATACENTER_NANO_SERVER (143)
    Windows Server Datacenter Edition (установка Nano Server)
    PRODUCT_STANDARD_NANO_SERVER (144)
    Стандартная версия Windows Server (установка Nano Server)
    PRODUCT_DATACENTER_WS_SERVER_CORE (147)
    Windows Server Datacenter Edition (установка Server Core)
    PRODUCT_STANDARD_WS_SERVER_CORE (148)
    Стандартная версия Windows Server (установка Server Core)*/
        /// <summary>
        /// Тип издания ОС
        /// </summary>
        uint OperatingSystemSKU;
        /// <summary>
        /// Название компании для зарегистрированного пользователя операционной системы.
        /// </summary>
        string Organization;
        /// <summary>
        /// Архитектура операционной системы, в отличие от процессора.
        /// </summary>
        string OSArchitecture;
        /*
        1033 (0x409)
        Английский Соединенные Штаты
        1049 (0x419)
        Русский
        1058 (0x422)
        Украинский
        */
        /// <summary>
        /// Установлена ​​языковая версия операционной системы. 
        /// </summary>
        uint OSLanguage;
        //uint OSProductSuite;
        //ushort OSType;
        /// <summary>
        /// Дополнительное описание для текущей версии операционной системы.
        /// </summary>
        string OtherTypeDescription;
        //bool PAEEnabled;
        //string PlusProductID;
        //string PlusVersionNumber;
        /// <summary>
        /// Указывает, загружена ли операционная система с внешнего USB-устройства. Если это правда, операционная система обнаружила, что она загружается на поддерживаемое локально подключенное устройство хранения.
        /// </summary>
  //      bool PortableOperatingSystem;
        /// <summary>
        /// Указывает, является ли это основной операционной системой.
        /// </summary>
        bool Primary;
        /// <summary>
        /// Дополнительная системная информация.
        /// </summary>
        /*
        Рабочая станция (1)
        Контроллер домена (2)
        Сервер (3)
        */
        uint ProductType;
        /// <summary>
        /// Имя зарегистрированного пользователя операционной системы.
        /// </summary>
        string RegisteredUser;
        /// <summary>
        /// Серийный идентификационный номер продукта операционной системы.
        /// </summary>
        string SerialNumber;
        /// <summary>
        /// Номер основной версии пакета обновления, установленного в компьютерной системе. Если пакет обновления не установлен, значение равно 0 (ноль).
        /// </summary>
        ushort ServicePackMajorVersion;
        /// <summary>
        /// Незначительный номер версии пакета обновления, установленного в компьютерной системе. Если пакет обновления не установлен, значение равно 0 (ноль).
        /// </summary>
        ushort ServicePackMinorVersion;
        /// <summary>
        /// Общее количество килобайт, которые могут быть сохранены в файлах подкачки операционной системы - 0 (ноль), указывает на отсутствие файлов подкачки. Имейте в виду, что это число не отражает фактический физический размер файла подкачки на диске.
        /// </summary>
        ulong SizeStoredInPagingFiles;
        /// <summary>
        /// Текущее состояние объекта. 
        /// </summary>
        /*
        OK («ОК»)
        Ошибка(«Ошибка»)
        Деградированные(«деградированные»)
        Неизвестно(«Неизвестно»)
        Pred Fail(«Pred Fail»)
        Запуск(«Запуск»)
        Остановка(«Остановка»)
        Сервис(«Сервис»)
        Подчеркнутый(«Подчеркнутый»)
        NonRecover(«NonRecover»)
        Нет контакта(«Без контакта»)
        Lost Comm(«Потерянная связь»)*/
        string Status;
        /// <summary>
        /// Бит-флаги, которые идентифицируют набор продуктов, доступных в системе.
        /// </summary>
        /*1
        Малый бизнес
        2
        предприятие
        4
        Бэк-офис
        8
        связи
        16
        Услуги терминалов
        32
        Малый бизнес ограничен
        64
        Встраиваемая версия
        128
        Datacenter Edition
        256
        Один пользователь
        512
        Домашняя версия
        1024
        Web Server Edition 
        */
        uint SuiteMask;
        /// <summary>
        /// Раздел физического диска, на котором установлена ​​операционная система.
        /// </summary>
        string SystemDevice;
        /// <summary>
        /// Системный каталог операционной системы.
        /// Пример: «C: \ WINDOWS \ SYSTEM32»
        /// </summary>
        string SystemDirectory;
        /// <summary>
        /// Буква диска, на котором находится операционная система. Пример: "C:"
        /// </summary>
        string SystemDrive;
        /// <summary>
        /// Общее пространство подкачки в килобайтах. 
        /// </summary>
        ulong TotalSwapSpaceSize;
        /// <summary>
        /// Число в килобайтах виртуальной памяти. 
        /// </summary>
        ulong TotalVirtualMemorySize;
        /// <summary>
        /// Общее количество в килобайтах физической памяти, доступной операционной системе.
        /// </summary>
        ulong TotalVisibleMemorySize;
        /// <summary>
        /// Номер версии операционной системы.
        /// </summary>
        string Version;
        /// <summary>
        /// Каталог ОС операционной системы Windows.
        /// Пример: «C: \ WINDOWS»
        /// </summary>
        string WindowsDirectory;
        //
        //   

        /*enum MyEnum
        {
    BootDevice                                      ,
    BuildNumber                                     ,
    BuildType                                       ,
    Caption                                         ,
    CodeSet                                         ,
    CountryCode                                     ,
    CSDVersion                                      ,
    CSName                                          ,
    CurrentTimeZone                                 ,
    DataExecutionPrevention_Available               ,
    DataExecutionPrevention_32BitApplications       ,
    DataExecutionPrevention_Drivers                 ,
    Debug                                           ,
    Description                                     ,
    Distributed                                     ,
    EncryptionLevel                                 ,
    FreePhysicalMemory                              ,
    FreeSpaceInPagingFiles                          ,
    FreeVirtualMemory                               ,
    InstallDate                                     ,
    LastBootUpTime                                  ,
    LocalDateTime                                   ,
    Locale                                          ,
    Manufacturer                                    ,
    MaxNumberOfProcesses                            ,
    MaxProcessMemorySize                            ,
    MUILanguages                                    ,
    Name                                            ,
    NumberOfLicensedUsers                           ,
    NumberOfProcesses                               ,
    NumberOfUsers                                   ,
    OperatingSystemSKU                              ,
    Organization                                    ,
    OSArchitecture                                  ,
    OSLanguage                                      ,
    OtherTypeDescription                            ,
    PortableOperatingSystem                         ,
    Primary                                         ,
    ProductType                                     ,
    RegisteredUser                                  ,
    SerialNumber                                    ,
    ServicePackMajorVersion                         ,
    SizeStoredInPagingFiles                         ,
    Status                                          ,
    SuiteMask                                       ,
    SystemDevice                                    ,
    SystemDirectory                                 ,
    SystemDrive                                     ,
    TotalSwapSpaceSize                              ,
    TotalVirtualMemorySize                          ,
    TotalVisibleMemorySize                          ,
    Version                                         ,
    WindowsDirectory                                
        }
        */

        public List<object[]> GetData()
        {
            
            List<object[]> os = new List<object[]>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            foreach (ManagementObject item in searcher.Get())
            {
                foreach (string field in GetFields().Split(';'))
                {
                    try
                    {
                    os.Add(new object[] { field, item[field] });
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
            return os;
        }

        public object this[string name]
        {
            get
            {
                switch (name)
                {
                    case "BootDevice": return BootDevice;
                    case "BuildNumber": return BuildNumber;
                    case "BuildType": return BuildType;
                    case "Caption": return Caption;
                    case "CodeSet": return CodeSet;
                    case "CountryCode": return CountryCode;
                    case "CSDVersion": return CSDVersion;
                    case "CSName": return CSName;
                    case "CurrentTimeZone": return CurrentTimeZone;
                    case "DataExecutionPrevention_Available": return DataExecutionPrevention_Available;
                    case "DataExecutionPrevention_32BitApplications": return DataExecutionPrevention_32BitApplications;
                    case "DataExecutionPrevention_Drivers": return DataExecutionPrevention_Drivers;
                    case "Debug": return Debug;
                    case "Description": return Description;
                    case "Distributed": return Distributed;
                    case "EncryptionLevel": return EncryptionLevel;
                    case "FreePhysicalMemory": return FreePhysicalMemory;
                    case "FreeSpaceInPagingFiles": return FreeSpaceInPagingFiles;
                    case "FreeVirtualMemory": return FreeVirtualMemory;
                    case "InstallDate": return InstallDate;
                    case "LastBootUpTime": return LastBootUpTime;
                    case "LocalDateTime": return LocalDateTime;
                    case "Locale": return Locale;
                    case "Manufacturer": return Manufacturer;
                    case "MaxNumberOfProcesses": return MaxNumberOfProcesses;
                    case "MaxProcessMemorySize": return MaxProcessMemorySize;
                    case "MUILanguages": return MUILanguages;
                    case "Name": return Name;
                    case "NumberOfLicensedUsers": return NumberOfLicensedUsers;
                    case "NumberOfProcesses": return NumberOfProcesses;
                    case "NumberOfUsers": return NumberOfUsers;
                    case "OperatingSystemSKU": return OperatingSystemSKU;
                    case "Organization": return Organization;
                    case "OSArchitecture": return OSArchitecture;
                    case "OSLanguage": return OSLanguage;
                    case "OtherTypeDescription": return OtherTypeDescription;
                   // case "PortableOperatingSystem": return PortableOperatingSystem;
                    case "Primary": return Primary;
                    case "ProductType": return ProductType;
                    case "RegisteredUser": return RegisteredUser;
                    case "SerialNumber": return SerialNumber;
                    case "ServicePackMajorVersion": return ServicePackMajorVersion;
                    case "SizeStoredInPagingFiles": return SizeStoredInPagingFiles;
                    case "Status": return Status;
                    case "SuiteMask": return SuiteMask;
                    case "SystemDevice": return SystemDevice;
                    case "SystemDirectory": return SystemDirectory;
                    case "SystemDrive": return SystemDrive;
                    case "TotalSwapSpaceSize": return TotalSwapSpaceSize;
                    case "TotalVirtualMemorySize": return TotalVirtualMemorySize;
                    case "TotalVisibleMemorySize": return TotalVisibleMemorySize;
                    case "Version": return Version;
                    case "WindowsDirectory": return WindowsDirectory;
                    default:
                        return null;
                }
            }
            set
            {
                switch (name)
                {
                    case "BootDevice": value = BootDevice; break;
                    case "BuildNumber": value = BuildNumber; break;
                    case "BuildType": value = BuildType; break;
                    case "Caption": value = Caption; break;
                    case "CodeSet": value = CodeSet; break;
                    case "CountryCode": value = CountryCode; break;
                    case "CSDVersion": value = CSDVersion; break;
                    case "CSName": value = CSName; break;
                    case "CurrentTimeZone": value = CurrentTimeZone; break;
                    case "DataExecutionPrevention_Available": value = DataExecutionPrevention_Available; break;
                    case "DataExecutionPrevention_32BitApplications": value = DataExecutionPrevention_32BitApplications; break;
                    case "DataExecutionPrevention_Drivers": value = DataExecutionPrevention_Drivers; break;
                    case "Debug": value = Debug; break;
                    case "Description": value = Description; break;
                    case "Distributed": value = Distributed; break;
                    case "EncryptionLevel": value = EncryptionLevel; break;
                    case "FreePhysicalMemory": value = FreePhysicalMemory; break;
                    case "FreeSpaceInPagingFiles": value = FreeSpaceInPagingFiles; break;
                    case "FreeVirtualMemory": value = FreeVirtualMemory; break;
                    case "InstallDate": value = InstallDate; break;
                    case "LastBootUpTime": value = LastBootUpTime; break;
                    case "LocalDateTime": value = LocalDateTime; break;
                    case "Locale": value = Locale; break;
                    case "Manufacturer": value = Manufacturer; break;
                    case "MaxNumberOfProcesses": value = MaxNumberOfProcesses; break;
                    case "MaxProcessMemorySize": value = MaxProcessMemorySize; break;
                    case "MUILanguages": value = MUILanguages; break;
                    case "Name": value = Name; break;
                    case "NumberOfLicensedUsers": value = NumberOfLicensedUsers; break;
                    case "NumberOfProcesses": value = NumberOfProcesses; break;
                    case "NumberOfUsers": value = NumberOfUsers; break;
                    case "OperatingSystemSKU": value = OperatingSystemSKU; break;
                    case "Organization": value = Organization; break;
                    case "OSArchitecture": value = OSArchitecture; break;
                    case "OSLanguage": value = OSLanguage; break;
                    case "OtherTypeDescription": value = OtherTypeDescription; break;
               //     case "PortableOperatingSystem": value = PortableOperatingSystem; break;
                    case "Primary": value = Primary; break;
                    case "ProductType": value = ProductType; break;
                    case "RegisteredUser": value = RegisteredUser; break;
                    case "SerialNumber": value = SerialNumber; break;
                    case "ServicePackMajorVersion": value = ServicePackMajorVersion; break;
                    case "SizeStoredInPagingFiles": value = SizeStoredInPagingFiles; break;
                    case "Status": value = Status; break;
                    case "SuiteMask": value = SuiteMask; break;
                    case "SystemDevice": value = SystemDevice; break;
                    case "SystemDirectory": value = SystemDirectory; break;
                    case "SystemDrive": value = SystemDrive; break;
                    case "TotalSwapSpaceSize": value = TotalSwapSpaceSize; break;
                    case "TotalVirtualMemorySize": value = TotalVirtualMemorySize; break;
                    case "TotalVisibleMemorySize": value = TotalVisibleMemorySize; break;
                    case "Version": value = Version; break;
                    case "WindowsDirectory": value = WindowsDirectory; break;
                    default:
                        value = null;
                        break;
                }
            }
        }
        /*      public object this[int id]
              {
                  get
                  {
                      switch (d)
                      {
                          case BootDevice:
                              break;
                          case BuildNumber:
                              break;
                          case BuildType:
                              break;
                          case Caption:
                              break;
                          case CodeSet:
                              break;
                          case CountryCode:
                              break;
                          case CSDVersion:
                              break;
                          case CSName:
                              break;
                          case CurrentTimeZone:
                              break;
                          case DataExecutionPrevention_Available:
                              break;
                          case DataExecutionPrevention_32BitApplications:
                              break;
                          case DataExecutionPrevention_Drivers:
                              break;
                          case Debug:
                              break;
                          case Description:
                              break;
                          case Distributed:
                              break;
                          case EncryptionLevel:
                              break;
                          case FreePhysicalMemory:
                              break;
                          case FreeSpaceInPagingFiles:
                              break;
                          case FreeVirtualMemory:
                              break;
                          case InstallDate:
                              break;
                          case LastBootUpTime:
                              break;
                          case LocalDateTime:
                              break;
                          case Locale:
                              break;
                          case Manufacturer:
                              break;
                          case MaxNumberOfProcesses:
                              break;
                          case MaxProcessMemorySize:
                              break;
                          case MUILanguages:
                              break;
                          case Name:
                              break;
                          case NumberOfLicensedUsers:
                              break;
                          case NumberOfProcesses:
                              break;
                          case NumberOfUsers:
                              break;
                          case OperatingSystemSKU:
                              break;
                          case Organization:
                              break;
                          case OSArchitecture:
                              break;
                          case OSLanguage:
                              break;
                          case OtherTypeDescription:
                              break;
                          case PortableOperatingSystem:
                              break;
                          case Primary:
                              break;
                          case ProductType:
                              break;
                          case RegisteredUser:
                              break;
                          case SerialNumber:
                              break;
                          case ServicePackMajorVersion:
                              break;
                          case SizeStoredInPagingFiles:
                              break;
                          case Status:
                              break;
                          case SuiteMask:
                              break;
                          case SystemDevice:
                              break;
                          case SystemDirectory:
                              break;
                          case SystemDrive:
                              break;
                          case TotalSwapSpaceSize:
                              break;
                          case TotalVirtualMemorySize:
                              break;
                          case TotalVisibleMemorySize:
                              break;
                          case Version:
                              break;
                          case WindowsDirectory:
                              break;
                          default:
                              break;
                      }
                  }
                  set
                  {
                      value =
                  }
              }
      */
        public override string GetFields()
        {
            return "BootDevice;BuildNumber;BuildType;Caption;CodeSet;CountryCode;CSDVersion;CSName;CurrentTimeZone;DataExecutionPrevention_Available;" +
                "DataExecutionPrevention_32BitApplications;DataExecutionPrevention_Drivers;Debug;Description;" +
                "Distributed;EncryptionLevel;FreePhysicalMemory;FreeSpaceInPagingFiles;FreeVirtualMemory;InstallDate;LastBootUpTime;LocalDateTime;" +
                "Locale;Manufacturer;MaxNumberOfProcesses;MaxProcessMemorySize;MUILanguages;Name;NumberOfLicensedUsers;NumberOfProcesses;NumberOfUsers;" +
                "OperatingSystemSKU;Organization;OSArchitecture;OSLanguage;OtherTypeDescription;"/*PortableOperatingSystem;*/+"Primary;ProductType;RegisteredUser;" +
                "SerialNumber;ServicePackMajorVersion;SizeStoredInPagingFiles;Status;SuiteMask;SystemDevice;SystemDirectory;SystemDrive;TotalSwapSpaceSize;" +
                "TotalVirtualMemorySize;TotalVisibleMemorySize;Version;WindowsDirectory";
        }

        public override string GetDescriptionFields()
        {
            return "BootDevice;BuildNumber;BuildType;Caption;CodeSet;CountryCode;CSDVersion;CSName;CurrentTimeZone;DataExecutionPrevention_Available;" +
                "DataExecutionPrevention_32BitApplications;DataExecutionPrevention_Drivers;Debug;Description;" +
                "Distributed;EncryptionLevel;FreePhysicalMemory;FreeSpaceInPagingFiles;FreeVirtualMemory;InstallDate;LastBootUpTime;LocalDateTime;" +
                "Locale;Manufacturer;MaxNumberOfProcesses;MaxProcessMemorySize;MUILanguages;Name;NumberOfLicensedUsers;NumberOfProcesses;NumberOfUsers;" +
                "OperatingSystemSKU;Organization;OSArchitecture;OSLanguage;OtherTypeDescription;Primary;ProductType;RegisteredUser;" +
                "SerialNumber;ServicePackMajorVersion;SizeStoredInPagingFiles;Status;SuiteMask;SystemDevice;SystemDirectory;SystemDrive;TotalSwapSpaceSize;" +
                "TotalVirtualMemorySize;TotalVisibleMemorySize;Version;WindowsDirectory";
        }
    }
}


/*
BootDevice
BuildNumber
BuildType
Caption
CodeSet
CountryCode
CSDVersion
CSName
CurrentTimeZone
DataExecutionPrevention_Available
DataExecutionPrevention_32BitApplications
DataExecutionPrevention_Drivers
Debug
Description
Distributed
EncryptionLevel
FreePhysicalMemory
FreeSpaceInPagingFiles
FreeVirtualMemory
InstallDate
LastBootUpTime
LocalDateTime
Locale
Manufacturer
MaxNumberOfProcesses
MaxProcessMemorySize
MUILanguages
Name
NumberOfLicensedUsers
NumberOfProcesses
NumberOfUsers
OperatingSystemSKU
Organization
OSArchitecture
OSLanguage
OtherTypeDescription
PortableOperatingSystem
Primary
ProductType
RegisteredUser
SerialNumber
ServicePackMajorVersion
SizeStoredInPagingFiles
Status
SuiteMask
SystemDevice
SystemDirectory
SystemDrive
TotalSwapSpaceSize
TotalVirtualMemorySize
TotalVisibleMemorySize
Version
WindowsDirectory
*/
