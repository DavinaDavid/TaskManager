using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;
using System.Management.Instrumentation;

namespace TaskManager1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            PopulateComboBox();
       
        }

        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            getAllProcesses();
        }

        private void NewTask_Click(object sender, EventArgs e)
        {
            using (RunNewTask runn = new RunNewTask())
            {
                if (runn.ShowDialog() == DialogResult.OK)
                {
                    getAllProcesses();
                }
            }

        }


        Process[] process;

        private void Form1_Load(object sender, EventArgs e)
        {
            getAllProcesses();
            detailAcount();
            Service();
            Info();
            WMiUse();
        }

        void getAllProcesses()
        {
            process = Process.GetProcesses();
            listBox1.Items.Clear();
            foreach (Process p in process)
            {
              listBox1.Items.Add(p.ProcessName);
              listBox1.Items.Add(p.Id);
            }
        }


        //refreshToolStripMenuItem
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getAllProcesses();

        }

        private void End_Task_Click(object sender, EventArgs e)
        {
            try
            {
                process[listBox1.SelectedIndex].Kill();
                getAllProcesses();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void detailAcount()
        {
            ManagementObjectSearcher m1 = new ManagementObjectSearcher("select * from Win32_userAccount");
            foreach (ManagementObject X in m1.Get())
            {
              
           dataGridView1.Rows.Add(X["Name"].ToString(), X["Domain"].ToString(), X["Status"].ToString(), X["Caption"].ToString(), X["Description"].ToString());
          
            }
            Console.Read();
        }

        public void Service()
        {
              ManagementObjectSearcher m1 = new ManagementObjectSearcher("select * from Win32_Service");
              foreach (ManagementObject X in m1.Get())
              {

                  dataGridView2.Rows.Add(X["Name"].ToString(), X["SystemName"].ToString(), X["Status"].ToString(), X["Caption"].ToString());
              }
              Console.Read();
        }

        //*****************************************PC***************************************//
        void Memory()
        {
            PerformanceCounter p = new PerformanceCounter();
            p = new PerformanceCounter("Memory", "Available MBytes");
            float y = p.NextValue();
            chart1.Series["Memory"].Points.AddXY(0, y);

        }

        void Processor()
        {
            PerformanceCounter p1 = new PerformanceCounter();
            p1 = new PerformanceCounter("Processor", "DPC Rate", "_Total");
            float y = p1.NextValue();
            chart2.Series["Processor"].Points.AddXY(0, y);

        }


        void Thread()
        {
            PerformanceCounter p2 = new PerformanceCounter();
            p2 = new PerformanceCounter("Thread", "Thread State", "_Total");
            float y = p2.NextValue();
            chart18.Series["Thread"].Points.AddXY(0, y);
        }

        void Cache()
        {
            PerformanceCounter p5 = new PerformanceCounter();
            p5 = new PerformanceCounter("Cache", "Data Maps/sec");
            float y = p5.NextValue();
            chart7.Series["Cache"].Points.AddXY(0, y);
        }

        void ProcessTime()
        {
            PerformanceCounter p5 = new PerformanceCounter();
            p5 = new PerformanceCounter("Process", "Thread Count","_Total");
            float y = p5.NextValue();
            chart5.Series["Process"].Points.AddXY(0, y);
        }

        void SystemTime()
        {
            PerformanceCounter p6 = new PerformanceCounter();
            p6 = new PerformanceCounter("System", "Processes");
            float y = p6.NextValue();
            chart4.Series["System"].Points.AddXY(0, y);
        }

        void LogicalDisk()
        {
            PerformanceCounter p7 = new PerformanceCounter();
            p7 = new PerformanceCounter("LogicalDisk", "% Free Space","_Total");
            float y = p7.NextValue();
            chart20.Series["LogicalDisk"].Points.AddXY(0, y);
        }

        void PhysicalDisk()
        {
            PerformanceCounter p8 = new PerformanceCounter();
            p8 = new PerformanceCounter("PhysicalDisk", "Split IO/sec","_Total");
            float y = p8.NextValue();
            chart19.Series["PhysicalDisk"].Points.AddXY(0, y);
        }

        void Mutexes()
        {
            PerformanceCounter p9 = new PerformanceCounter();
            p9 = new PerformanceCounter("Objects", "Mutexes");
            float y = p9.NextValue();
            chart9.Series["Mutexes"].Points.AddXY(0, y);
        }


        void Semaphores()
        {
            PerformanceCounter p10 = new PerformanceCounter();
            p10 = new PerformanceCounter("Objects", "Semaphores");
            float y = p10.NextValue();
            chart10.Series["Semaphores"].Points.AddXY(0, y);
        }

        void Threads()
        {
            PerformanceCounter p11 = new PerformanceCounter();
            p11 = new PerformanceCounter("Objects", "Threads");
            float y = p11.NextValue();
            chart3.Series["Threads"].Points.AddXY(0, y);
        }


        void Eventss()
        {
            PerformanceCounter p12 = new PerformanceCounter();
            p12 = new PerformanceCounter("Objects", "Events");
            float y = p12.NextValue();
            chart8.Series["Events"].Points.AddXY(0, y);
        }

        void WFP()
        {
            PerformanceCounter p13 = new PerformanceCounter();
            p13 = new PerformanceCounter("WFP","Provider Count");
            float y = p13.NextValue();
            chart6.Series["WFP"].Points.AddXY(0, y);
        }
        void WFPv4()
        {
            PerformanceCounter p14 = new PerformanceCounter();
            p14 = new PerformanceCounter("WFPv4", "Outbound Connections");
            float y = p14.NextValue();
            chart12.Series["WFPv4"].Points.AddXY(0, y);
        }


        void WFPv6()
        {
            PerformanceCounter p15 = new PerformanceCounter();
            p15 = new PerformanceCounter("WFPv6", "Inbound Connections");
            float y = p15.NextValue();
            chart13.Series["WFPv6"].Points.AddXY(0, y);
        }

        void TerminalServices()
        {
            PerformanceCounter p16 = new PerformanceCounter();
            p16 = new PerformanceCounter("Terminal Services", "Total Sessions");
            float y = p16.NextValue();
            chart11.Series["TerminalService"].Points.AddXY(0, y);
        }

        void Wifi()
        {
            PerformanceCounter p16 = new PerformanceCounter();
            p16 = new PerformanceCounter("Network Adapter", "Current Bandwidth", "Realtek RTL8723BS Wireless LAN 802.11n SDIO Network Adapter");
            float y = p16.NextValue();
            chart17.Series["Wifi"].Points.AddXY(0, y);
        }

        void NetworkInterface()
        {
            PerformanceCounter p17 = new PerformanceCounter();
            p17 = new PerformanceCounter("Network Interface", "Bytes Total/sec", "Realtek RTL8723BS Wireless LAN 802.11n SDIO Network Adapter");
            float y = p17.NextValue();
            chart14.Series["NetworkInterface"].Points.AddXY(0, y);
        }


        void PagingFile()
        {
            PerformanceCounter p18 = new PerformanceCounter();
            p18 = new PerformanceCounter("Paging File", "% Usage","_Total");
            float y = p18.NextValue();
            chart15.Series["PagingFile"].Points.AddXY(0, y);
        }

       void UDPv4()
        {
            PerformanceCounter p19 = new PerformanceCounter();
            p19 = new PerformanceCounter("UDPv4", "Datagrams Sent/sec");
            float y = p19.NextValue();
            chart16.Series["UDPv4"].Points.AddXY(0, y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Memory();
            Processor();
            Thread();
            Cache();
            ProcessTime();
            SystemTime();
            LogicalDisk();
            PhysicalDisk();
            Mutexes();
            Semaphores();
            Threads();
            Eventss();
            WFP();
            WFPv4();
            WFPv6();
            TerminalServices();
            Wifi();
            NetworkInterface();
            PagingFile();
            UDPv4();
     
        }

        public void Info()
        {
            PopulateComboBox();

        }
        private void PopulateComboBox()
        {
            process = Process.GetProcesses();
           comboBox1.Items.Clear();
            foreach (Process proc in process)
            {
                comboBox1.Items.Add(proc.ProcessName);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                int index = comboBox1.SelectedIndex;
                propertyGrid1.SelectedObject = process[index];
                propertyGrid2.SelectedObject = process[index].StartInfo;

            }
        }

        private void KillSelected_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex != -1)
                {
                process[comboBox1.SelectedIndex].Kill();
                getAllProcesses();
                }
            }
            catch
            {
                MessageBox.Show("cannot kill");
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
           PopulateComboBox();
        }

          //*************************Properties*****************//

        public void WMiUse()
        {
           

            ManagementObjectSearcher bus = new ManagementObjectSearcher("select * from Win32_Bus");

            foreach (ManagementObject X in bus.Get())
            {

                String a = X["Name"].ToString();
                String b = X["Caption"].ToString();
                String c = X["DeviceID"].ToString();
                String d = X["SystemName"].ToString();
                String e = X["Description"].ToString();

                dataGridView7.Rows.Add(new object[] { a, b, c, d, e });

            }
            Console.Read();


            ManagementObjectSearcher Ld = new ManagementObjectSearcher("select * from Win32_LogicalDisk ");

            foreach (ManagementObject X in Ld.Get())
            {

                String a = X["Name"].ToString();
                String b = X["Caption"].ToString();
                String c = X["DeviceID"].ToString();
                String d = X["SystemName"].ToString();
                String e = X["Description"].ToString();
                dataGridView8.Rows.Add(new object[] { a, b, c, d, e });

            }
            Console.Read();

            ManagementObjectSearcher des = new ManagementObjectSearcher("select * from Win32_Desktop");

            foreach (ManagementObject X in des.Get())
            {

                String a = X["Name"].ToString();
                String d = X["Pattern"].ToString();
                String c = X["IconTitleFaceName"].ToString();
                dataGridView9.Rows.Add(new object[] { a, d, c });

            }
            Console.Read();

            ManagementObjectSearcher usb = new ManagementObjectSearcher("select * from Win32_USBHub");

            foreach (ManagementObject X in usb.Get())
            {

                String a = X["Name"].ToString();
                String b = X["Caption"].ToString();
                String c = X["DeviceID"].ToString();
                String d = X["Status"].ToString();
                String e = X["SystemName"].ToString();

                dataGridView10.Rows.Add(new object[] { a, b, c, d, e });

            }
            Console.Read();


            ManagementObjectSearcher Sound = new ManagementObjectSearcher("select * from Win32_SoundDevice ");

            foreach (ManagementObject X in Sound.Get())
            {

                String a = X["Name"].ToString();
                String b = X["Caption"].ToString();
                String c = X["DeviceID"].ToString();
                //  String e = X["Description"].ToString();
                String e = X["SystemName"].ToString();
                String d = X["Status"].ToString();

                dataGridView11.Rows.Add(new object[] { a, b, c, d, e});

            }
            Console.Read();

            ManagementObjectSearcher vol = new ManagementObjectSearcher("select * from Win32_Volume");

            foreach (ManagementObject X in vol.Get())
            {

                String a = X["Name"].ToString();
                //  String d = X["DriveName"].ToString();
                String c = X["Caption"].ToString();
                String b = X["DeviceID"].ToString();

                dataGridView12.Rows.Add(new object[] { a, b, c });

            }
            Console.Read();

            ManagementObjectSearcher ri = new ManagementObjectSearcher("select * from Win32_DiskPartition");

            foreach (ManagementObject X in ri.Get())
            {

                String a = X["Name"].ToString();
                String e = X["SystemName"].ToString();
                String b = X["Caption"].ToString();
                String c = X["DeviceID"].ToString();
                String d = X["Type"].ToString();

                dataGridView13.Rows.Add(new object[] { a, b, c, d, e });

            }
            Console.Read();

            String[] ClassName = { "Win32_Fan", "Win32_Refrigeration", "Win32_TemperatureProbe", "Win32_HeatPipe", "Win32_Keyboard", "Win32_PointingDevice", "Win32_DiskDrive" ,"Win32_CDROMDrive", "Win32_TapeDrive",
                                 "Win32_BaseBoard","Win32_Battery","Win32_DesktopMonitor","Win32_VideoController","Win32_POTSModem","Win32_USBController","Win32_USBHub","Win32_SoundDevice","Win32_SerialPort"};
        
            for (int j = 0; j < ClassName.Length; j++)
            {
                Console.Write(ClassName[j] + "------>");

                ManagementObjectSearcher m1 = new ManagementObjectSearcher("Select * from " + ClassName[j]);
                foreach (ManagementObject i in m1.Get())
                {

                    ListViewItem items = new ListViewItem(i["CreationClassName"].ToString());

                    items.SubItems.Add(i["Status"].ToString());
                    items.SubItems.Add(i["Caption"].ToString());
                    items.SubItems.Add(i["Description"].ToString());
                    listView1.Items.Add(items);
                }
            }

          String[] ClassName1 = { "Win32_BIOS" , "Win32_CacheMemory", "Win32_NetworkConnection" ,"Win32_SerialPortConfiguration","Win32_MappedLogicalDisk","Win32_POTSModem",
                                  "Win32_DiskDrive","Win32_Thread","Win32_MotherboardDevice","Win32_SoundDevice","Win32_SCSIController","Win32_BaseBoard","Win32_Fan","Win32_DMAChannel",
                                  "Win32_CDROMDrive","Win32_DesktopMonitor","Win32_TapeDrive","Win32_PointingDevice","Win32_MappedLogicalDisk","Win32_VoltageProbe","Win32_SerialPort", "Win32_InfraredDevice"};
            for (int i = 0; i < ClassName1.Length; i++)
            {
                Console.Write(ClassName1[i] + "----->");
                ManagementObjectSearcher m2 = new ManagementObjectSearcher("Select * from " + ClassName1[i]);

                foreach (ManagementObject k in m2.Get())
                {
                    ListViewItem itemss = new ListViewItem(k["Name"].ToString());

                    itemss.SubItems.Add(k["Status"].ToString());
                    itemss.SubItems.Add(k["Caption"].ToString());
                    itemss.SubItems.Add(k["Description"].ToString());
                    listView2.Items.Add(itemss);
                }
            }

            String[] ClassName2 = { "Win32_SystemSlot", "Win32_Processor","Win32_DeviceMemoryAddress","Win32_SystemMemoryResource"};
            for (int i = 0; i < ClassName2.Length; i++)
            {
                ManagementObjectSearcher m2 = new ManagementObjectSearcher("Select * from " + ClassName2[i]);

                foreach (ManagementObject k in m2.Get())
                {
                    ListViewItem items2 = new ListViewItem(k["Name"].ToString());

                    items2.SubItems.Add(k["Status"].ToString());
                    items2.SubItems.Add(k["Caption"].ToString());
                    items2.SubItems.Add(k["Description"].ToString());
                    listView3.Items.Add(items2);
                }
            }


           /* String[] ClassName3 = { "Win32_ShortcutFile" };
            for (int i = 0; i < ClassName3.Length; i++)
            {
                Console.Write(ClassName3[i] + "----->");
                ManagementObjectSearcher m2 = new ManagementObjectSearcher("Select * from " + ClassName3[i]);
                //   Console.Write(ClassName[j] + "----->");
                foreach (ManagementObject k in m2.Get())
                {
                    ListViewItem items3 = new ListViewItem(k["Name"].ToString());
                    items3.SubItems.Add(k["Status"].ToString());
                    items3.SubItems.Add(k["Caption"].ToString());

                    listView4.Items.Add(items3);
                }
            }
          */


        }


    
    }
}
