using System;
using System.Data;
using System.IO;
using System.Management;
using System.Windows.Forms;
using System.Xml;

namespace WinScaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void save(string name)
        {
            if (!checkBox2.Checked)
                return;
            if (!Directory.Exists("c:\\ScanerData"))
                Directory.CreateDirectory("c:\\ScanerData");

            string path = "c:\\ScanerData\\" + name + ".xml";
            DataTable dT = (DataTable)dataGridView1.DataSource;
            DataSet dS = new DataSet();
            dS.Tables.Add(dT);
            dS.WriteXml(File.OpenWrite(path));
        }
        public void load(string name)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            string path = "c:\\ScanerDataL\\" + name + ".xml";

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(path);
            
            dataGridView2.DataSource = dataSet.Tables[0];

            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            string path2 = "c:\\ScanerDataL2\\" + name + ".xml";

            DataSet dataSet2 = new DataSet();
            dataSet2.ReadXml(path2);

            dataGridView3.DataSource = dataSet2.Tables[0];
        }

        private void btWin32_BootConfiguration_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if(checkBox1.Checked)
            {
                load("Win32_BootConfiguration");
                //return;
            }
            //gridTable.Columns.Add("c1",                                               "c1");
            //gridTable.Columns.Add("c2",                                               "c2");


            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("c1", typeof(object));
            gridTable.Columns.Add("c2", typeof(object));



            SelectQuery query = new SelectQuery("SELECT * FROM Win32_BootConfiguration");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                gridTable.Rows.Add(new object[] { "BootDirectory", item["BootDirectory"] });
                gridTable.Rows.Add(new object[] { "Caption", item["Caption"] });
                gridTable.Rows.Add(new object[] { "ConfigurationPath", item["ConfigurationPath"] });
                gridTable.Rows.Add(new object[] { "Description", item["Description"] });
                gridTable.Rows.Add(new object[] { "LastDrive", item["LastDrive"] });
                gridTable.Rows.Add(new object[] { "Name", item["Name"] });
                gridTable.Rows.Add(new object[] { "ScratchDirectory", item["ScratchDirectory"] });
                gridTable.Rows.Add(new object[] { "SettingID", item["SettingID"] });
                gridTable.Rows.Add(new object[] { "TempDirectory", item["TempDirectory"] });
            }

            dataGridView1.DataSource = gridTable;
            save("Win32_BootConfiguration");
            //BootDirectory;Caption;ConfigurationPath;Description;LastDrive;Name;ScratchDirectory;SettingID;TempDirectory
             
        }

        private void btWin32_LogicalProgramGroup_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_LogicalProgramGroup");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Caption",    typeof(object) );
            gridTable.Columns.Add("Description",typeof(object) );
            gridTable.Columns.Add("GroupName",  typeof(object) );
            gridTable.Columns.Add("InstallDate",typeof(object) );
            gridTable.Columns.Add("Name",       typeof(object) );
            gridTable.Columns.Add("Status",     typeof(object)     );
            gridTable.Columns.Add("UserName", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_LogicalProgramGroup");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                gridTable.Rows.Add(new object[] {item["Caption"],
                    item["Description"] ,
                    item["GroupName"],
                    item["InstallDate"],
                    item["Name"],
                    item["Status"],
                    item["UserName"]
                });
            }
            //Description;GroupName;InstallDate;Name;Status;UserName
            dataGridView1.DataSource = gridTable;
            save("Win32_LogicalProgramGroup");
        }

        private void btWin32_Process_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_Process");
                //return;
            }

            DataTable gridTable = new DataTable();

            gridTable.Columns.Add("Caption"                          ,typeof(object));     
            gridTable.Columns.Add("CommandLine"                      ,typeof(object));     
            gridTable.Columns.Add("CreationClassName"                ,typeof(object));     
            gridTable.Columns.Add("CreationDate"                     ,typeof(object));     
            gridTable.Columns.Add("CSCreationClassName"              ,typeof(object));     
            gridTable.Columns.Add("CSName"                           ,typeof(object));     
            gridTable.Columns.Add("Description"                      ,typeof(object));     
            gridTable.Columns.Add("ExecutablePath"                   ,typeof(object));     
            gridTable.Columns.Add("ExecutionState"                   ,typeof(object));     
            gridTable.Columns.Add("Handle"                           ,typeof(object));     
            gridTable.Columns.Add("HandleCount"                      ,typeof(object));     
            gridTable.Columns.Add("InstallDate"                      ,typeof(object));     
            gridTable.Columns.Add("KernelModeTime"                   ,typeof(object));     
            gridTable.Columns.Add("MaximumWorkingSetSize"            ,typeof(object));     
            gridTable.Columns.Add("MinimumWorkingSetSize"            ,typeof(object));     
            gridTable.Columns.Add("Name"                             ,typeof(object));     
            gridTable.Columns.Add("OSCreationClassName"              ,typeof(object));     
            gridTable.Columns.Add("OSName"                           ,typeof(object));     
            gridTable.Columns.Add("OtherOperationCount"              ,typeof(object));     
            gridTable.Columns.Add("OtherTransferCount"               ,typeof(object));     
            gridTable.Columns.Add("PageFaults"                       ,typeof(object));     
            gridTable.Columns.Add("PageFileUsage"                    ,typeof(object));     
            gridTable.Columns.Add("ParentProcessId"                  ,typeof(object));     
            gridTable.Columns.Add("PeakPageFileUsage"                ,typeof(object));     
            gridTable.Columns.Add("PeakVirtualSize"                  ,typeof(object));     
            gridTable.Columns.Add("PeakWorkingSetSize"               ,typeof(object));     
            gridTable.Columns.Add("Priority"                         ,typeof(object));     
            gridTable.Columns.Add("PrivatePageCount"                 ,typeof(object));     
            gridTable.Columns.Add("ProcessId"                        ,typeof(object));     
            gridTable.Columns.Add("QuotaNonPagedPoolUsage"           ,typeof(object));     
            gridTable.Columns.Add("QuotaPagedPoolUsage"              ,typeof(object));     
            gridTable.Columns.Add("QuotaPeakNonPagedPoolUsage"       ,typeof(object));     
            gridTable.Columns.Add("QuotaPeakPagedPoolUsage"          ,typeof(object));     
            gridTable.Columns.Add("ReadOperationCount"               ,typeof(object));     
            gridTable.Columns.Add("ReadTransferCount"                ,typeof(object));     
            gridTable.Columns.Add("SessionId"                        ,typeof(object));     
            gridTable.Columns.Add("Status"                           ,typeof(object));     
            gridTable.Columns.Add("TerminationDate"                  ,typeof(object));     
            gridTable.Columns.Add("ThreadCount"                      ,typeof(object));     
            gridTable.Columns.Add("UserModeTime"                     ,typeof(object));     
            gridTable.Columns.Add("VirtualSize"                      ,typeof(object));     
            gridTable.Columns.Add("WindowsVersion"                   ,typeof(object));     
            gridTable.Columns.Add("WorkingSetSize"                   ,typeof(object));     
            gridTable.Columns.Add("WriteOperationCount"              ,typeof(object));
            gridTable.Columns.Add("WriteTransferCount",               typeof(object));                      

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_Process");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                gridTable.Rows.Add(new object[] {
            item["Caption"                      ],
            item["CommandLine"                  ],
            item["CreationClassName"            ],
            item["CreationDate"                 ],
            item["CSCreationClassName"          ],
            item["CSName"                       ],
            item["Description"                  ],
            item["ExecutablePath"               ],
            item["ExecutionState"               ],
            item["Handle"                       ],
            item["HandleCount"                  ],
            item["InstallDate"                  ],
            item["KernelModeTime"               ],
            item["MaximumWorkingSetSize"        ],
            item["MinimumWorkingSetSize"        ],
            item["Name"                         ],
            item["OSCreationClassName"          ],
            item["OSName"                       ],
            item["OtherOperationCount"          ],
            item["OtherTransferCount"           ],
            item["PageFaults"                   ],
            item["PageFileUsage"                ],
            item["ParentProcessId"              ],
            item["PeakPageFileUsage"            ],
            item["PeakVirtualSize"              ],
            item["PeakWorkingSetSize"           ],
            item["Priority"                     ],
            item["PrivatePageCount"             ],
            item["ProcessId"                    ],
            item["QuotaNonPagedPoolUsage"       ],
            item["QuotaPagedPoolUsage"          ],
            item["QuotaPeakNonPagedPoolUsage"   ],
            item["QuotaPeakPagedPoolUsage"      ],
            item["ReadOperationCount"           ],
            item["ReadTransferCount"            ],
            item["SessionId"                    ],
            item["Status"                       ],
            item["TerminationDate"              ],
            item["ThreadCount"                  ],
            item["UserModeTime"                 ],
            item["VirtualSize"                  ],
            item["WindowsVersion"               ],
            item["WorkingSetSize"               ],
            item["WriteOperationCount"          ],
            item["WriteTransferCount"           ]

                });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_Process");
        }

        private void btWin32_OperatingSystem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_OperatingSystem");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("c1",                                               typeof(object));
            gridTable.Columns.Add("c2", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                gridTable.Rows.Add(new object[] { "BootDevice", item["BootDevice"] });
                gridTable.Rows.Add(new object[] { "BuildNumber", item["BuildNumber"] });
                gridTable.Rows.Add(new object[] { "BuildType", item["BuildType"] });
                gridTable.Rows.Add(new object[] { "Caption", item["Caption"] });
                gridTable.Rows.Add(new object[] { "CodeSet", item["CodeSet"] });
                gridTable.Rows.Add(new object[] { "CountryCode", item["CountryCode"] });
                gridTable.Rows.Add(new object[] { "CreationClassName", item["CreationClassName"] });
                gridTable.Rows.Add(new object[] { "CSCreationClassName", item["CSCreationClassName"] });
                gridTable.Rows.Add(new object[] { "CSDVersion", item["CSDVersion"] });
                gridTable.Rows.Add(new object[] { "CSName", item["CSName"] });
                gridTable.Rows.Add(new object[] { "CurrentTimeZone", item["CurrentTimeZone"] });
                gridTable.Rows.Add(new object[] { "DataExecutionPrevention_Available", item["DataExecutionPrevention_Available"] });
                gridTable.Rows.Add(new object[] { "DataExecutionPrevention_32BitApplications", item["DataExecutionPrevention_32BitApplications"] });
                gridTable.Rows.Add(new object[] { "DataExecutionPrevention_Drivers", item["DataExecutionPrevention_Drivers"] });
                gridTable.Rows.Add(new object[] { "DataExecutionPrevention_SupportPolicy", item["DataExecutionPrevention_SupportPolicy"] });
                gridTable.Rows.Add(new object[] { "Debug", item["Debug"] });
                gridTable.Rows.Add(new object[] { "Description", item["Description"] });
                gridTable.Rows.Add(new object[] { "Distributed", item["Distributed"] });
                gridTable.Rows.Add(new object[] { "EncryptionLevel", item["EncryptionLevel"] });
                gridTable.Rows.Add(new object[] { "ForegroundApplicationBoost", item["ForegroundApplicationBoost"] });
                gridTable.Rows.Add(new object[] { "FreePhysicalMemory", item["FreePhysicalMemory"] });
                gridTable.Rows.Add(new object[] { "FreeSpaceInPagingFiles", item["FreeSpaceInPagingFiles"] });
                gridTable.Rows.Add(new object[] { "FreeVirtualMemory", item["FreeVirtualMemory"] });
                gridTable.Rows.Add(new object[] { "InstallDate", item["InstallDate"] });
                gridTable.Rows.Add(new object[] { "LargeSystemCache", item["LargeSystemCache"] });
                gridTable.Rows.Add(new object[] { "LastBootUpTime", item["LastBootUpTime"] });
                gridTable.Rows.Add(new object[] { "LocalDateTime", item["LocalDateTime"] });
                gridTable.Rows.Add(new object[] { "Locale", item["Locale"] });
                gridTable.Rows.Add(new object[] { "Manufacturer", item["Manufacturer"] });
                gridTable.Rows.Add(new object[] { "MaxNumberOfProcesses", item["MaxNumberOfProcesses"] });
                gridTable.Rows.Add(new object[] { "MaxProcessMemorySize", item["MaxProcessMemorySize"] });
                string str = "";
                foreach (var item0 in (string[])item["MUILanguages"])
                {
                    str += " | " + item0;
                }
                gridTable.Rows.Add(new object[] { "MUILanguages", str + " | " });
                gridTable.Rows.Add(new object[] { "Name", item["Name"] });
                gridTable.Rows.Add(new object[] { "NumberOfLicensedUsers", item["NumberOfLicensedUsers"] });
                gridTable.Rows.Add(new object[] { "NumberOfProcesses", item["NumberOfProcesses"] });
                gridTable.Rows.Add(new object[] { "NumberOfUsers", item["NumberOfUsers"] });
                gridTable.Rows.Add(new object[] { "OperatingSystemSKU", item["OperatingSystemSKU"] });
                gridTable.Rows.Add(new object[] { "Organization", item["Organization"] });
                gridTable.Rows.Add(new object[] { "OSArchitecture", item["OSArchitecture"] });
                gridTable.Rows.Add(new object[] { "OSLanguage", item["OSLanguage"] });
                gridTable.Rows.Add(new object[] { "OSProductSuite", item["OSProductSuite"] });
                gridTable.Rows.Add(new object[] { "OSType", item["OSType"] });
                gridTable.Rows.Add(new object[] { "OtherTypeDescription", item["OtherTypeDescription"] });
                gridTable.Rows.Add(new object[] { "PAEEnabled", item["PAEEnabled"] });
                gridTable.Rows.Add(new object[] { "PlusProductID", item["PlusProductID"] });
                gridTable.Rows.Add(new object[] { "PlusVersionNumber", item["PlusVersionNumber"] });
            //    gridTable.Rows.Add(new object[] { "PortableOperatingSystem", item["PortableOperatingSystem"] });
                gridTable.Rows.Add(new object[] { "Primary", item["Primary"] });
                gridTable.Rows.Add(new object[] { "ProductType", item["ProductType"] });
                gridTable.Rows.Add(new object[] { "RegisteredUser", item["RegisteredUser"] });
                gridTable.Rows.Add(new object[] { "SerialNumber", item["SerialNumber"] });
                gridTable.Rows.Add(new object[] { "ServicePackMajorVersion", item["ServicePackMajorVersion"] });
                gridTable.Rows.Add(new object[] { "ServicePackMinorVersion", item["ServicePackMinorVersion"] });
                gridTable.Rows.Add(new object[] { "SizeStoredInPagingFiles", item["SizeStoredInPagingFiles"] });
                gridTable.Rows.Add(new object[] { "Status", item["Status"] });
                gridTable.Rows.Add(new object[] { "SuiteMask", item["SuiteMask"] });
                gridTable.Rows.Add(new object[] { "SystemDevice", item["SystemDevice"] });
                gridTable.Rows.Add(new object[] { "SystemDirectory", item["SystemDirectory"] });
                gridTable.Rows.Add(new object[] { "SystemDrive", item["SystemDrive"] });
                gridTable.Rows.Add(new object[] { "TotalSwapSpaceSize", item["TotalSwapSpaceSize"] });
                gridTable.Rows.Add(new object[] { "TotalVirtualMemorySize", item["TotalVirtualMemorySize"] });
                gridTable.Rows.Add(new object[] { "TotalVisibleMemorySize", item["TotalVisibleMemorySize"] });
                gridTable.Rows.Add(new object[] { "Version", item["Version"] });
                gridTable.Rows.Add(new object[] { "WindowsDirectory", item["WindowsDirectory"] });


            }
            dataGridView1.DataSource = gridTable;
            save("Win32_OperatingSystem");
        }

        private void btWin32_DiskDrive_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_DiskDrive");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Availability",                              typeof(object));
            gridTable.Columns.Add("BytesPerSector",                            typeof(object));
            gridTable.Columns.Add("Capabilities[]",                            typeof(object));
            gridTable.Columns.Add("CapabilityDescriptions[]",                  typeof(object));
            gridTable.Columns.Add("Caption",                                   typeof(object));
            gridTable.Columns.Add("CompressionMethod",                         typeof(object));
            gridTable.Columns.Add("ConfigManagerErrorCode",                    typeof(object));
            gridTable.Columns.Add("ConfigManagerUserConfig",                   typeof(object));
            gridTable.Columns.Add("CreationClassName",                         typeof(object));
            gridTable.Columns.Add("DefaultBlockSize",                          typeof(object));
            gridTable.Columns.Add("Description",                               typeof(object));
            gridTable.Columns.Add("DeviceID",                                  typeof(object));
            gridTable.Columns.Add("ErrorCleared",                              typeof(object));
            gridTable.Columns.Add("ErrorDescription",                          typeof(object));
            gridTable.Columns.Add("ErrorMethodology",                          typeof(object));
            gridTable.Columns.Add("FirmwareRevision",                          typeof(object));
            gridTable.Columns.Add("Index",                                     typeof(object));
            gridTable.Columns.Add("InstallDate",                               typeof(object));
            gridTable.Columns.Add("InterfaceType",                             typeof(object));
            gridTable.Columns.Add("LastErrorCode",                             typeof(object));
            gridTable.Columns.Add("Manufacturer",                              typeof(object));
            gridTable.Columns.Add("MaxBlockSize",                              typeof(object));
            gridTable.Columns.Add("MaxMediaSize",                              typeof(object));
            gridTable.Columns.Add("MediaLoaded",                               typeof(object));
            gridTable.Columns.Add("MediaType",                                 typeof(object));
            gridTable.Columns.Add("MinBlockSize",                              typeof(object));
            gridTable.Columns.Add("Model",                                     typeof(object));
            gridTable.Columns.Add("Name",                                      typeof(object));
            gridTable.Columns.Add("NeedsCleaning",                             typeof(object));
            gridTable.Columns.Add("NumberOfMediaSupported",                    typeof(object));
            gridTable.Columns.Add("Partitions",                                typeof(object));
            gridTable.Columns.Add("PNPDeviceID",                               typeof(object));
            gridTable.Columns.Add("PowerManagementCapabilities[]",             typeof(object));
            gridTable.Columns.Add("PowerManagementSupported",                  typeof(object));
            gridTable.Columns.Add("SCSIBus",                                   typeof(object));
            gridTable.Columns.Add("SCSILogicalUnit",                           typeof(object));
            gridTable.Columns.Add("SCSIPort",                                  typeof(object));
            gridTable.Columns.Add("SCSITargetId",                              typeof(object));
            gridTable.Columns.Add("SectorsPerTrack",                           typeof(object));
            gridTable.Columns.Add("SerialNumber",                              typeof(object));
            gridTable.Columns.Add("Signature",                                 typeof(object));
            gridTable.Columns.Add("Size",                                      typeof(object));
            gridTable.Columns.Add("Status",                                    typeof(object));
            gridTable.Columns.Add("StatusInfo",                                typeof(object));
            gridTable.Columns.Add("SystemCreationClassName",                   typeof(object));
            gridTable.Columns.Add("SystemName",                                typeof(object));
            gridTable.Columns.Add("TotalCylinders",                            typeof(object));
            gridTable.Columns.Add("TotalHeads",                                typeof(object));
            gridTable.Columns.Add("TotalSectors",                              typeof(object));
            gridTable.Columns.Add("TotalTracks",                               typeof(object));
            gridTable.Columns.Add("TracksPerCylinder", typeof(object));


            SelectQuery query = new SelectQuery("SELECT * FROM Win32_DiskDrive");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string Capabilities = "";
                if (item["Capabilities"] is UInt16[] && ((UInt16[])item["Capabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["Capabilities"])
                    {
                        Capabilities += " | " + item0;
                    }
                string CapabilityDescriptions = "";
                if (item["CapabilityDescriptions"] is string[] && ((string[])item["CapabilityDescriptions"]) != null)
                    foreach (var item0 in (string[])item["CapabilityDescriptions"])
                    {
                        CapabilityDescriptions += " | " + item0;
                    }
                string PowerManagementCapabilities = "";
                if (item["PowerManagementCapabilities"] is UInt16[] && ((UInt16[])item["PowerManagementCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["PowerManagementCapabilities"])
                    {
                        PowerManagementCapabilities += " | " + item0;
                    }
                gridTable.Rows.Add(new object[] {
                    item["Availability"],
                    item["BytesPerSector"],
                    Capabilities,
                    CapabilityDescriptions,
                    item["Caption"],
                    item["CompressionMethod"],
                    item["ConfigManagerErrorCode"],
                    item["ConfigManagerUserConfig"],
                    item["CreationClassName"],
                    item["DefaultBlockSize"],
                    item["Description"],
                   item["DeviceID"],
                    item["ErrorCleared"],
                    item["ErrorDescription"],
                    item["ErrorMethodology"],
                    item["FirmwareRevision"],
                    item["Index"],
                    item["InstallDate"],
                    item["InterfaceType"],
                    item["LastErrorCode"],
                    item["Manufacturer"],
                    item["MaxBlockSize"],
                    item["MaxMediaSize"],
                    item["MediaLoaded"],

                    item["MediaType"],
                    item["MinBlockSize"],
                    item["Model"],
                    item["Name"],
                    item["NeedsCleaning"],
                    item["NumberOfMediaSupported"],
                    item["Partitions"],
                    item["PNPDeviceID"],

                    PowerManagementCapabilities,
                    item["PowerManagementSupported"],
                    item["SCSIBus"],
                    item["SCSILogicalUnit"],
                    item["SCSIPort"],
                    item["SCSITargetId"],
                   item["SectorsPerTrack"],

                  item["SerialNumber"],
                    item["Signature"],
                    item["Size"],
                      item["Status"],
                    item["StatusInfo"],
                    item["SystemCreationClassName"],
                    item["SystemName"],
                    item["TotalCylinders"],
                    item["TotalHeads"],
                    item["TotalSectors"],
                    item["TotalTracks"],
                    item["TracksPerCylinder"],
                    });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_DiskDrive");
        }

        private void btWin32_BaseBoard_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_BaseBoard");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("c1",                                              typeof(object));
            gridTable.Columns.Add("c2", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_BaseBoard");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string ConfigOptions = "";
                if (((string[])item["ConfigOptions"]) != null)
                    foreach (var item0 in (string[])item["ConfigOptions"])
                    {
                        ConfigOptions += " | " + item0;
                    }
                gridTable.Rows.Add(new object[] { "Caption", item["Caption"] });
                gridTable.Rows.Add(new object[] { "ConfigOptions[]", ConfigOptions });
                gridTable.Rows.Add(new object[] { "CreationClassName", item["CreationClassName"] });
                gridTable.Rows.Add(new object[] { "Depth", item["Depth"] });
                gridTable.Rows.Add(new object[] { "Description", item["Description"] });
                gridTable.Rows.Add(new object[] { "Height", item["Height"] });
                gridTable.Rows.Add(new object[] { "HostingBoard", item["HostingBoard"] });
                gridTable.Rows.Add(new object[] { "HotSwappable", item["HotSwappable"] });
                gridTable.Rows.Add(new object[] { "InstallDate", item["InstallDate"] });
                gridTable.Rows.Add(new object[] { "Manufacturer", item["Manufacturer"] });
                gridTable.Rows.Add(new object[] { "Model", item["Model"] });
                gridTable.Rows.Add(new object[] { "Name", item["Name"] });
                gridTable.Rows.Add(new object[] { "OtherIdentifyingInfo", item["OtherIdentifyingInfo"] });
                gridTable.Rows.Add(new object[] { "PartNumber", item["PartNumber"] });
                gridTable.Rows.Add(new object[] { "PoweredOn", item["PoweredOn"] });
                gridTable.Rows.Add(new object[] { "Product", item["Product"] });
                gridTable.Rows.Add(new object[] { "Removable", item["Removable"] });
                gridTable.Rows.Add(new object[] { "Replaceable", item["Replaceable"] });
                gridTable.Rows.Add(new object[] { "RequirementsDescription", item["RequirementsDescription"] });
                gridTable.Rows.Add(new object[] { "RequiresDaughterBoard", item["RequiresDaughterBoard"] });
                gridTable.Rows.Add(new object[] { "SerialNumber", item["SerialNumber"] });
                gridTable.Rows.Add(new object[] { "SKU", item["SKU"] });
                gridTable.Rows.Add(new object[] { "SlotLayout", item["SlotLayout"] });
                gridTable.Rows.Add(new object[] { "SpecialRequirements", item["SpecialRequirements"] });
                gridTable.Rows.Add(new object[] { "Status", item["Status"] });
                gridTable.Rows.Add(new object[] { "Tag", item["Tag"] });
                gridTable.Rows.Add(new object[] { "Version", item["Version"] });
                gridTable.Rows.Add(new object[] { "Weight", item["Weight"] });
                gridTable.Rows.Add(new object[] { "Width", item["Width"] });

            }
            dataGridView1.DataSource = gridTable;
            save("Win32_BaseBoard");
        }

        private void btWin32_BIOS_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_BIOS");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("c1",                                              typeof(object));
            gridTable.Columns.Add("c2", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_BIOS");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string BiosCharacteristics = "";
                if (((UInt16[])item["BiosCharacteristics"]) != null)
                    foreach (var item0 in (UInt16[])item["BiosCharacteristics"])
                    {
                        BiosCharacteristics += " | " + item0;
                    }
                string BIOSVersion = "";
                if (((string[])item["BIOSVersion"]) != null)
                    foreach (var item0 in (string[])item["BIOSVersion"])
                    {
                        BIOSVersion += " | " + item0;
                    }
                string ListOfLanguages = "";
                if (((string[])item["ListOfLanguages"]) != null)
                    foreach (var item0 in (string[])item["ListOfLanguages"])
                    {
                        ListOfLanguages += " | " + item0;
                    }
                gridTable.Rows.Add(new object[] { "BiosCharacteristics[]", BiosCharacteristics });
                gridTable.Rows.Add(new object[] { "BIOSVersion[]", BIOSVersion });
                gridTable.Rows.Add(new object[] { "BuildNumber", item["BuildNumber"] });
                gridTable.Rows.Add(new object[] { "Caption", item["Caption"] });
                gridTable.Rows.Add(new object[] { "CodeSet", item["CodeSet"] });
                gridTable.Rows.Add(new object[] { "CurrentLanguage", item["CurrentLanguage"] });
                gridTable.Rows.Add(new object[] { "Description", item["Description"] });
                gridTable.Rows.Add(new object[] { "IdentificationCode", item["IdentificationCode"] });
                gridTable.Rows.Add(new object[] { "InstallableLanguages", item["InstallableLanguages"] });
                gridTable.Rows.Add(new object[] { "InstallDate", item["InstallDate"] });
                gridTable.Rows.Add(new object[] { "LanguageEdition", item["LanguageEdition"] });
                gridTable.Rows.Add(new object[] { "ListOfLanguages[]", ListOfLanguages });
                gridTable.Rows.Add(new object[] { "Manufacturer", item["Manufacturer"] });
                gridTable.Rows.Add(new object[] { "Name", item["Name"] });
                gridTable.Rows.Add(new object[] { "OtherTargetOS", item["OtherTargetOS"] });
                gridTable.Rows.Add(new object[] { "PrimaryBIOS", item["PrimaryBIOS"] });
                gridTable.Rows.Add(new object[] { "ReleaseDate", item["ReleaseDate"] });
                gridTable.Rows.Add(new object[] { "SerialNumber", item["SerialNumber"] });
                gridTable.Rows.Add(new object[] { "SMBIOSBIOSVersion", item["SMBIOSBIOSVersion"] });
                gridTable.Rows.Add(new object[] { "SMBIOSMajorVersion", item["SMBIOSMajorVersion"] });
                gridTable.Rows.Add(new object[] { "SMBIOSMinorVersion", item["SMBIOSMinorVersion"] });
                gridTable.Rows.Add(new object[] { "SMBIOSPresent", item["SMBIOSPresent"] });
                gridTable.Rows.Add(new object[] { "SoftwareElementID", item["SoftwareElementID"] });
                gridTable.Rows.Add(new object[] { "SoftwareElementState", item["SoftwareElementState"] });
                gridTable.Rows.Add(new object[] { "Status", item["Status"] });
                gridTable.Rows.Add(new object[] { "TargetOperatingSystem", item["TargetOperatingSystem"] });
                gridTable.Rows.Add(new object[] { "Version", item["Version"] });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_BIOS");
        }

        private void btWin32_OnBoardDevice_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_OnBoardDevice");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Caption",                                        typeof(object));
            gridTable.Columns.Add("CreationClassName",                              typeof(object));
            gridTable.Columns.Add("Description",                                    typeof(object));
            gridTable.Columns.Add("DeviceType",                                     typeof(object));
            gridTable.Columns.Add("Enabled",                                        typeof(object));
            gridTable.Columns.Add("HotSwappable",                                   typeof(object));
            gridTable.Columns.Add("InstallDate",                                    typeof(object));
            gridTable.Columns.Add("Manufacturer",                                   typeof(object));
            gridTable.Columns.Add("Model",                                          typeof(object));
            gridTable.Columns.Add("Name",                                           typeof(object));
            gridTable.Columns.Add("OtherIdentifyingInfo",                           typeof(object));
            gridTable.Columns.Add("PartNumber",                                     typeof(object));
            gridTable.Columns.Add("PoweredOn",                                      typeof(object));
            gridTable.Columns.Add("Removable",                                      typeof(object));
            gridTable.Columns.Add("Replaceable",                                    typeof(object));
            gridTable.Columns.Add("SerialNumber",                                   typeof(object));
            gridTable.Columns.Add("SKU",                                            typeof(object));
            gridTable.Columns.Add("Status",                                         typeof(object));
            gridTable.Columns.Add("Tag",                                            typeof(object));
            gridTable.Columns.Add("Version", typeof(object));


            SelectQuery query = new SelectQuery("SELECT * FROM Win32_OnBoardDevice");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                gridTable.Rows.Add(new object[] {
                    item["Caption"],
                    item["CreationClassName"],
                    item["Description"],
                    item["DeviceType"],
                    item["Enabled"],
                    item["HotSwappable"],
                    item["InstallDate"],
                    item["Manufacturer"],
                    item["Model"],
                    item["Name"],
                    item["OtherIdentifyingInfo"],
                    item["PartNumber"],
                    item["PoweredOn"],
                    item["Removable"],
                    item["Replaceable"],
                    item["SerialNumber"],
                    item["SKU"],
                    item["Status"],
                    item["Tag"],
                    item["Version"],
                    });
            }
            //Caption;CreationClassName;Description;DeviceType;Enabled;HotSwappable;InstallDate;Manufacturer;Model;Name;OtherIdentifyingInfo;PartNumber;PoweredOn;Removable;Replaceable;SerialNumber;SKU;Status;Tag;Version

            dataGridView1.DataSource = gridTable;
            save("Win32_OnBoardDevice");
        }

        private void btWin32_PhysicalMemory_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_PhysicalMemory");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("BankLabel",                                         typeof(object));
            gridTable.Columns.Add("Capacity",                                          typeof(object));
            gridTable.Columns.Add("Caption",                                           typeof(object));
            gridTable.Columns.Add("CreationClassName",                                 typeof(object));
            gridTable.Columns.Add("DataWidth",                                         typeof(object));
            gridTable.Columns.Add("Description",                                       typeof(object));
            gridTable.Columns.Add("DeviceLocator",                                     typeof(object));
            gridTable.Columns.Add("FormFactor",                                        typeof(object));
            gridTable.Columns.Add("HotSwappable",                                      typeof(object));
            gridTable.Columns.Add("InstallDate",                                       typeof(object));
            gridTable.Columns.Add("InterleaveDataDepth",                               typeof(object));
            gridTable.Columns.Add("InterleavePosition",                                typeof(object));
            gridTable.Columns.Add("Manufacturer",                                      typeof(object));
            gridTable.Columns.Add("MemoryType",                                        typeof(object));
            gridTable.Columns.Add("Model",                                             typeof(object));
            gridTable.Columns.Add("Name",                                              typeof(object));
            gridTable.Columns.Add("OtherIdentifyingInfo",                              typeof(object));
            gridTable.Columns.Add("PartNumber",                                        typeof(object));
            gridTable.Columns.Add("PositionInRow",                                     typeof(object));
            gridTable.Columns.Add("PoweredOn",                                         typeof(object));
            gridTable.Columns.Add("Removable",                                         typeof(object));
            gridTable.Columns.Add("Replaceable",                                       typeof(object));
            gridTable.Columns.Add("SerialNumber",                                      typeof(object));
            gridTable.Columns.Add("SKU",                                               typeof(object));
            gridTable.Columns.Add("Speed",                                             typeof(object));
            gridTable.Columns.Add("Status",                                            typeof(object));
            gridTable.Columns.Add("Tag",                                               typeof(object));
            gridTable.Columns.Add("TotalWidth",                                        typeof(object));
            gridTable.Columns.Add("TypeDetail",                                        typeof(object));
            gridTable.Columns.Add("Version", typeof(object));


            SelectQuery query = new SelectQuery("SELECT * FROM Win32_PhysicalMemory");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                gridTable.Rows.Add(new object[] {
                    item["BankLabel"],
                    item["Capacity"],
                    item["Caption"],
                    item["CreationClassName"],
                    item["DataWidth"],
                    item["Description"],
                    item["DeviceLocator"],
                    item["FormFactor"],
                    item["HotSwappable"],
                    item["InstallDate"],
                    item["InterleaveDataDepth"],
                    item["InterleavePosition"],
                    item["Manufacturer"],
                    item["MemoryType"],
                    item["Model"],
                    item["Name"],
                    item["OtherIdentifyingInfo"],
                    item["PartNumber"],
                    item["PositionInRow"],
                    item["PoweredOn"],
                    item["Removable"],
                    item["Replaceable"],
                    item["SerialNumber"],
                    item["SKU"],
                    item["Speed"],
                    item["Status"],
                    item["Tag"],
                    item["TotalWidth"],
                    item["TypeDetail"],
                    item["Version"],
                });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_PhysicalMemory");
        }

        private void btWin32_StartupCommand_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_StartupCommand");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Caption",                                      typeof(object));
            gridTable.Columns.Add("Command",                                      typeof(object));
            gridTable.Columns.Add("Description",                                  typeof(object));
            gridTable.Columns.Add("Location",                                     typeof(object));
            gridTable.Columns.Add("Name",                                         typeof(object));
            gridTable.Columns.Add("SettingID",                                    typeof(object));
            gridTable.Columns.Add("User",                                         typeof(object));
            gridTable.Columns.Add("UserSID[]", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_StartupCommand");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string UserSID = "";
                try
                {
                if ((item["UserSID"] is string[]) && ((string[])item["UserSID"]) != null)
                    foreach (var item0 in (string[])item["UserSID"])
                    {
                        UserSID += " | " + item0;
                    }
                }
                catch (Exception)
                {
                    UserSID = "error";
                }
                gridTable.Rows.Add(new object[] {
                    item["Caption"],
                    item["Command"],
                    item["Description"],
                    item["Location"],
                    item["Name"],
                    item["SettingID"],
                    item["User"],
                    UserSID
                });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_StartupCommand");
        }

        private void btWin32_Processor_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_Processor");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("c1",                                              typeof(object));
            gridTable.Columns.Add("c2", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_Processor");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string PowerManagementCapabilities = "";
                if (((UInt16[])item["PowerManagementCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["PowerManagementCapabilities"])
                    {
                        PowerManagementCapabilities += " | " + item0;
                    }
                gridTable.Rows.Add(new object[] { "AddressWidth", item["AddressWidth"] });
                gridTable.Rows.Add(new object[] { "Architecture", item["Architecture"] });
                gridTable.Rows.Add(new object[] { "Availability", item["Availability"] });
                gridTable.Rows.Add(new object[] { "Caption", item["Caption"] });
                gridTable.Rows.Add(new object[] { "ConfigManagerErrorCode", item["ConfigManagerErrorCode"] });
                gridTable.Rows.Add(new object[] { "ConfigManagerUserConfig", item["ConfigManagerUserConfig"] });
                gridTable.Rows.Add(new object[] { "CpuStatus", item["CpuStatus"] });
                gridTable.Rows.Add(new object[] { "CreationClassName", item["CreationClassName"] });
                gridTable.Rows.Add(new object[] { "CurrentClockSpeed", item["CurrentClockSpeed"] });
                gridTable.Rows.Add(new object[] { "CurrentVoltage", item["CurrentVoltage"] });
                gridTable.Rows.Add(new object[] { "DataWidth", item["DataWidth"] });
                gridTable.Rows.Add(new object[] { "Description", item["Description"] });
                gridTable.Rows.Add(new object[] { "DeviceID", item["DeviceID"] });
                gridTable.Rows.Add(new object[] { "ErrorCleared", item["ErrorCleared"] });
                gridTable.Rows.Add(new object[] { "ErrorDescription", item["ErrorDescription"] });
                gridTable.Rows.Add(new object[] { "ExtClock", item["ExtClock"] });
                gridTable.Rows.Add(new object[] { "Family", item["Family"] });
                gridTable.Rows.Add(new object[] { "InstallDate", item["InstallDate"] });
                gridTable.Rows.Add(new object[] { "L2CacheSize", item["L2CacheSize"] });
                gridTable.Rows.Add(new object[] { "L2CacheSpeed", item["L2CacheSpeed"] });
                try
                {
                gridTable.Rows.Add(new object[] { "L3CacheSize", item["L3CacheSize"] });
                }
                catch (Exception)
                {
                    gridTable.Rows.Add(new object[] { "L3CacheSize", "error" });
                }
                try
                {
                    gridTable.Rows.Add(new object[] { "L3CacheSpeed", item["L3CacheSpeed"] });
                }
                catch (Exception)
                {
                    gridTable.Rows.Add(new object[] { "L3CacheSpeed", "error" });
                }
                gridTable.Rows.Add(new object[] { "LastErrorCode", item["LastErrorCode"] });
                gridTable.Rows.Add(new object[] { "Level", item["Level"] });
                gridTable.Rows.Add(new object[] { "LoadPercentage", item["LoadPercentage"] });
                gridTable.Rows.Add(new object[] { "Manufacturer", item["Manufacturer"] });
                gridTable.Rows.Add(new object[] { "MaxClockSpeed", item["MaxClockSpeed"] });
                gridTable.Rows.Add(new object[] { "Name", item["Name"] });
                gridTable.Rows.Add(new object[] { "NumberOfCores", item["NumberOfCores"] });
                gridTable.Rows.Add(new object[] { "NumberOfLogicalProcessors", item["NumberOfLogicalProcessors"] });
                gridTable.Rows.Add(new object[] { "OtherFamilyDescription", item["OtherFamilyDescription"] });
                gridTable.Rows.Add(new object[] { "PNPDeviceID", item["PNPDeviceID"] });
                gridTable.Rows.Add(new object[] { "PowerManagementCapabilities[]", PowerManagementCapabilities });
                gridTable.Rows.Add(new object[] { "PowerManagementSupported", item["PowerManagementSupported"] });
                gridTable.Rows.Add(new object[] { "ProcessorId", item["ProcessorId"] });
                gridTable.Rows.Add(new object[] { "ProcessorType", item["ProcessorType"] });
                gridTable.Rows.Add(new object[] { "Revision", item["Revision"] });
                gridTable.Rows.Add(new object[] { "Role", item["Role"] });
                gridTable.Rows.Add(new object[] { "SocketDesignation", item["SocketDesignation"] });
                gridTable.Rows.Add(new object[] { "Status", item["Status"] });
                gridTable.Rows.Add(new object[] { "StatusInfo", item["StatusInfo"] });
                gridTable.Rows.Add(new object[] { "Stepping", item["Stepping"] });
                gridTable.Rows.Add(new object[] { "SystemCreationClassName", item["SystemCreationClassName"] });
                gridTable.Rows.Add(new object[] { "SystemName", item["SystemName"] });
                gridTable.Rows.Add(new object[] { "UniqueId", item["UniqueId"] });
                gridTable.Rows.Add(new object[] { "UpgradeMethod", item["UpgradeMethod"] });
                gridTable.Rows.Add(new object[] { "Version", item["Version"] });
                gridTable.Rows.Add(new object[] { "VoltageCaps", item["VoltageCaps"] });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_Processor");
        }

        private void btWin32_MotherboardDevice_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_MotherboardDevice");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Availability",                                      typeof(object));
            gridTable.Columns.Add("Caption",                                           typeof(object));
            gridTable.Columns.Add("ConfigManagerErrorCode",                            typeof(object));
            gridTable.Columns.Add("ConfigManagerUserConfig",                           typeof(object));
            gridTable.Columns.Add("CreationClassName",                                 typeof(object));
            gridTable.Columns.Add("Description",                                       typeof(object));
            gridTable.Columns.Add("DeviceID",                                          typeof(object));
            gridTable.Columns.Add("ErrorCleared",                                      typeof(object));
            gridTable.Columns.Add("ErrorDescription",                                  typeof(object));
            gridTable.Columns.Add("InstallDate",                                       typeof(object));
            gridTable.Columns.Add("LastErrorCode",                                     typeof(object));
            gridTable.Columns.Add("Name",                                              typeof(object));
            gridTable.Columns.Add("PNPDeviceID",                                       typeof(object));
            gridTable.Columns.Add("PowerManagementCapabilities[]",                     typeof(object));
            gridTable.Columns.Add("PowerManagementSupported",                          typeof(object));
            gridTable.Columns.Add("PrimaryBusType",                                    typeof(object));
            gridTable.Columns.Add("RevisionNumber",                                    typeof(object));
            gridTable.Columns.Add("SecondaryBusType",                                  typeof(object));
            gridTable.Columns.Add("Status",                                            typeof(object));
            gridTable.Columns.Add("StatusInfo",                                        typeof(object));
            gridTable.Columns.Add("SystemCreationClassName",                           typeof(object));
            gridTable.Columns.Add("SystemName", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_MotherboardDevice");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string PowerManagementCapabilities = "";
                if ((item["PowerManagementCapabilities"] is UInt16[]) && ((UInt16[])item["PowerManagementCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["PowerManagementCapabilities"])
                    {
                        PowerManagementCapabilities += " | " + item0;
                    }
                gridTable.Rows.Add(new object[] {
                    item["Availability"],
                    item["Caption"],
                    item["ConfigManagerErrorCode"],
                    item["ConfigManagerUserConfig"],
                    item["CreationClassName"],
                    item["Description"],
                    item["DeviceID"],
                    item["ErrorCleared"],
                    item["ErrorDescription"],
                    item["InstallDate"],
                    item["LastErrorCode"],
                    item["Name"],
                    item["PNPDeviceID"],
                    PowerManagementCapabilities,
                    item["PowerManagementSupported"],
                    item["PrimaryBusType"],
                    item["RevisionNumber"],
                    item["SecondaryBusType"],
                    item["Status"],
                    item["StatusInfo"],
                    item["SystemCreationClassName"],
                    item["SystemName"],
                });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_MotherboardDevice");
        }

        private void btWin32_Printer_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_Printer");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Attributes",                                   typeof(object));
            gridTable.Columns.Add("Availability",                                 typeof(object));
            gridTable.Columns.Add("AvailableJobSheets[]",                         typeof(object));
            gridTable.Columns.Add("AveragePagesPerMinute",                        typeof(object));
            gridTable.Columns.Add("Capabilities[]",                               typeof(object));
            gridTable.Columns.Add("CapabilityDescriptions[]",                     typeof(object));
            gridTable.Columns.Add("Caption",                                      typeof(object));
            gridTable.Columns.Add("CharSetsSupported[]",                          typeof(object));
            gridTable.Columns.Add("Comment",                                      typeof(object));
            gridTable.Columns.Add("ConfigManagerErrorCode",                       typeof(object));
            gridTable.Columns.Add("ConfigManagerUserConfig",                      typeof(object));
            gridTable.Columns.Add("CreationClassName",                            typeof(object));
            gridTable.Columns.Add("CurrentCapabilities[]",                        typeof(object));
            gridTable.Columns.Add("CurrentCharSet",                               typeof(object));
            gridTable.Columns.Add("CurrentLanguage",                              typeof(object));
            gridTable.Columns.Add("CurrentMimeType",                              typeof(object));
            gridTable.Columns.Add("CurrentNaturalLanguage",                       typeof(object));
            gridTable.Columns.Add("CurrentPaperType",                             typeof(object));
            gridTable.Columns.Add("Default",                                      typeof(object));
            gridTable.Columns.Add("DefaultCapabilities[]",                        typeof(object));
            gridTable.Columns.Add("DefaultCopies",                                typeof(object));
            gridTable.Columns.Add("DefaultLanguage",                              typeof(object));
            gridTable.Columns.Add("DefaultMimeType",                              typeof(object));
            gridTable.Columns.Add("DefaultNumberUp",                              typeof(object));
            gridTable.Columns.Add("DefaultPaperType",                             typeof(object));
            gridTable.Columns.Add("DefaultPriority",                              typeof(object));
            gridTable.Columns.Add("Description",                                  typeof(object));
            gridTable.Columns.Add("DetectedErrorState",                           typeof(object));
            gridTable.Columns.Add("DeviceID",                                     typeof(object));
            gridTable.Columns.Add("Direct",                                       typeof(object));
            gridTable.Columns.Add("DoCompleteFirst",                              typeof(object));
            gridTable.Columns.Add("DriverName",                                   typeof(object));
            gridTable.Columns.Add("EnableBIDI",                                   typeof(object));
            gridTable.Columns.Add("EnableDevQueryPrint",                          typeof(object));
            gridTable.Columns.Add("ErrorCleared",                                 typeof(object));
            gridTable.Columns.Add("ErrorDescription",                             typeof(object));
            gridTable.Columns.Add("ErrorInformation[]",                           typeof(object));
            gridTable.Columns.Add("ExtendedDetectedErrorState",                   typeof(object));
            gridTable.Columns.Add("ExtendedPrinterStatus",                        typeof(object));
            gridTable.Columns.Add("Hidden",                                       typeof(object));
            gridTable.Columns.Add("HorizontalResolution",                         typeof(object));
            gridTable.Columns.Add("InstallDate",                                  typeof(object));
            gridTable.Columns.Add("JobCountSinceLastReset",                       typeof(object));
            gridTable.Columns.Add("KeepPrintedJobs",                              typeof(object));
            gridTable.Columns.Add("LanguagesSupported[]",                         typeof(object));
            gridTable.Columns.Add("LastErrorCode",                                typeof(object));
            gridTable.Columns.Add("Local",                                        typeof(object));
            gridTable.Columns.Add("Location",                                     typeof(object));
            gridTable.Columns.Add("MarkingTechnology",                            typeof(object));
            gridTable.Columns.Add("MaxCopies",                                    typeof(object));
            gridTable.Columns.Add("MaxNumberUp",                                  typeof(object));
            gridTable.Columns.Add("MaxSizeSupported",                             typeof(object));
            gridTable.Columns.Add("MimeTypesSupported[]",                         typeof(object));
            gridTable.Columns.Add("Name",                                         typeof(object));
            gridTable.Columns.Add("NaturalLanguagesSupported[]",                  typeof(object));
            gridTable.Columns.Add("Network",                                      typeof(object));
            gridTable.Columns.Add("PaperSizesSupported[]",                        typeof(object));
            gridTable.Columns.Add("PaperTypesAvailable[]",                        typeof(object));
            gridTable.Columns.Add("Parameters",                                   typeof(object));
            gridTable.Columns.Add("PNPDeviceID",                                  typeof(object));
            gridTable.Columns.Add("PortName",                                     typeof(object));
            gridTable.Columns.Add("PowerManagementCapabilities[]",                typeof(object));
            gridTable.Columns.Add("PowerManagementSupported",                     typeof(object));
            gridTable.Columns.Add("PrinterPaperNames[]",                          typeof(object));
            gridTable.Columns.Add("PrinterState",                                 typeof(object));
            gridTable.Columns.Add("PrinterStatus",                                typeof(object));
            gridTable.Columns.Add("PrintJobDataType",                             typeof(object));
            gridTable.Columns.Add("PrintProcessor",                               typeof(object));
            gridTable.Columns.Add("Priority",                                     typeof(object));
            gridTable.Columns.Add("Published",                                    typeof(object));
            gridTable.Columns.Add("Queued",                                       typeof(object));
            gridTable.Columns.Add("RawOnly",                                      typeof(object));
            gridTable.Columns.Add("SeparatorFile",                                typeof(object));
            gridTable.Columns.Add("ServerName",                                   typeof(object));
            gridTable.Columns.Add("Shared",                                       typeof(object));
            gridTable.Columns.Add("ShareName",                                    typeof(object));
            gridTable.Columns.Add("SpoolEnabled",                                 typeof(object));
            gridTable.Columns.Add("StartTime",                                    typeof(object));
            gridTable.Columns.Add("Status",                                       typeof(object));
            gridTable.Columns.Add("StatusInfo",                                   typeof(object));
            gridTable.Columns.Add("SystemCreationClassName",                      typeof(object));
            gridTable.Columns.Add("SystemName",                                   typeof(object));
            gridTable.Columns.Add("TimeOfLastReset",                              typeof(object));
            gridTable.Columns.Add("UntilTime",                                    typeof(object));
            gridTable.Columns.Add("VerticalResolution",                           typeof(object));
            gridTable.Columns.Add("WorkOffline", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_Printer");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string AvailableJobSheets = "";
                if ((item["AvailableJobSheets"] is string[]) && ((string[])item["AvailableJobSheets"]) != null)
                    foreach (var item0 in (string[])item["AvailableJobSheets"])
                    {
                        AvailableJobSheets += " | " + item0;
                    }

                string Capabilities = "";
                if ((item["Capabilities"] is UInt16[]) && ((UInt16[])item["Capabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["Capabilities"])
                    {
                        Capabilities += " | " + item0;
                    }

                string CapabilityDescriptions = "";
                if ((item["CapabilityDescriptions"] is string[]) && ((string[])item["CapabilityDescriptions"]) != null)
                    foreach (var item0 in (string[])item["CapabilityDescriptions"])
                    {
                        CapabilityDescriptions += " | " + item0;
                    }

                string CharSetsSupported = "";
                if ((item["CharSetsSupported"] is string[]) && ((string[])item["CharSetsSupported"]) != null)
                    foreach (var item0 in (string[])item["CharSetsSupported"])
                    {
                        CharSetsSupported += " | " + item0;
                    }

                string CurrentCapabilities = "";
                if ((item["CurrentCapabilities"] is UInt16[]) && ((UInt16[])item["CurrentCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["CurrentCapabilities"])
                    {
                        CurrentCapabilities += " | " + item0;
                    }

                string DefaultCapabilities = "";
                if ((item["DefaultCapabilities"] is UInt16[]) && ((UInt16[])item["DefaultCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["DefaultCapabilities"])
                    {
                        DefaultCapabilities += " | " + item0;
                    }

                string ErrorInformation = "";
                if ((item["ErrorInformation"] is string[]) && ((string[])item["ErrorInformation"]) != null)
                    foreach (var item0 in (string[])item["ErrorInformation"])
                    {
                        ErrorInformation += " | " + item0;
                    }

                string LanguagesSupported = "";
                if ((item["LanguagesSupported"] is UInt16[]) && ((UInt16[])item["LanguagesSupported"]) != null)
                    foreach (var item0 in (UInt16[])item["LanguagesSupported"])
                    {
                        LanguagesSupported += " | " + item0;
                    }

                string MimeTypesSupported = "";
                if ((item["MimeTypesSupported"] is string[]) && ((string[])item["MimeTypesSupported"]) != null)
                    foreach (var item0 in (string[])item["MimeTypesSupported"])
                    {
                        MimeTypesSupported += " | " + item0;
                    }

                string NaturalLanguagesSupported = "";
                if ((item["NaturalLanguagesSupported"] is string[]) && ((string[])item["NaturalLanguagesSupported"]) != null)
                    foreach (var item0 in (string[])item["NaturalLanguagesSupported"])
                    {
                        NaturalLanguagesSupported += " | " + item0;
                    }

                string PaperSizesSupported = "";
                if ((item["PaperSizesSupported"] is UInt16[]) && ((UInt16[])item["PaperSizesSupported"]) != null)
                    foreach (var item0 in (UInt16[])item["PaperSizesSupported"])
                    {
                        PaperSizesSupported += " | " + item0;
                    }

                string PaperTypesAvailable = "";
                if ((item["PaperTypesAvailable"] is string[]) && ((string[])item["PaperTypesAvailable"]) != null)
                    foreach (var item0 in (string[])item["PaperTypesAvailable"])
                    {
                        PaperTypesAvailable += " | " + item0;
                    }

                string PowerManagementCapabilities = "";
                if ((item["PowerManagementCapabilities"] is UInt16[]) && ((UInt16[])item["PowerManagementCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["PowerManagementCapabilities"])
                    {
                        PowerManagementCapabilities += " | " + item0;
                    }

                string PrinterPaperNames = "";
                if ((item["PrinterPaperNames"] is string[]) && ((string[])item["PrinterPaperNames"]) != null)
                    foreach (var item0 in (string[])item["PrinterPaperNames"])
                    {
                        PrinterPaperNames += " | " + item0;
                    }

                gridTable.Rows.Add(new object[] {
                    item["Attributes"],
                    item["Availability"],
                    AvailableJobSheets,
                    item["AveragePagesPerMinute"],
                    Capabilities,
                    CapabilityDescriptions,
                    item["Caption"],
                    CharSetsSupported,
                    item["Comment"],
                    item["ConfigManagerErrorCode"],
                    item["ConfigManagerUserConfig"],
                    item["CreationClassName"],
                    CurrentCapabilities,
                    item["CurrentCharSet"],
                    item["CurrentLanguage"],
                    item["CurrentMimeType"],
                    item["CurrentNaturalLanguage"],
                    item["CurrentPaperType"],
                    item["Default"],
                    DefaultCapabilities,
                    item["DefaultCopies"],
                    item["DefaultLanguage"],
                    item["DefaultMimeType"],
                    item["DefaultNumberUp"],
                    item["DefaultPaperType"],
                    item["DefaultPriority"],
                    item["Description"],
                    item["DetectedErrorState"],
                    item["DeviceID"],
                    item["Direct"],
                    item["DoCompleteFirst"],
                    item["DriverName"],
                    item["EnableBIDI"],
                    item["EnableDevQueryPrint"],
                    item["ErrorCleared"],
                    item["ErrorDescription"],
                    ErrorInformation,
                    item["ExtendedDetectedErrorState"],
                    item["ExtendedPrinterStatus"],
                    item["Hidden"],
                    item["HorizontalResolution"],
                    item["InstallDate"],
                    item["JobCountSinceLastReset"],
                    item["KeepPrintedJobs"],
                    LanguagesSupported,
                    item["LastErrorCode"],
                    item["Local"],
                    item["Location"],
                    item["MarkingTechnology"],
                    item["MaxCopies"],
                    item["MaxNumberUp"],
                    item["MaxSizeSupported"],
                    MimeTypesSupported,
                    item["Name"],
                    NaturalLanguagesSupported,
                    item["Network"],
                    PaperSizesSupported,
                    PaperTypesAvailable,
                    item["Parameters"],
                    item["PNPDeviceID"],
                    item["PortName"],
                    PowerManagementCapabilities,
                    item["PowerManagementSupported"],
                    PrinterPaperNames,
                    item["PrinterState"],
                    item["PrinterStatus"],
                    item["PrintJobDataType"],
                    item["PrintProcessor"],
                    item["Priority"],
                    item["Published"],
                    item["Queued"],
                    item["RawOnly"],
                    item["SeparatorFile"],
                    item["ServerName"],
                    item["Shared"],
                    item["ShareName"],
                    item["SpoolEnabled"],
                    item["StartTime"],
                    item["Status"],
                    item["StatusInfo"],
                    item["SystemCreationClassName"],
                    item["SystemName"],
                    item["TimeOfLastReset"],
                    item["UntilTime"],
                    item["VerticalResolution"],
                    item["WorkOffline"]
                });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_Printer");
        }

        private void btWin32_Battery_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_Battery");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("c1",                                              typeof(object));
            gridTable.Columns.Add("c2", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_Battery");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string PowerManagementCapabilities = "";
                if (((UInt16[])item["PowerManagementCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["PowerManagementCapabilities"])
                    {
                        PowerManagementCapabilities += " | " + item0;
                    }
                gridTable.Rows.Add(new object[] { "Availability", item["Availability"] });
                gridTable.Rows.Add(new object[] { "BatteryRechargeTime", item["BatteryRechargeTime"] });
                gridTable.Rows.Add(new object[] { "BatteryStatus", item["BatteryStatus"] });
                gridTable.Rows.Add(new object[] { "Caption", item["Caption"] });
                gridTable.Rows.Add(new object[] { "Chemistry", item["Chemistry"] });
                gridTable.Rows.Add(new object[] { "ConfigManagerErrorCode", item["ConfigManagerErrorCode"] });
                gridTable.Rows.Add(new object[] { "ConfigManagerUserConfig", item["ConfigManagerUserConfig"] });
                gridTable.Rows.Add(new object[] { "CreationClassName", item["CreationClassName"] });
                gridTable.Rows.Add(new object[] { "Description", item["Description"] });
                gridTable.Rows.Add(new object[] { "DesignCapacity", item["DesignCapacity"] });
                gridTable.Rows.Add(new object[] { "DesignVoltage", item["DesignVoltage"] });
                gridTable.Rows.Add(new object[] { "DeviceID", item["DeviceID"] });
                gridTable.Rows.Add(new object[] { "ErrorCleared", item["ErrorCleared"] });
                gridTable.Rows.Add(new object[] { "ErrorDescription", item["ErrorDescription"] });
                gridTable.Rows.Add(new object[] { "EstimatedChargeRemaining", item["EstimatedChargeRemaining"] });
                gridTable.Rows.Add(new object[] { "EstimatedRunTime", item["EstimatedRunTime"] });
                gridTable.Rows.Add(new object[] { "ExpectedBatteryLife", item["ExpectedBatteryLife"] });
                gridTable.Rows.Add(new object[] { "ExpectedLife", item["ExpectedLife"] });
                gridTable.Rows.Add(new object[] { "FullChargeCapacity", item["FullChargeCapacity"] });
                gridTable.Rows.Add(new object[] { "InstallDate", item["InstallDate"] });
                gridTable.Rows.Add(new object[] { "LastErrorCode", item["LastErrorCode"] });
                gridTable.Rows.Add(new object[] { "MaxRechargeTime", item["MaxRechargeTime"] });
                gridTable.Rows.Add(new object[] { "Name", item["Name"] });
                gridTable.Rows.Add(new object[] { "PNPDeviceID", item["PNPDeviceID"] });
                gridTable.Rows.Add(new object[] { "PowerManagementCapabilities[]", PowerManagementCapabilities });
                gridTable.Rows.Add(new object[] { "PowerManagementSupported", item["PowerManagementSupported"] });
                gridTable.Rows.Add(new object[] { "SmartBatteryVersion", item["SmartBatteryVersion"] });
                gridTable.Rows.Add(new object[] { "Status", item["Status"] });
                gridTable.Rows.Add(new object[] { "StatusInfo", item["StatusInfo"] });
                gridTable.Rows.Add(new object[] { "SystemCreationClassName", item["SystemCreationClassName"] });
                gridTable.Rows.Add(new object[] { "SystemName", item["SystemName"] });
                gridTable.Rows.Add(new object[] { "TimeOnBattery", item["TimeOnBattery"] });
                gridTable.Rows.Add(new object[] { "TimeToFullCharge", item["TimeToFullCharge"] });

            }
            dataGridView1.DataSource = gridTable;
            save("Win32_Battery");
        }

        private void btWin32_NetworkAdapter_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_NetworkAdapter");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("AdapterType",                                    typeof(object));
            gridTable.Columns.Add("AdapterTypeID",                                  typeof(object));
            gridTable.Columns.Add("AutoSense",                                      typeof(object));
            gridTable.Columns.Add("Availability",                                   typeof(object));
            gridTable.Columns.Add("Caption",                                        typeof(object));
            gridTable.Columns.Add("ConfigManagerErrorCode",                         typeof(object));
            gridTable.Columns.Add("ConfigManagerUserConfig",                        typeof(object));
            gridTable.Columns.Add("CreationClassName",                              typeof(object));
            gridTable.Columns.Add("Description",                                    typeof(object));
            gridTable.Columns.Add("DeviceID",                                       typeof(object));
            gridTable.Columns.Add("ErrorCleared",                                   typeof(object));
            gridTable.Columns.Add("ErrorDescription",                               typeof(object));
       //     gridTable.Columns.Add("GUID",                                           typeof(object));
            gridTable.Columns.Add("Index",                                          typeof(object));
            gridTable.Columns.Add("InstallDate",                                    typeof(object));
            gridTable.Columns.Add("Installed",                                      typeof(object));
       //     gridTable.Columns.Add("InterfaceIndex",                                 typeof(object));
            gridTable.Columns.Add("LastErrorCode",                                  typeof(object));
            gridTable.Columns.Add("MACAddress",                                     typeof(object));
            gridTable.Columns.Add("Manufacturer",                                   typeof(object));
            gridTable.Columns.Add("MaxNumberControlled",                            typeof(object));
            gridTable.Columns.Add("MaxSpeed",                                       typeof(object));
            gridTable.Columns.Add("Name",                                           typeof(object));
            gridTable.Columns.Add("NetConnectionID",                                typeof(object));
            gridTable.Columns.Add("NetConnectionStatus",                            typeof(object));
       //     gridTable.Columns.Add("NetEnabled",                                     typeof(object));
            gridTable.Columns.Add("NetworkAddresses[]",                             typeof(object));
            gridTable.Columns.Add("PermanentAddress",                               typeof(object));
       //     gridTable.Columns.Add("PhysicalAdapter",                                typeof(object));
            gridTable.Columns.Add("PNPDeviceID",                                    typeof(object));
            gridTable.Columns.Add("PowerManagementCapabilities[]",                  typeof(object));
            gridTable.Columns.Add("PowerManagementSupported",                       typeof(object));
            gridTable.Columns.Add("ProductName",                                    typeof(object));
            gridTable.Columns.Add("ServiceName",                                    typeof(object));
            gridTable.Columns.Add("Speed",                                          typeof(object));
            gridTable.Columns.Add("Status",                                         typeof(object));
            gridTable.Columns.Add("StatusInfo",                                     typeof(object));
            gridTable.Columns.Add("SystemCreationClassName",                        typeof(object));
            gridTable.Columns.Add("SystemName",                                     typeof(object));
            gridTable.Columns.Add("TimeOfLastReset", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_NetworkAdapter");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string NetworkAddresses = "";
                if ((item["NetworkAddresses"] is string[]) && ((string[])item["NetworkAddresses"]) != null)
                    foreach (var item0 in (string[])item["NetworkAddresses"])
                    {
                        NetworkAddresses += " | " + item0;
                    }

                string PowerManagementCapabilities = "";
                if ((item["PowerManagementCapabilities"] is UInt16[]) && ((UInt16[])item["PowerManagementCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["PowerManagementCapabilities"])
                    {
                        PowerManagementCapabilities += " | " + item0;
                    }

                gridTable.Rows.Add(new object[] {
                    item["AdapterType"],
                    item["AdapterTypeID"],
                    item["AutoSense"],
                    item["Availability"],
                    item["Caption"],
                    item["ConfigManagerErrorCode"],
                    item["ConfigManagerUserConfig"],
                    item["CreationClassName"],
                    item["Description"],
                   item["DeviceID"],
                    item["ErrorCleared"],
                    item["ErrorDescription"],
                 //   item["GUID"],
                    item["Index"],
                    item["InstallDate"],
                    item["Installed"],
                  //  item["InterfaceIndex"],
                    item["LastErrorCode"],
                    item["MACAddress"],
                    item["Manufacturer"],
                    item["MaxNumberControlled"],
                    item["MaxSpeed"],
                    item["Name"],
                    item["NetConnectionID"],
                    item["NetConnectionStatus"],
                  //  item["NetEnabled"],
                    NetworkAddresses,
                    item["PermanentAddress"],
                  //  item["PhysicalAdapter"],
                    item["PNPDeviceID"],
                    PowerManagementCapabilities,
                    item["PowerManagementSupported"],
                    item["ProductName"],
                    item["ServiceName"],
                    item["Speed"],
                    item["Status"],
                    item["StatusInfo"],
                    item["SystemCreationClassName"],
                    item["SystemName"],
                    item["TimeOfLastReset"]
                });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_NetworkAdapter");
        }

        private void btMSFT_NetAdapter_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("MSFT_NetAdapter");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Caption",                                          typeof(object));
            gridTable.Columns.Add("Description",                                      typeof(object));
            gridTable.Columns.Add("InstallDate",                                      typeof(object));
            gridTable.Columns.Add("Name",                                             typeof(object));
            gridTable.Columns.Add("Status",                                           typeof(object));
            gridTable.Columns.Add("Availability",                                     typeof(object));
            gridTable.Columns.Add("ConfigManagerErrorCode",                           typeof(object));
            gridTable.Columns.Add("ConfigManagerUserConfig",                          typeof(object));
            gridTable.Columns.Add("CreationClassName",                                typeof(object));
            gridTable.Columns.Add("DeviceID",                                         typeof(object));
            gridTable.Columns.Add("ErrorCleared",                                     typeof(object));
            gridTable.Columns.Add("ErrorDescription",                                 typeof(object));
            gridTable.Columns.Add("LastErrorCode",                                    typeof(object));
            gridTable.Columns.Add("PNPDeviceID",                                      typeof(object));
            gridTable.Columns.Add("PowerManagementCapabilities[]",                    typeof(object));
            gridTable.Columns.Add("PowerManagementSupported",                         typeof(object));
            gridTable.Columns.Add("StatusInfo",                                       typeof(object));
            gridTable.Columns.Add("SystemCreationClassName",                          typeof(object));
            gridTable.Columns.Add("SystemName",                                       typeof(object));
            gridTable.Columns.Add("Speed",                                            typeof(object));
            gridTable.Columns.Add("MaxSpeed",                                         typeof(object));
            gridTable.Columns.Add("RequestedSpeed",                                   typeof(object));
            gridTable.Columns.Add("UsageRestriction",                                 typeof(object));
            gridTable.Columns.Add("PortType",                                         typeof(object));
            gridTable.Columns.Add("OtherPortType",                                    typeof(object));
            gridTable.Columns.Add("OtherNetworkPortType",                             typeof(object));
            gridTable.Columns.Add("PortNumber",                                       typeof(object));
            gridTable.Columns.Add("LinkTechnology",                                   typeof(object));
            gridTable.Columns.Add("OtherLinkTechnology",                              typeof(object));
            gridTable.Columns.Add("PermanentAddress",                                 typeof(object));
            gridTable.Columns.Add("NetworkAddresses[]",                               typeof(object));
            gridTable.Columns.Add("FullDuplex",                                       typeof(object));
            gridTable.Columns.Add("AutoSense",                                        typeof(object));
            gridTable.Columns.Add("SupportedMaximumTransmissionUnit",                 typeof(object));
            gridTable.Columns.Add("ActiveMaximumTransmissionUnit",                    typeof(object));
            gridTable.Columns.Add("InterfaceDescription",                             typeof(object));
            gridTable.Columns.Add("InterfaceName",                                    typeof(object));
            gridTable.Columns.Add("NetLuid",                                          typeof(object));
            gridTable.Columns.Add("InterfaceGuid",                                    typeof(object));
            gridTable.Columns.Add("InterfaceIndex",                                   typeof(object));
            gridTable.Columns.Add("DeviceName",                                       typeof(object));
            gridTable.Columns.Add("NetLuidIndex",                                     typeof(object));
            gridTable.Columns.Add("Virtual",                                          typeof(object));
            gridTable.Columns.Add("Hidden",                                           typeof(object));
            gridTable.Columns.Add("NotUserRemovable",                                 typeof(object));
            gridTable.Columns.Add("IMFilter",                                         typeof(object));
            gridTable.Columns.Add("InterfaceType",                                    typeof(object));
            gridTable.Columns.Add("HardwareInterface",                                typeof(object));
            gridTable.Columns.Add("WdmInterface",                                     typeof(object));
            gridTable.Columns.Add("EndPointInterface",                                typeof(object));
            gridTable.Columns.Add("iSCSIInterface",                                   typeof(object));
            gridTable.Columns.Add("State",                                            typeof(object));
            gridTable.Columns.Add("NdisMedium",                                       typeof(object));
            gridTable.Columns.Add("NdisPhysicalMedium",                               typeof(object));
            gridTable.Columns.Add("InterfaceOperationalStatus",                       typeof(object));
            gridTable.Columns.Add("OperationalStatusDownDefaultPortNotAuthenticated", typeof(object));
            gridTable.Columns.Add("OperationalStatusDownMediaDisconnected",           typeof(object));
            gridTable.Columns.Add("OperationalStatusDownInterfacePaused",             typeof(object));
            gridTable.Columns.Add("OperationalStatusDownLowPowerState",               typeof(object));
            gridTable.Columns.Add("InterfaceAdminStatus",                             typeof(object));
            gridTable.Columns.Add("MediaConnectState",                                typeof(object));
            gridTable.Columns.Add("MtuSize",                                          typeof(object));
            gridTable.Columns.Add("VlanID",                                           typeof(object));
            gridTable.Columns.Add("TransmitLinkSpeed",                                typeof(object));
            gridTable.Columns.Add("ReceiveLinkSpeed",                                 typeof(object));
            gridTable.Columns.Add("PromiscuousMode",                                  typeof(object));
            gridTable.Columns.Add("DeviceWakeUpEnable",                               typeof(object));
            gridTable.Columns.Add("ConnectorPresent",                                 typeof(object));
            gridTable.Columns.Add("MediaDuplexState",                                 typeof(object));
            gridTable.Columns.Add("DriverDate",                                       typeof(object));
            gridTable.Columns.Add("DriverDateData",                                   typeof(object));
            gridTable.Columns.Add("DriverVersionString",                              typeof(object));
            gridTable.Columns.Add("DriverName",                                       typeof(object));
            gridTable.Columns.Add("DriverDescription",                                typeof(object));
            gridTable.Columns.Add("MajorDriverVersion",                               typeof(object));
            gridTable.Columns.Add("MinorDriverVersion",                               typeof(object));
            gridTable.Columns.Add("DriverMajorNdisVersion",                           typeof(object));
            gridTable.Columns.Add("DriverMinorNdisVersion",                           typeof(object));
            gridTable.Columns.Add("PnPDeviceID",                                      typeof(object));
            gridTable.Columns.Add("DriverProvider",                                   typeof(object));
            gridTable.Columns.Add("ComponentID",                                      typeof(object));
            gridTable.Columns.Add("LowerLayerInterfaceIndices[]",                     typeof(object));
            gridTable.Columns.Add("HigherLayerInterfaceIndices[]",                    typeof(object));
            gridTable.Columns.Add("AdminLocked", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM MSFT_NetAdapter");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string NetworkAddresses = "";
                if ((item["NetworkAddresses"] is string[]) && ((string[])item["NetworkAddresses"]) != null)
                    foreach (var item0 in (string[])item["NetworkAddresses"])
                    {
                        NetworkAddresses += " | " + item0;
                    }

                string PowerManagementCapabilities = "";
                if ((item["PowerManagementCapabilities"] is UInt16[]) && ((UInt16[])item["PowerManagementCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["PowerManagementCapabilities"])
                    {
                        PowerManagementCapabilities += " | " + item0;
                    }

                string LowerLayerInterfaceIndices = "";
                if ((item["LowerLayerInterfaceIndices"] is UInt32[]) && ((UInt32[])item["LowerLayerInterfaceIndices"]) != null)
                    foreach (var item0 in (UInt32[])item["LowerLayerInterfaceIndices"])
                    {
                        LowerLayerInterfaceIndices += " | " + item0;
                    }

                string HigherLayerInterfaceIndices = "";
                if ((item["HigherLayerInterfaceIndices"] is UInt32[]) && ((UInt32[])item["HigherLayerInterfaceIndices"]) != null)
                    foreach (var item0 in (UInt32[])item["HigherLayerInterfaceIndices"])
                    {
                        HigherLayerInterfaceIndices += " | " + item0;
                    }
                gridTable.Rows.Add(new object[] {
                    item["Caption"],
                    item["Description"],
                    item["InstallDate"],
                    item["Name"],
                    item["Status"],
                    item["Availability"],
                    item["ConfigManagerErrorCode"],
                    item["ConfigManagerUserConfig"],
                    item["CreationClassName"],
                    item["DeviceID"],
                    item["ErrorCleared"],
                    item["ErrorDescription"],
                    item["LastErrorCode"],
                    item["PNPDeviceID"],
                    PowerManagementCapabilities,
                    item["PowerManagementSupported"],
                    item["StatusInfo"],
                    item["SystemCreationClassName"],
                    item["SystemName"],
                    item["Speed"],
                    item["MaxSpeed"],
                    item["RequestedSpeed"],
                    item["UsageRestriction"],
                    item["PortType"],
                    item["OtherPortType"],
                    item["OtherNetworkPortType"],
                    item["PortNumber"],
                    item["LinkTechnology"],
                    item["OtherLinkTechnology"],
                    item["PermanentAddress"],
                    NetworkAddresses,
                    item["FullDuplex"],
                    item["AutoSense"],
                    item["SupportedMaximumTransmissionUnit"],
                    item["ActiveMaximumTransmissionUnit"],
                    item["InterfaceDescription"],
                    item["InterfaceName"],
                    item["NetLuid"],
                    item["InterfaceGuid"],
                    item["InterfaceIndex"],
                    item["DeviceName"],
                    item["NetLuidIndex"],
                    item["Virtual"],
                    item["Hidden"],
                    item["NotUserRemovable"],
                    item["IMFilter"],
                    item["InterfaceType"],
                    item["HardwareInterface"],
                    item["WdmInterface"],
                    item["EndPointInterface"],
                    item["iSCSIInterface"],
                    item["State"],
                    item["NdisMedium"],
                    item["NdisPhysicalMedium"],
                    item["InterfaceOperationalStatus"],
                    item["OperationalStatusDownDefaultPortNotAuthenticated"],
                    item["OperationalStatusDownMediaDisconnected"],
                    item["OperationalStatusDownInterfacePaused"],
                    item["OperationalStatusDownLowPowerState"],
                    item["InterfaceAdminStatus"],
                    item["MediaConnectState"],
                    item["MtuSize"],
                    item["VlanID"],
                    item["TransmitLinkSpeed"],
                    item["ReceiveLinkSpeed"],
                    item["PromiscuousMode"],
                    item["DeviceWakeUpEnable"],
                    item["ConnectorPresent"],
                    item["MediaDuplexState"],
                    item["DriverDate"],
                    item["DriverDateData"],
                    item["DriverVersionString"],
                    item["DriverName"],
                    item["DriverDescription"],
                    item["MajorDriverVersion"],
                    item["MinorDriverVersion"],
                    item["DriverMajorNdisVersion"],
                    item["DriverMinorNdisVersion"],
                    item["PnPDeviceID"],
                    item["DriverProvider"],
                    item["ComponentID"],
                    LowerLayerInterfaceIndices,
                    HigherLayerInterfaceIndices,
                    item["AdminLocked"],
                });
            }
            dataGridView1.DataSource = gridTable;
            save("MSFT_NetAdapter");
        }

        private void btWin32_NetworkAdapterConfiguration_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_NetworkAdapterConfiguration");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Caption",                                   typeof(object));
            gridTable.Columns.Add("Description",                               typeof(object));
            gridTable.Columns.Add("SettingID",                                 typeof(object));
            gridTable.Columns.Add("ArpAlwaysSourceRoute",                      typeof(object));
            gridTable.Columns.Add("ArpUseEtherSNAP",                           typeof(object));
            gridTable.Columns.Add("DatabasePath",                              typeof(object));
            gridTable.Columns.Add("DeadGWDetectEnabled",                       typeof(object));
            gridTable.Columns.Add("DefaultIPGateway[]",                        typeof(object));
            gridTable.Columns.Add("DefaultTOS",                                typeof(object));
            gridTable.Columns.Add("DefaultTTL",                                typeof(object));
            gridTable.Columns.Add("DHCPEnabled",                               typeof(object));
            gridTable.Columns.Add("DHCPLeaseExpires",                          typeof(object));
            gridTable.Columns.Add("DHCPLeaseObtained",                         typeof(object));
            gridTable.Columns.Add("DHCPServer",                                typeof(object));
            gridTable.Columns.Add("DNSDomain",                                 typeof(object));
            gridTable.Columns.Add("DNSDomainSuffixSearchOrder[]",              typeof(object));
            gridTable.Columns.Add("DNSEnabledForWINSResolution",               typeof(object));
            gridTable.Columns.Add("DNSHostName",                               typeof(object));
            gridTable.Columns.Add("DNSServerSearchOrder[]",                    typeof(object));
            gridTable.Columns.Add("DomainDNSRegistrationEnabled",              typeof(object));
            gridTable.Columns.Add("ForwardBufferMemory",                       typeof(object));
            gridTable.Columns.Add("FullDNSRegistrationEnabled",                typeof(object));
            gridTable.Columns.Add("GatewayCostMetric[]",                       typeof(object));
            gridTable.Columns.Add("IGMPLevel",                                 typeof(object));
            gridTable.Columns.Add("Index",                                     typeof(object));
        //    gridTable.Columns.Add("InterfaceIndex",                            typeof(object));
            gridTable.Columns.Add("IPAddress[]",                               typeof(object));
            gridTable.Columns.Add("IPConnectionMetric",                        typeof(object));
            gridTable.Columns.Add("IPEnabled",                                 typeof(object));
            gridTable.Columns.Add("IPFilterSecurityEnabled",                   typeof(object));
            gridTable.Columns.Add("IPPortSecurityEnabled",                     typeof(object));
            gridTable.Columns.Add("IPSecPermitIPProtocols[]",                  typeof(object));
            gridTable.Columns.Add("IPSecPermitTCPPorts[]",                     typeof(object));
            gridTable.Columns.Add("IPSecPermitUDPPorts[]",                     typeof(object));
            gridTable.Columns.Add("IPSubnet[]",                                typeof(object));
            gridTable.Columns.Add("IPUseZeroBroadcast",                        typeof(object));
            gridTable.Columns.Add("IPXAddress",                                typeof(object));
            gridTable.Columns.Add("IPXEnabled",                                typeof(object));
            gridTable.Columns.Add("IPXFrameType[]",                            typeof(object));
            gridTable.Columns.Add("IPXMediaType",                              typeof(object));
            gridTable.Columns.Add("IPXNetworkNumber[]",                        typeof(object));
            gridTable.Columns.Add("IPXVirtualNetNumber",                       typeof(object));
            gridTable.Columns.Add("KeepAliveInterval",                         typeof(object));
            gridTable.Columns.Add("KeepAliveTime",                             typeof(object));
            gridTable.Columns.Add("MACAddress",                                typeof(object));
            gridTable.Columns.Add("MTU",                                       typeof(object));
            gridTable.Columns.Add("NumForwardPackets",                         typeof(object));
            gridTable.Columns.Add("PMTUBHDetectEnabled",                       typeof(object));
            gridTable.Columns.Add("PMTUDiscoveryEnabled",                      typeof(object));
            gridTable.Columns.Add("ServiceName",                               typeof(object));
            gridTable.Columns.Add("TcpipNetbiosOptions",                       typeof(object));
            gridTable.Columns.Add("TcpMaxConnectRetransmissions",              typeof(object));
            gridTable.Columns.Add("TcpMaxDataRetransmissions",                 typeof(object));
            gridTable.Columns.Add("TcpNumConnections",                         typeof(object));
            gridTable.Columns.Add("TcpUseRFC1122UrgentPointer",                typeof(object));
            gridTable.Columns.Add("TcpWindowSize",                             typeof(object));
            gridTable.Columns.Add("WINSEnableLMHostsLookup",                   typeof(object));
            gridTable.Columns.Add("WINSHostLookupFile",                        typeof(object));
            gridTable.Columns.Add("WINSPrimaryServer",                         typeof(object));
            gridTable.Columns.Add("WINSScopeID",                               typeof(object));
            gridTable.Columns.Add("WINSSecondaryServer", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string DefaultIPGateway = "";
                if ((item["DefaultIPGateway"] is string[]) && ((string[])item["DefaultIPGateway"]) != null)
                    foreach (var item0 in (string[])item["DefaultIPGateway"])
                    {
                        DefaultIPGateway += " | " + item0;
                    }

                string DNSDomainSuffixSearchOrder = "";
                if ((item["DNSDomainSuffixSearchOrder"] is string[]) && ((string[])item["DNSDomainSuffixSearchOrder"]) != null)
                    foreach (var item0 in (string[])item["DNSDomainSuffixSearchOrder"])
                    {
                        DNSDomainSuffixSearchOrder += " | " + item0;
                    }

                string DNSServerSearchOrder = "";
                if ((item["DNSServerSearchOrder"] is string[]) && ((string[])item["DNSServerSearchOrder"]) != null)
                    foreach (var item0 in (string[])item["DNSServerSearchOrder"])
                    {
                        DNSServerSearchOrder += " | " + item0;
                    }

                string GatewayCostMetric = "";
                if ((item["GatewayCostMetric"] is UInt16[]) && ((UInt16[])item["GatewayCostMetric"]) != null)
                    foreach (var item0 in (UInt16[])item["GatewayCostMetric"])
                    {
                        GatewayCostMetric += " | " + item0;
                    }

                string IPAddress = "";
                if ((item["IPAddress"] is string[]) && ((string[])item["IPAddress"]) != null)
                    foreach (var item0 in (string[])item["IPAddress"])
                    {
                        IPAddress += " | " + item0;
                    }

                string IPSecPermitIPProtocols = "";
                if ((item["IPSecPermitIPProtocols"] is string[]) && ((string[])item["IPSecPermitIPProtocols"]) != null)
                    foreach (var item0 in (string[])item["IPSecPermitIPProtocols"])
                    {
                        IPSecPermitIPProtocols += " | " + item0;
                    }

                string IPSecPermitTCPPorts = "";
                if ((item["IPSecPermitTCPPorts"] is string[]) && ((string[])item["IPSecPermitTCPPorts"]) != null)
                    foreach (var item0 in (string[])item["IPSecPermitTCPPorts"])
                    {
                        IPSecPermitTCPPorts += " | " + item0;
                    }

                string IPSecPermitUDPPorts = "";
                if ((item["IPSecPermitUDPPorts"] is string[]) && ((string[])item["IPSecPermitUDPPorts"]) != null)
                    foreach (var item0 in (string[])item["IPSecPermitUDPPorts"])
                    {
                        IPSecPermitUDPPorts += " | " + item0;
                    }

                string IPSubnet = "";
                if ((item["IPSubnet"] is string[]) && ((string[])item["IPSubnet"]) != null)
                    foreach (var item0 in (string[])item["IPSubnet"])
                    {
                        IPSubnet += " | " + item0;
                    }

                string IPXFrameType = "";
                if ((item["IPXFrameType"] is UInt32[]) && ((UInt32[])item["IPXFrameType"]) != null)
                    foreach (var item0 in (UInt32[])item["IPXFrameType"])
                    {
                        IPXFrameType += " | " + item0;
                    }

                string IPXNetworkNumber = "";
                if ((item["IPXNetworkNumber"] is string[]) && ((string[])item["IPXNetworkNumber"]) != null)
                    foreach (var item0 in (string[])item["IPXNetworkNumber"])
                    {
                        IPXNetworkNumber += " | " + item0;
                    }
                gridTable.Rows.Add(new object[] {
                    item["Caption"],
                    item["Description"],
                    item["SettingID"],
                    item["ArpAlwaysSourceRoute"],
                    item["ArpUseEtherSNAP"],
                    item["DatabasePath"],
                    item["DeadGWDetectEnabled"],
                    DefaultIPGateway,
                    item["DefaultTOS"],
                    item["DefaultTTL"],
                    item["DHCPEnabled"],
                    item["DHCPLeaseExpires"],
                    item["DHCPLeaseObtained"],
                    item["DHCPServer"],
                    item["DNSDomain"],
                    DNSDomainSuffixSearchOrder,
                    item["DNSEnabledForWINSResolution"],
                    item["DNSHostName"],

                    DNSServerSearchOrder,
                    item["DomainDNSRegistrationEnabled"],
                    item["ForwardBufferMemory"],
                    item["FullDNSRegistrationEnabled"],
                    GatewayCostMetric,
                    item["IGMPLevel"],
                    item["Index"],
                  //  item["InterfaceIndex"],
                    IPAddress,
                    item["IPConnectionMetric"],
                    item["IPEnabled"],
                    item["IPFilterSecurityEnabled"],
                    item["IPPortSecurityEnabled"],
                    IPSecPermitIPProtocols,

                    IPSecPermitTCPPorts,
                    IPSecPermitUDPPorts,
                    IPSubnet,
                    item["IPUseZeroBroadcast"],
                    item["IPXAddress"],
                    item["IPXEnabled"],
                    IPXFrameType,
                    item["IPXMediaType"],
                    IPXNetworkNumber,
                    item["IPXVirtualNetNumber"],
                    item["KeepAliveInterval"],
                    item["KeepAliveTime"],
                    item["MACAddress"],
                    item["MTU"],
                    item["NumForwardPackets"],
                    item["PMTUBHDetectEnabled"],
                    item["PMTUDiscoveryEnabled"],
                    item["ServiceName"],
                    item["TcpipNetbiosOptions"],
                    item["TcpMaxConnectRetransmissions"],
                    item["TcpMaxDataRetransmissions"],
                    item["TcpNumConnections"],
                    item["TcpUseRFC1122UrgentPointer"],
                    item["TcpWindowSize"],
                    item["WINSEnableLMHostsLookup"],
                    item["WINSHostLookupFile"],
                    item["WINSPrimaryServer"],
                    item["WINSScopeID"],
                    item["WINSSecondaryServer"],
                });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_NetworkAdapterConfiguration");
        }

        private void btWin32_ParallelPort_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_ParallelPort");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Availability",                               typeof(object));
            gridTable.Columns.Add("Capabilities[]",                             typeof(object));
            gridTable.Columns.Add("CapabilityDescriptions[]",                   typeof(object));
            gridTable.Columns.Add("Caption",                                    typeof(object));
            gridTable.Columns.Add("ConfigManagerErrorCode",                     typeof(object));
            gridTable.Columns.Add("ConfigManagerUserConfig",                    typeof(object));
            gridTable.Columns.Add("CreationClassName",                          typeof(object));
            gridTable.Columns.Add("Description",                                typeof(object));
            gridTable.Columns.Add("DeviceID",                                   typeof(object));
            gridTable.Columns.Add("DMASupport",                                 typeof(object));
            gridTable.Columns.Add("ErrorCleared",                               typeof(object));
            gridTable.Columns.Add("ErrorDescription",                           typeof(object));
            gridTable.Columns.Add("InstallDate",                                typeof(object));
            gridTable.Columns.Add("LastErrorCode",                              typeof(object));
            gridTable.Columns.Add("MaxNumberControlled",                        typeof(object));
            gridTable.Columns.Add("Name",                                       typeof(object));
            gridTable.Columns.Add("OSAutoDiscovered",                           typeof(object));
            gridTable.Columns.Add("PNPDeviceID",                                typeof(object));
            gridTable.Columns.Add("PowerManagementCapabilities[]",              typeof(object));
            gridTable.Columns.Add("PowerManagementSupported",                   typeof(object));
            gridTable.Columns.Add("ProtocolSupported",                          typeof(object));
            gridTable.Columns.Add("Status",                                     typeof(object));
            gridTable.Columns.Add("StatusInfo",                                 typeof(object));
            gridTable.Columns.Add("SystemCreationClassName",                    typeof(object));
            gridTable.Columns.Add("SystemName",                                 typeof(object));
            gridTable.Columns.Add("TimeOfLastReset", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_ParallelPort");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string CapabilityDescriptions = "";
                if ((item["CapabilityDescriptions"] is string[]) && ((string[])item["CapabilityDescriptions"]) != null)
                    foreach (var item0 in (string[])item["CapabilityDescriptions"])
                    {
                        CapabilityDescriptions += " | " + item0;
                    }

                string Capabilities = "";
                if ((item["Capabilities"] is UInt16[]) && ((UInt16[])item["Capabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["Capabilities"])
                    {
                        Capabilities += " | " + item0;
                    }

                string PowerManagementCapabilities = "";
                if ((item["PowerManagementCapabilities"] is UInt16[]) && ((UInt16[])item["PowerManagementCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["PowerManagementCapabilities"])
                    {
                        PowerManagementCapabilities += " | " + item0;
                    }
                gridTable.Rows.Add(new object[] {
                    item["Availability"],
                    Capabilities,
                    CapabilityDescriptions,
                    item["Caption"],
                    item["ConfigManagerErrorCode"],
                    item["ConfigManagerUserConfig"],
                    item["CreationClassName"],
                    item["Description"],
                    item["DeviceID"],
                    item["DMASupport"],
                    item["ErrorCleared"],
                    item["ErrorDescription"],
                    item["InstallDate"],
                    item["LastErrorCode"],
                    item["MaxNumberControlled"],
                    item["Name"],
                    item["OSAutoDiscovered"],
                    item["PNPDeviceID"],
                    PowerManagementCapabilities,
                    item["PowerManagementSupported"],
                    item["ProtocolSupported"],
                    item["Status"],
                    item["StatusInfo"],
                    item["SystemCreationClassName"],
                    item["SystemName"],
                    item["TimeOfLastReset"],
                });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_ParallelPort");
        }

        private void btWin32_PortableBattery_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_PortableBattery");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("c1",                                              typeof(object));
            gridTable.Columns.Add("c2", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_PortableBattery");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string PowerManagementCapabilities = "";
                if ((item["PowerManagementCapabilities"] is UInt16[]) && ((UInt16[])item["PowerManagementCapabilities"]) != null)
                    foreach (var item0 in (UInt16[])item["PowerManagementCapabilities"])
                    {
                        PowerManagementCapabilities += " | " + item0;
                    }
                gridTable.Rows.Add(new object[] { "Availability", item["Availability"] });
                gridTable.Rows.Add(new object[] { "BatteryStatus", item["BatteryStatus"] });
                gridTable.Rows.Add(new object[] { "CapacityMultiplier", item["CapacityMultiplier"] });
                gridTable.Rows.Add(new object[] { "Caption", item["Caption"] });
                gridTable.Rows.Add(new object[] { "Chemistry", item["Chemistry"] });
                gridTable.Rows.Add(new object[] { "ConfigManagerErrorCode", item["ConfigManagerErrorCode"] });
                gridTable.Rows.Add(new object[] { "ConfigManagerUserConfig", item["ConfigManagerUserConfig"] });
                gridTable.Rows.Add(new object[] { "CreationClassName", item["CreationClassName"] });
                gridTable.Rows.Add(new object[] { "Description", item["Description"] });
                gridTable.Rows.Add(new object[] { "DesignCapacity", item["DesignCapacity"] });
                gridTable.Rows.Add(new object[] { "DesignVoltage", item["DesignVoltage"] });
                gridTable.Rows.Add(new object[] { "DeviceID", item["DeviceID"] });
                gridTable.Rows.Add(new object[] { "ErrorCleared", item["ErrorCleared"] });
                gridTable.Rows.Add(new object[] { "ErrorDescription", item["ErrorDescription"] });
                gridTable.Rows.Add(new object[] { "EstimatedChargeRemaining", item["EstimatedChargeRemaining"] });
                gridTable.Rows.Add(new object[] { "EstimatedRunTime", item["EstimatedRunTime"] });
                gridTable.Rows.Add(new object[] { "ExpectedBatteryLife", item["ExpectedBatteryLife"] });
                gridTable.Rows.Add(new object[] { "ExpectedLife", item["ExpectedLife"] });
                gridTable.Rows.Add(new object[] { "FullChargeCapacity", item["FullChargeCapacity"] });
                gridTable.Rows.Add(new object[] { "InstallDate", item["InstallDate"] });
                gridTable.Rows.Add(new object[] { "LastErrorCode", item["LastErrorCode"] });
                gridTable.Rows.Add(new object[] { "Location", item["Location"] });
                gridTable.Rows.Add(new object[] { "ManufactureDate", item["ManufactureDate"] });
                gridTable.Rows.Add(new object[] { "Manufacturer", item["Manufacturer"] });
                gridTable.Rows.Add(new object[] { "MaxBatteryError", item["MaxBatteryError"] });
                gridTable.Rows.Add(new object[] { "MaxRechargeTime", item["MaxRechargeTime"] });
                gridTable.Rows.Add(new object[] { "Name", item["Name"] });
                gridTable.Rows.Add(new object[] { "PNPDeviceID", item["PNPDeviceID"] });
                gridTable.Rows.Add(new object[] { "PowerManagementCapabilities[]", PowerManagementCapabilities });
                gridTable.Rows.Add(new object[] { "PowerManagementSupported", item["PowerManagementSupported"] });
                gridTable.Rows.Add(new object[] { "SmartBatteryVersion", item["SmartBatteryVersion"] });
                gridTable.Rows.Add(new object[] { "Status", item["Status"] });
                gridTable.Rows.Add(new object[] { "StatusInfo", item["StatusInfo"] });
                gridTable.Rows.Add(new object[] { "SystemCreationClassName", item["SystemCreationClassName"] });
                gridTable.Rows.Add(new object[] { "SystemName", item["SystemName"] });
                gridTable.Rows.Add(new object[] { "TimeOnBattery", item["TimeOnBattery"] });
                gridTable.Rows.Add(new object[] { "TimeToFullCharge", item["TimeToFullCharge"] });

            }
            dataGridView1.DataSource = gridTable;
            save("Win32_PortableBattery");
        }

        private void btWin32_PortResource_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_PortResource");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Alias",                                             typeof(object));
            gridTable.Columns.Add("Caption",                                           typeof(object));
            gridTable.Columns.Add("CreationClassName",                                 typeof(object));
            gridTable.Columns.Add("CSCreationClassName",                               typeof(object));
            gridTable.Columns.Add("CSName",                                            typeof(object));
            gridTable.Columns.Add("Description",                                       typeof(object));
            gridTable.Columns.Add("EndingAddress",                                     typeof(object));
            gridTable.Columns.Add("InstallDate",                                       typeof(object));
            gridTable.Columns.Add("Name",                                              typeof(object));
            gridTable.Columns.Add("StartingAddress",                                   typeof(object));
            gridTable.Columns.Add("Status", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_PortResource");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                gridTable.Rows.Add(new object[] {
                    item["Alias"],
                    item["Caption"],
                    item["CreationClassName"],
                    item["CSCreationClassName"],
                    item["CSName"],
                    item["Description"],
                    item["EndingAddress"],
                    item["InstallDate"],
                    item["Name"],
                    item["StartingAddress"],
                    item["Status"],
                });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_PortResource");
        }

        private void btWin32_PortConnector_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_PortConnector");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Caption",                                           typeof(object));
            gridTable.Columns.Add("ConnectorPinout",                                   typeof(object));
            gridTable.Columns.Add("ConnectorType[]",                                   typeof(object));
            gridTable.Columns.Add("CreationClassName",                                 typeof(object));
            gridTable.Columns.Add("Description",                                       typeof(object));
            gridTable.Columns.Add("ExternalReferenceDesignator",                       typeof(object));
            gridTable.Columns.Add("InstallDate",                                       typeof(object));
            gridTable.Columns.Add("InternalReferenceDesignator",                       typeof(object));
            gridTable.Columns.Add("Manufacturer",                                      typeof(object));
            gridTable.Columns.Add("Model",                                             typeof(object));
            gridTable.Columns.Add("Name",                                              typeof(object));
            gridTable.Columns.Add("OtherIdentifyingInfo",                              typeof(object));
            gridTable.Columns.Add("PartNumber",                                        typeof(object));
            gridTable.Columns.Add("PortType",                                          typeof(object));
            gridTable.Columns.Add("PoweredOn",                                         typeof(object));
            gridTable.Columns.Add("SerialNumber",                                      typeof(object));
            gridTable.Columns.Add("SKU",                                               typeof(object));
            gridTable.Columns.Add("Status",                                            typeof(object));
            gridTable.Columns.Add("Tag",                                               typeof(object));
            gridTable.Columns.Add("Version", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_PortConnector");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in items.Get())
            {
                string ConnectorType = "";
                if ((item["ConnectorType"] is UInt16[]) && ((UInt16[])item["ConnectorType"]) != null)
                    foreach (var item0 in (UInt16[])item["ConnectorType"])
                    {
                        ConnectorType += " | " + item0;
                    }

                gridTable.Rows.Add(new object[] {
                    item["Caption"],
                    item["ConnectorPinout"],
                    ConnectorType,
                    item["CreationClassName"],
                    item["Description"],
                    item["ExternalReferenceDesignator"],
                    item["InstallDate"],
                    item["InternalReferenceDesignator"],
                    item["Manufacturer"],
                    item["Model"],
                    item["Name"],
                    item["OtherIdentifyingInfo"],
                    item["PartNumber"],
                    item["PortType"],
                    item["PoweredOn"],
                    item["SerialNumber"],
                    item["SKU"],
                    item["Status"],
                    item["Tag"],
                    item["Version"],
                });
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_PortConnector");
        }

        private void btWin32_Product_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (checkBox1.Checked)
            {
                load("Win32_Product");
                //return;
            }
            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("Caption",                                              typeof(object));
            gridTable.Columns.Add("Description",                                          typeof(object));
            gridTable.Columns.Add("IdentifyingNumber",                                    typeof(object));
            gridTable.Columns.Add("InstallDate",                                          typeof(object));
            gridTable.Columns.Add("InstallDate2",                                         typeof(object));
            gridTable.Columns.Add("InstallLocation",                                      typeof(object));
            gridTable.Columns.Add("Vendor",                                               typeof(object));
            gridTable.Columns.Add("Version", typeof(object));

            SelectQuery query = new SelectQuery("SELECT * FROM Win32_Product");
            ManagementObjectSearcher items = new ManagementObjectSearcher(query);
            int i = 0;
            foreach (ManagementObject item in items.Get())
            {
                gridTable.Rows.Add(new object[]
                    {
                        item["Caption"],
                item["Description"],
                item["IdentifyingNumber"],
                item["InstallDate"],
                item["InstallDate2"],
                item["InstallLocation"],
                item["Vendor"],
                item["Version"]
            }
                    );
                i++;
            }
            dataGridView1.DataSource = gridTable;
            save("Win32_Product");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in this.Controls)
            {
                if(item is Button&&((Button)item).Name!="btSave")
                {
                    try
                    {
                    ((Button)item).PerformClick();

                    }
                    finally
                    {
                    i++;
                    progressBar1.Value = i;
                    }
                }
            }
            MessageBox.Show("OK");

            progressBar1.Value = 0;
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}