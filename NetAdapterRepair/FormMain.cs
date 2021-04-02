using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace NetAdapter
{
    public partial class FormMain : Form
    {
        private string LogFileName;
        private long BytesSent = 0;
        private long BytesReceived = 0;
        private long BytesSentTotal = 0;
        private long BytesReceivedTotal = 0;
        //private long BytesSentTick = 0;
        //private long BytesReceivedTick = 0;
        private bool HostsFileLogged = false;

        public FormMain()
        {
            InitializeComponent();
            LogFileName = "netadapter-log-" + DateTime.Now.ToString("yyyy-MM-dd-H-mm-ss") + ".txt";
            timer1.Enabled = true;
        }

        // Logs the message to the application log area AND to the log file
        private void LogMessage(String msg)
        {
            richTextBoxLogArea.Text += DateTime.Now + ": " + msg + "\n";
            richTextBoxLogArea.SelectionStart = richTextBoxLogArea.Text.Length;
            richTextBoxLogArea.ScrollToCaret();

            LogMessageToFile(msg);

            this.Refresh();
        }

        // Logs the message to the log file ONLY
        private void LogMessageToFile(String msg)
        {
            using (System.IO.StreamWriter LogFile = File.AppendText(LogFileName))
            {
                LogFile.WriteLine(DateTime.Now + ": " + msg);
            }
        }

        // Sets the status message and the progress bar at the bottom
        private void ChangeStatus(String msg, int progress)
        {
            toolStripStatusLabel.Text = msg;
            toolStripProgressBar.Value = progress;
            this.Refresh();
        }

        // Checks if the current logged in user is an Administrator
        public static bool IsAdministrator()
        {
            if (Environment.OSVersion.Version.Major > 5)    // If newer than XP
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            else
            {
                return true;
            }
        }

        // Finds the "friendly" OS name
        private static string GetOSName() {
            string versionString = Environment.OSVersion.VersionString;
            string servicePack = Environment.OSVersion.ServicePack;
            string pa = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            string bits = ((String.IsNullOrEmpty(pa) || String.Compare(pa, 0, "x86", 0, 3, true) == 0) ? " 32-bit " : " 64-bit ");

            var name = (from x in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>()
                        select x.GetPropertyValue("Caption")).First();
            return name != null ? name.ToString() + bits + servicePack : versionString;
        }

        // Creates a .reg file with default IE privacy options, then imports it to the registry
        private void RunIEPrivacyDefaultRegFile()
        {
            string sFileName = "ie_privacy_default.reg";
            string sRegPath = Environment.GetEnvironmentVariable("temp") + "\\" + sFileName;

            // Remove read-only attribute, if set
            try
            {
                FileInfo fileInfo = new FileInfo(sRegPath);
                fileInfo.IsReadOnly = false;
                fileInfo.Refresh();
            } catch (FileNotFoundException) {
            }

            // Create or overwrite .reg file (we could also use a resource file, but this feels safer)
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(sRegPath))
            {
                file.WriteLine("Windows Registry Editor Version 5.00");
                file.WriteLine("");
                file.WriteLine("[HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Zones\\3]");
                file.WriteLine("\"1A10\"=dword:00000001");
                file.WriteLine("\"{AEBA21FA-782A-4A90-978D-B72164C80120}\"=hex:1a,37,61,59,23,52,35,0c,7a,5f,20,\\");
                file.WriteLine("  17,2f,1e,1a,19,0e,2b,01,73,1e,28,1a,04,1b,0c,3b,c2,21,27,53,0d,36,05,2c,05,\\");
                file.WriteLine("  04,3d,4f,3a,4a,44,33,3a,0a,06,12,68,53,7c,20,13,35,5d,4c,10,27,01,56,7a,2d,\\");
                file.WriteLine("  3f,38,4f,79,0f,16,26,75,53,1c,31,00,56,7a,3e,32,24,4f,79,1b,00,33,71,4d,23,\\");
                file.WriteLine("  32,29,7c,6a,35,31,34,40,72,3b,01,2e,5d,4c,2a,07,15,48,72,38,12,00,56,7a,3e,\\");
                file.WriteLine("  16,3c,71,4d,24,33,35,7c,72,35,0e,3c,1a,41,44,19,0f,31,3a,56,7a,2e,3e,31,0c,\\");
                file.WriteLine("  7c,6a,10,27,0c,05,5d,4c,39,19,12,15,61,54,2e,00,33,32,40,52,03,25,1f,05,5d,\\");
                file.WriteLine("  4c,2c,0c,0a,15,61,54,1a,26,1f,05,5d,4c,10,21,1d,1b,71,4d,3b,24,3a,21,6d,72,\\");
                file.WriteLine("  24,16,3c,32,40,72,21,0f,3a,1a,41,44,1b,1e,01,01,71,4d,32,23,30,27,6d,4d,1f,\\");
                file.WriteLine("  28,10,3c,56,7a,2f,2e,32,16,7c,6a,3a,12,3b,28,75,53,0b,3f,12,01,71,4d,23,32,\\");
                file.WriteLine("  29,27,75,53,12,30,32,1e,4f,79,12,38,17,01,71,4d,30,3e,37,27,6d,72,38,12,3f,\\");
                file.WriteLine("  04,41,44,0a,0e,32,28,49,5f,1c,24,0b,1b,36,21,41,7b,5b,24,39,31,7c,6a,2b,0e,\\");
                file.WriteLine("  25,75,53,1a,2e,26,41,72,34,16,26,71,4d,30,30,3a,7c,6a,07,33,1a,56,7a,3a,00,\\");
                file.WriteLine("  33,71,4d,23,32,29,7c,6a,1a,26,1a,40,52,24,3f,1a,6d,4d,1c,22,28,75,53,13,25,\\");
                file.WriteLine("  20,41,44,0a,0e,32,75,53,08,07,20,71,4d,10,27,0d,05,5d,4c,24,1a,1e,1b,71,4d,\\");
                file.WriteLine("  3f,20,3f,21,6d,4d,10,27,0c,05,5d,4c,39,19,12,3a,56,7a,3a,20,2c,0c,7c,6a,3e,\\");
                file.WriteLine("  0c,37,07,75,53,12,30,32,3a,56,7a,25,2d,23,0c,7c,6a,2b,08,21,3a,56,7a,22,3a,\\");
                file.WriteLine("  32,3a,56,72,24,1e,26,1a,41,44,07,1f,03,1b,75,53,1c,31,01,01,71,4d,32,23,30,\\");
                file.WriteLine("  27,6d,72,34,1e,30,04,41,44,1b,1e,3b,28,49,5f,07,33,12,1b,5d,4c,35,0b,0a,1f,\\");
                file.WriteLine("  75,53,0b,00,34,28,40,72,3b,01,2d,04,41,44,01,05,34,28,40,52,22,36,04,34,48,\\");
                file.WriteLine("  72,38,12,3f,04,41,44,0a,0e,1f,01,71,4d,24,33,35,27,06,1c,68,53,49,14,21,01,\\");
                file.WriteLine("  40,52,10,27,0d,40,52,2c,29,05,6d,4d,1f,28,05,56,7a,2f,2e,32,75,53,07,33,12,\\");
                file.WriteLine("  40,52,3f,3a,19,6d,72,20,00,34,71,4d,1a,26,1a,40,52,24,3f,1a,6d,72,35,08,38,\\");
                file.WriteLine("  5d,4c,2d,01,18,48,7a,27,23,1f,56,7a,3b,2f,3f,4f,79,08,39,01,1b,71,72,33,1f,\\");
                file.WriteLine("  39,3a,56,7a,2e,3e,31,0c,7c,72,35,0e,3f,1a,41,44,0a,0a,35,3a,56,7a,3a,20,2c,\\");
                file.WriteLine("  0c,7c,6a,03,25,1f,05,5d,4c,2c,0c,0a,15,61,54,27,05,34,32,40,52,10,21,09,05,\\");
                file.WriteLine("  5d,4c,2d,01,18,15,61,54,07,37,17,05,5d,4c,1c,24,03,1b,71,4d,30,30,3b,27,6d,\\");
                file.WriteLine("  72,33,17,3f,28,40,72,34,1e,30,04,41,44,1b,1e,00,01,71,4d,2f,2c,2c,27,6d,4d,\\");
                file.WriteLine("  0b,26,3f,3c,56,7a,3a,20,23,16,7c,6a,35,05,33,28,75,53,12,30,17,01,71,4d,30,\\");
                file.WriteLine("  3e,37,27,75,53,13,25,20,1e,4f,79,1f,29,1f,01,71,4d,24,33,35,27,06,21,41,7b,\\");
                file.WriteLine("  5b,3d,24,37,7c,6a,2b,0e,25,40,72,33,1f,39,5d,72,34,1e,30,5d,4c,2a,0d,18,48,\\");
                file.WriteLine("  7a,27,12,3b,71,4d,23,32,12,56,72,20,0c,2e,5d,4c,2c,0c,0a,75,53,1a,26,1f,40,\\");
                file.WriteLine("  72,35,08,38,5d,4c,2d,01,18,75,53,0f,21,27,41,44,07,1f,3e,61,54,3d,06,22,32,\\");
                file.WriteLine("  40,52,2c,29,05,32,48,72,34,1e,05,1b,71,4d,10,27,0c,05,5d,4c,39,19,1a,1b,71,\\");
                file.WriteLine("  4d,23,32,24,21,6d,4d,03,25,1f,05,5d,4c,2c,0c,0a,3a,56,7a,25,2d,23,0c,7c,6a,\\");
                file.WriteLine("  2b,08,21,07,75,53,13,25,20,3a,56,7a,3e,3e,3b,0c,7c,6a,3f,0f,23,3a,56,7a,2f,\\");
                file.WriteLine("  2e,3d,3c,56,72,33,1f,39,04,41,44,1a,0e,05,01,75,53,1c,31,00,01,71,4d,2f,2c,\\");
                file.WriteLine("  2c,27,6d,72,20,0c,2d,04,41,44,06,18,2a,28,49,5f,1a,26,1a,1b,5d,4c,2c,0c,0f,\\");
                file.WriteLine("  1f,75,53,1c,1c,3e,28,40,72,38,12,3f,04,41,44,0a,16,3c,28,40,52,3e,39,06,34,\\");
                file.WriteLine("  21,21,41,7b,5b,23,27,3c,7c,6a,17,37,17,40,52,32,24,05,6d,4d,0e,21,2c,75,53,\\");
                file.WriteLine("  0b,31,31,75,53,08,3e,21,41,44,07,1e,3c,61,54,17,37,17,05,5d,4c,00,33,1e,1b,\\");
                file.WriteLine("  71,4d,2e,39,3b,21,6d,72,20,06,32,32,40,72,21,0f,3c,1a,41,44,1a,0e,1f,01,71,\\");
                file.WriteLine("  4d,20,2c,30,27,6d,4d,0e,21,2c,3c,56,7a,3a,2e,2d,16,7c,6a,3f,07,22,28,6e,02,\\");
                file.WriteLine("  68,4a,7c,21,09,26,5d,4c,29,1d,1f,56,7a,3f,32,38,4f,79,1e,30,01,56,7a,3a,2e,\\");
                file.WriteLine("  2d,4f,79,14,07,22,71,4d,24,30,3b,7c,6a,2a,1e,2f,07,75,53,0c,2d,26,3a,56,7a,\\");
                file.WriteLine("  31,25,3d,0c,7c,6a,3e,0e,35,3a,56,7a,3b,2f,3d,3a,56,72,34,1e,26,04,41,44,0b,\\");
                file.WriteLine("  0a,1e,01,75,53,0e,38,01,01,71,4d,23,30,2b,27,6d,72,21,0f,3c,04,28,1b,67,6b,\\");
                file.WriteLine("  5f,00,22,10,75,53,1f,21,27,41,44,0b,0a,31,75,53,0e,1d,22,71,4d,03,27,1d,40,\\");
                file.WriteLine("  52,3e,39,08,75,53,08,31,21,41,44,1a,0e,32,3a,56,7a,3f,32,38,0c,7c,6a,06,3e,\\");
                file.WriteLine("  0d,05,5d,4c,35,0d,09,15,61,54,29,07,22,32,40,52,17,37,17,1b,5d,4c,3a,19,16,\\");
                file.WriteLine("  1f,61,54,06,3e,0d,1b,5d,4c,03,27,11,01,71,4d,24,33,3b,27,06,21,41,73,41,11,\\");
                file.WriteLine("  25,1d,56,7a,2e,3e,3b,4f,79,18,12,3f,71,4d,2e,39,3b,7c,6a,3e,0e,35,40,72,21,\\");
                file.WriteLine("  0f,3c,5d,4c,36,0d,19,48,72,34,1e,1f,1b,71,4d,00,33,16,05,5d,4c,38,04,01,1b,\\");
                file.WriteLine("  71,4d,23,30,2b,21,6d,4d,1c,24,0d,05,5d,4c,29,1d,17,3c,56,7a,3f,32,38,16,7c,\\");
                file.WriteLine("  6a,39,09,25,09,75,53,0b,31,31,3c,56,7a,3b,2f,3d,16,15,39,5f,7b,42,03,38,02,\\");
                file.WriteLine("  40,20,2c,1e,4f,37,41,7b,5b,23,27,3c,7c,14,07,22,6e,14,68,4a,7c,20,13,35,5d,\\");
                file.WriteLine("  30,37,08,06,37,41,7b,5b,23,27,3c,7c,1b,39,1d,30,02,7c,50,68,3a,3b,34,4f,1b,\\");
                file.WriteLine("  1e,3b,6e,14,68,73,41,0b,22,0a,56,12,30,32,28,09,67,73,41,0b,22,2a,41,2c,0c,\\");
                file.WriteLine("  0f,21,37,41,7b,5b,23,27,3c,7c,08,1c,3e,66,0e,44,4f,56,06,13,05,61,27,23,1f,\\");
                file.WriteLine("  4f,3f,5b,53,7c,20,13,35,5d,3e,39,06,06,0a,68,53,7c,21,09,26,5d,32,12,3f,6e,\\");
                file.WriteLine("  14,68,4a,44,3e,37,02,6d,1c,24,01,4f,3f,5b,73,41,08,38,27,41,38,04,19,6e,14,\\");
                file.WriteLine("  68,4a,44,3e,37,02,6d,3e,0e,35,3b,37,41,7b,5b,24,39,31,7c,08,39,00,4f,3f,7c,\\");
                file.WriteLine("  50,68,3b,1d,3c,71,25,2d,2c,20,3a,7c,50,68,3b,25,3b,4f,01,1d,2a,6e,14,68,4a,\\");
                file.WriteLine("  44,3e,37,02,6d,10,21,09,29,1f,5e,45,67,14,30,07,49,12,16,3c,66,0e,44,73,41,\\");
                file.WriteLine("  08,38,27,41,36,0a,1b,21,3f,42,73,41,10,3b,2d,41,00,33,1e,4f,3f,5b,53,5e,2e,\\");
                file.WriteLine("  07,1d,75,21,07,22,66,0e,7c,50,68,23,24,31,4f,0d,15,01,4f,3f,5b,53,5e,2e,07,\\");
                file.WriteLine("  1d,48,0b,18,3c,6e,14,68,4a,44,26,36,0c,6d,2b,06,25,66,37,41,7b,5b,14,21,01,\\");
                file.WriteLine("  40,3a,31,24,15,37,41,7b,5b,3c,3e,3f,7c,12,38,17,4f,3f,5b,53,5e,2e,07,1d,75,\\");
                file.WriteLine("  35,08,38,36,03,56,76,74,37,08,19,40,07,37,17,29,1f,7c,50,68,23,24,31,4f,07,\\");
                file.WriteLine("  1f,3e,16,17,7c,50,68,20,3a,39,75,25,12,3f,66,0e,44,4f,56,1c,12,1d,56,1c,24,\\");
                file.WriteLine("  0d,29,37,41,7b,5b,3d,24,37,7c,1e,1d,22,66,0e,44,4f,56,1c,12,30,61,23,13,11,\\");
                file.WriteLine("  4f,3f,5b,53,5e,2f,01,15,48,10,27,0c,6e,14,68,4a,7c,36,12,38,5d,24,3f,19,6e,\\");
                file.WriteLine("  14,68,4a,44,21,2c,04,6d,35,05,34,66,0e,44,4f,56,1c,12,1d,56,1c,3b,25,28,09,\\");
                file.WriteLine("  67,6b,5f,01,2c,28,75,24,1e,26,36,37,41,7b,5b,3d,24,37,7c,14,3a,0b,30,37,41,\\");
                file.WriteLine("  7b,5b,36,0c,7c");
                file.WriteLine("\"{A8A88C49-5EB2-4990-A1A2-0876022C854F}\"=hex:1a,37,61,59,23,52,35,0c,7a,5f,20,\\");
                file.WriteLine("  17,2f,1e,1a,19,0e,2b,01,73,1e,28,1a,04,1b,0c,3b,c2,21,2d,53,49,07,25,0f,29,\\");
                file.WriteLine("  01,7c,50,68,3a,3b,34,4f,79,08,39,0d,49,72,33,1f,39,5d,4c,17,37,05,56,7a,2f,\\");
                file.WriteLine("  2e,32,4f,79,1f,12,3b,75,53,0b,3f,12,56,7a,3a,20,23,4f,79,12,05,33,71,4d,3a,\\");
                file.WriteLine("  31,29,7c,6a,2b,08,21,40,72,38,12,3f,5d,4c,39,1d,17,48,72,21,0f,03,56,7a,2f,\\");
                file.WriteLine("  06,22,32,40,52,2c,29,05,3a,56,7a,2e,3e,31,0c,7c,6a,2b,06,25,32,40,52,33,24,\\");
                file.WriteLine("  01,32,75,53,0b,3f,32,04,4f,79,1b,3b,1f,0c,40,72,3b,01,2d,1a,75,53,12,30,3f,\\");
                file.WriteLine("  04,4f,79,08,3f,09,0c,75,53,13,25,20,04,75,53,07,37,17,05,5d,4c,36,0a,1b,3a,\\");
                file.WriteLine("  56,72,35,0e,3c,3c,56,7a,2d,3f,38,16,7c,6a,17,37,01,1b,5d,4c,2a,0d,18,1f,61,\\");
                file.WriteLine("  54,12,12,3b,28,40,52,3f,3a,19,34,48,72,20,0c,17,01,71,4d,1a,26,1a,1b,5d,4c,\\");
                file.WriteLine("  2c,0c,17,01,71,4d,30,3e,37,27,6d,4d,1b,3b,0c,1b,5d,4c,39,1d,17,3c,56,7a,3b,\\");
                file.WriteLine("  2f,3f,16,15,39,5f,7b,42,29,1d,3c,71,4d,30,06,22,71,4d,32,23,30,7c,6a,2a,1e,\\");
                file.WriteLine("  19,75,53,1c,31,20,41,72,24,12,3b,71,4d,23,32,24,7c,6a,03,25,17,56,7a,25,05,\\");
                file.WriteLine("  33,71,4d,3a,31,29,7c,6a,10,21,09,40,52,27,2c,0b,6d,4d,0f,28,2a,75,53,08,3e,\\");
                file.WriteLine("  23,41,44,1b,1e,3c,3a,56,7a,12,34,16,05,75,53,1f,21,2d,04,4f,79,10,27,0c,05,\\");
                file.WriteLine("  5d,4c,39,19,12,15,75,53,0b,3f,32,04,4f,79,1b,00,34,32,40,52,24,3f,19,32,48,\\");
                file.WriteLine("  7a,2c,10,17,1b,71,4d,30,1c,3e,32,40,52,27,2c,0b,32,48,7a,27,16,3c,32,40,52,\\");
                file.WriteLine("  3e,07,20,3a,56,7a,2f,2e,3d,16,7c,6a,12,34,1e,01,71,4d,17,37,01,1b,5d,4c,2a,\\");
                file.WriteLine("  0d,18,3c,56,7a,3e,32,24,16,7c,6a,3e,0c,34,09,75,53,0b,3f,3f,1e,4f,79,12,38,\\");
                file.WriteLine("  12,01,71,72,3b,01,2e,3c,56,7a,2f,24,39,16,7c,72,38,12,3f,04,41,44,0a,0e,32,\\");
                file.WriteLine("  3c,56,7a,3b,2f,3f,16,15,39,7c,50,68,23,24,31,4f,79,08,39,0d,49,5f,12,34,16,\\");
                file.WriteLine("  40,52,17,37,01,40,52,22,38,0b,6d,4d,0f,34,1a,56,7a,3a,20,2c,75,53,03,25,1f,\\");
                file.WriteLine("  40,52,24,3f,19,6d,72,3b,05,34,71,4d,10,21,09,40,52,27,2c,0b,6d,72,24,1e,26,\\");
                file.WriteLine("  5d,4c,36,0a,1b,48,7a,36,13,01,1b,71,4d,32,23,30,21,6d,4d,17,37,01,3a,56,7a,\\");
                file.WriteLine("  2f,06,25,32,40,52,33,24,01,3a,56,7a,3a,20,2c,0c,7c,6a,3e,00,34,32,40,52,24,\\");
                file.WriteLine("  3f,19,32,75,53,12,30,3f,04,4f,79,08,3f,09,0c,40,72,38,12,3f,1a,75,53,0f,21,\\");
                file.WriteLine("  27,04,4f,79,14,3a,0b,0c,75,53,1c,31,21,1e,75,53,12,34,16,1b,5d,4c,29,1d,1d,\\");
                file.WriteLine("  3c,56,72,35,0e,3f,3c,56,7a,3e,32,24,16,7c,6a,03,25,1a,1b,5d,4c,35,0b,0f,1f,\\");
                file.WriteLine("  61,54,27,05,33,28,40,52,24,3f,1a,34,48,72,35,08,1d,01,71,4d,1b,3b,0c,1b,5d,\\");
                file.WriteLine("  4c,39,1d,1f,01,71,4d,24,33,35,27,06,1c,7c,50,68,20,3a,39,4f,79,08,06,22,71,\\");
                file.WriteLine("  4d,32,23,30,7c,6a,2a,1e,19,40,72,35,0e,3f,5d,72,24,1a,25,5d,4c,35,0b,0a,48,\\");
                file.WriteLine("  7a,23,00,34,71,4d,3a,31,12,56,72,3b,01,2e,5d,4c,2a,07,15,75,53,1b,3b,0c,40,\\");
                file.WriteLine("  72,24,1e,26,5d,4c,36,0a,1b,75,53,1c,31,21,04,4f,79,0a,2a,06,0c,40,72,34,1e,\\");
                file.WriteLine("  30,1a,41,44,1b,1e,3b,3a,56,7a,07,33,12,05,75,53,0b,3f,32,04,4f,79,03,25,1f,\\");
                file.WriteLine("  05,5d,4c,2c,0c,0a,15,75,53,12,30,3f,04,4f,79,08,1c,3e,32,40,52,27,2c,0b,32,\\");
                file.WriteLine("  48,7a,27,23,1f,1b,71,4d,24,07,20,32,40,52,22,38,08,34,48,7a,34,17,3f,28,40,\\");
                file.WriteLine("  52,23,16,26,3c,56,7a,2f,2e,32,16,7c,6a,07,33,1a,01,71,4d,03,25,1a,1b,5d,4c,\\");
                file.WriteLine("  35,0b,0f,3c,56,7a,25,2d,2c,16,7c,6a,35,31,37,09,75,53,1c,3b,25,1e,4f,79,13,\\");
                file.WriteLine("  35,00,01,71,72,24,1e,26,3c,56,7a,3b,2f,3f,16,15,21,41,7b,5b,23,27,3c,7c,6a,\\");
                file.WriteLine("  2a,16,3c,71,4d,20,2c,30,7c,6a,06,3e,0d,40,52,3f,38,18,6d,4d,08,27,2c,75,53,\\");
                file.WriteLine("  08,31,21,75,53,1f,21,27,04,4f,79,18,2d,06,0c,75,53,0e,38,21,04,75,53,03,27,\\");
                file.WriteLine("  1d,05,5d,4c,36,0a,19,3a,56,72,34,1e,26,3c,56,7a,3f,32,38,16,7c,6a,06,3e,0d,\\");
                file.WriteLine("  1b,5d,4c,35,0d,09,1f,61,54,29,07,22,28,29,01,5e,45,67,14,30,1f,56,7a,17,37,\\");
                file.WriteLine("  17,40,72,25,1a,39,5d,4c,38,04,01,56,7a,3a,2e,2d,4f,79,14,3a,01,56,7a,3b,2e,\\");
                file.WriteLine("  3d,4f,79,0f,16,3c,32,40,52,32,24,05,32,48,7a,18,28,01,1b,71,4d,23,06,32,32,\\");
                file.WriteLine("  40,52,3e,39,08,32,48,7a,37,16,3c,28,40,52,32,12,3f,3c,56,7a,31,25,3d,16,7c,\\");
                file.WriteLine("  6a,03,27,11,01,71,4d,1c,24,0d,1b,36,1d,56,76,74,14,21,01,40,52,23,28,02,6d,\\");
                file.WriteLine("  4d,0c,34,2b,75,53,0e,38,21,41,44,06,1e,2c,75,53,08,07,22,71,4d,1c,27,0d,40,\\");
                file.WriteLine("  52,23,28,02,3a,56,7a,3f,32,38,0c,7c,6a,39,1d,22,32,40,52,3f,38,18,32,75,53,\\");
                file.WriteLine("  08,3e,21,04,4f,79,0f,29,07,02,40,72,25,1a,39,04,75,53,0e,38,21,1e,4f,79,1b,\\");
                file.WriteLine("  39,1d,02,75,53,08,3e,21,1e,6e,02,7c,50,68,20,3a,39,4f,79,0f,16,3c,75,53,0c,\\");
                file.WriteLine("  2d,1e,56,7a,31,25,3d,4f,79,1b,06,32,71,4d,24,33,3b,7c,6a,3f,0e,25,40,72,34,\\");
                file.WriteLine("  1e,26,1a,41,44,0b,0a,31,3a,56,7a,06,3e,0d,05,75,53,0b,31,31,04,4f,79,1c,24,\\");
                file.WriteLine("  0d,05,5d,4c,29,1d,17,1f,75,53,0c,2d,26,1e,4f,79,1e,1d,22,28,40,52,3f,38,18,\\");
                file.WriteLine("  34,48,7a,22,12,01,01,66,1c,44,73,41,0b,22,2a,41,3a,19,16,21,2d,42,73,41,0b,\\");
                file.WriteLine("  22,2a,41,1c,24,01,4f,2d,5b,53,5e,35,1e,22,75,27,1d,22,66,1c,7c,50,68,3a,3b,\\");
                file.WriteLine("  34,4f,06,1e,11,4f,2d,5b,53,5e,35,1e,22,48,1c,18,2d,6e,02,68,4a,44,3f,2d,31,\\");
                file.WriteLine("  6d,35,05,33,66,21,41,7b,5b,03,38,02,40,3a,31,29,15,21,41,7b,5b,23,27,3c,7c,\\");
                file.WriteLine("  08,3f,1d,4f,2d,5b,53,5e,35,1e,22,75,24,1e,26,36,1d,56,76,74,3e,03,1c,40,1c,\\");
                file.WriteLine("  24,0b,29,01,7c,50,68,3b,25,3b,4f,0b,0a,31,16,05,7c,50,68,3b,25,3b,75,21,07,\\");
                file.WriteLine("  22,66,1c,44,4f,56,07,15,1f,56,06,3e,0d,29,21,41,7b,5b,24,39,31,7c,1b,06,32,\\");
                file.WriteLine("  66,1c,44,4f,56,07,15,32,61,36,13,00,4f,2d,5b,53,5e,36,04,17,48,1a,26,1a,6e,\\");
                file.WriteLine("  02,68,4a,7c,21,09,26,5d,24,3f,1a,6e,02,68,4a,44,3e,37,02,6d,2b,1c,3e,66,1c,\\");
                file.WriteLine("  44,4f,56,07,15,1f,56,0f,21,27,28,1b,67,6b,5f,08,21,2a,75,21,0f,3a,36,21,41,\\");
                file.WriteLine("  7b,5b,3c,3e,3f,7c,18,2d,06,30,21,41,7b,5b,3c,3e,05,56,1c,24,0d,29,01,5e,45,\\");
                file.WriteLine("  67,0c,1c,26,75,27,09,3c,6e,02,68,4a,44,26,36,0c,6d,03,27,1d,29,01,5e,45,67,\\");
                file.WriteLine("  0c,3f,31,49,3d,06,25,66,1c,44,4f,56,1f,14,38,75,3b,01,12,4f,2d,5b,73,41,10,\\");
                file.WriteLine("  3b,2d,41,2c,0c,17,4f,2d,5b,53,5e,2e,07,1d,48,10,21,09,29,01,5e,45,67,0c,1c,\\");
                file.WriteLine("  26,71,3e,3e,3b,20,28,74,4e,68,2a,29,05,56,08,3e,23,6e,02,68,4a,44,21,2c,04,\\");
                file.WriteLine("  6d,3b,1a,20,6e,02,68,4a,44,21,1a,3e,75,21,0f,3c,36,1d,56,76,74,15,3b,1d,56,\\");
                file.WriteLine("  0e,38,01,4f,2d,5b,53,5e,2f,01,15,75,20,0e,2c,36,1d,56,76,74,28,02,21,40,10,\\");
                file.WriteLine("  27,0c,29,01,5e,45,67,0d,35,1d,56,12,05,33,66,1c,7c,50,68,20,3a,39,4f,01,05,\\");
                file.WriteLine("  34,66,1c,44,4f,56,1c,12,30,75,35,08,38,36,1d,56,76,74,15,3b,09,40,2f,20,31,\\");
                file.WriteLine("  15,39,5f,7b,42,20,1a,3e,71,3b,2f,03,4f,2d,5b,53,5e,20,39,74");
            }

            String result = RunCommand("regedit.exe", "/s " + sRegPath);
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred importing .reg file:");
                LogMessage(result);
            };

        }

        // Get all RAS (dial-up, VPN) names from Internet Options
        private string[] GetRasNames()
        {
            string sPBKPath = Environment.GetEnvironmentVariable("userprofile") + "\\AppData\\Roaming\\Microsoft\\Network\\Connections\\Pbk\\rasphone.pbk";
            List<string> list = new List<string>();
            if (File.Exists(sPBKPath))
            {
                using (StreamReader sr = File.OpenText(sPBKPath))
                {
                    String input;
                    while ((input = sr.ReadLine()) != null)
                    {
                        if (input.StartsWith("[") && input.EndsWith("]"))
                        {
                            list.Add(input.Substring(1, input.Length - 2));
                        }
                    }
                }
            }
            return list.ToArray();
        }

        // Runs a shell command with given command line arguments
        private string RunCommand(String cmd, String args)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            p.StartInfo.FileName = cmd;
            p.StartInfo.Arguments = args;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }

        // Returns all network adapter names
        private string[] GetAllAdapterNames()
        {
            string[] results = RunCommand("netsh.exe", "interface show interface").Split('\n');

            string[] names = new string[results.Count() - 5];
            for (int i = 3; i < results.Count() - 2; i++)
            {
                names[i - 3] = results[i].Substring(47, results[i].Length - 48);
            }

            return names;
        }

        // Returns the NIC object for a given adapter name
        private NetworkInterface GetNic(string strAdapterName)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface nic in nics)
            {
                if (nic.Name.Equals(strAdapterName))
                {
                    return nic;
                }
            }
            return null;
        }

        // Returns the NIC object bound to a given IP address
        private NetworkInterface GetNicForIP(string strTargetIP) {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface nic in nics)
            {
                IPInterfaceProperties ipProperties = nic.GetIPProperties();
                if (ipProperties != null)
                {
                    foreach (UnicastIPAddressInformation ip in ipProperties.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            if (ip.Address.ToString().Equals(strTargetIP))
                            {
                                return nic;
                            }
                        }
                    }
                }
            }
            return null;
        }

        // Gets the public IP address using an external server (checkip.dyndns.org)
        public string GetPublicIP()
        {
            string strPublicIP = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://checkip.dyndns.com/");
                request.Timeout = 5000;
                request.UserAgent = "Mozilla/5.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/5.0)";
                using (WebResponse response = request.GetResponse())
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    strPublicIP = stream.ReadToEnd();
                }

                //Search for the ip in the html
                int first = strPublicIP.IndexOf("Address: ") + 9;
                int last = strPublicIP.LastIndexOf("</body>");
                strPublicIP = strPublicIP.Substring(first, last - first);

                return strPublicIP;
            }
            catch (WebException e) {
                Console.WriteLine(e.StackTrace);
                return "Error (No Internet connection?)";
            }
        }


        private Shell32.Folder GetShell32NameSpaceFolder(Object folder)
        {
            Type shellAppType = Type.GetTypeFromProgID("Shell.Application");

            Object shell = Activator.CreateInstance(shellAppType);
            return (Shell32.Folder)shellAppType.InvokeMember("NameSpace",
            System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { folder });
        } 


        private bool SetNicStatus(string nicName, bool status)
        {
            const string verbDisable = "Disa&ble";
            const string verbEnable = "En&able";

            string sVerb = null;

            if (status)
            {
                sVerb = verbEnable;
            }
            else
            {
                sVerb = verbDisable;
            }

            Type ShellAppType = Type.GetTypeFromProgID("Shell.Application");
            Object sh = Activator.CreateInstance(ShellAppType);
            Shell32.Folder folder = GetShell32NameSpaceFolder(Shell32.ShellSpecialFolderConstants.ssfCONTROLS);

            try
            {
                foreach (Shell32.FolderItem myItem in folder.Items())
                {
                    if (myItem.Name == "Network Connections")
                    {
                        Shell32.Folder fd = (Shell32.Folder)myItem.GetFolder;
                        foreach (Shell32.FolderItem fi in fd.Items())
                        {
                            if ((fi.Name == nicName))
                            {
                                foreach (Shell32.FolderItemVerb Fib in fi.Verbs())
                                {
                                    if (Fib.Name == sVerb)
                                    {
                                        Fib.DoIt();
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }   

        private void RefreshAdapterInfo(string strAdapterName)
        {
            if (strAdapterName.Equals("")) return;

            LogMessage("Getting information for '" + strAdapterName + "'");
            ChangeStatus("Getting information for '" + strAdapterName + "'", 50);

            NetworkInterface nic = GetNic(strAdapterName);
            if (nic != null)
            {
                IPInterfaceProperties ipProperties = nic.GetIPProperties();
                if (ipProperties != null)
                {
                    try
                    {
                        textBoxLocalIP.Text = string.Join(", ", ipProperties.UnicastAddresses.Select(x => x.Address.ToString()).Where(x => !x.Contains(':')).OrderBy(x => x.Length));
                    }
                    catch (NullReferenceException) { }
                    try
                    {
                        textBoxSubnet.Text = string.Join(", ", ipProperties.UnicastAddresses.Select(x => x.IPv4Mask.ToString()).Where(x => !x.Equals("0.0.0.0")));
                    }
                    catch (NullReferenceException) { }
                    try
                    {
                        textBoxDefaultGW.Text = string.Join(", ", ipProperties.GatewayAddresses.Select(x => x.Address.ToString()).Where(x => !x.Equals("0.0.0.0")));
                    }
                    catch (NullReferenceException) { }
                    try
                    {
                        textBoxDNS.Text = string.Join(", ", ipProperties.DnsAddresses.Select(x => x.ToString()).Where(x => !x.Equals("0.0.0.0")));
                    }
                    catch (NullReferenceException) { }
                    try
                    {
                        textBoxDHCP.Text = string.Join(", ", ipProperties.DhcpServerAddresses.Select(x => x.ToString()).Where(x => !x.Equals("0.0.0.0")));
                    }
                    catch (NullReferenceException) { }
                }
                textBoxMac.Text = string.Join(":", (from z in nic.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());
            }

            ChangeStatus("Ready", 0);
        }

        private void RefreshNetworkInfo(bool isPublicIP)
        {
            LogMessage("Getting network information");
            ChangeStatus("Getting network information", 50);

            NetworkInterface nicDefault = FindDefaultNic();

            if (isPublicIP)
            {
                #if !DEBUG
                textBoxPublicIP.Text = GetPublicIP();
                #endif
            }
            textBoxHostname.Text = System.Net.Dns.GetHostName();

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            comboBoxAdapters.Items.Clear();
            foreach (NetworkInterface adapter in adapters)
            {
                comboBoxAdapters.Items.Add(adapter.Name);
                if (adapter.Name.Equals(nicDefault.Name))
                {
                    comboBoxAdapters.SelectedIndex = comboBoxAdapters.Items.IndexOf(adapter.Name);
                }
            }

            LogMessage("Network information updated");
            ChangeStatus("Ready", 0);
        }

        private NetworkInterface FindDefaultNic()
        {
            IPAddress[] ipList = Array.FindAll(Dns.GetHostEntry(String.Empty).AddressList,
                                               a => a.AddressFamily == AddressFamily.InterNetwork);
            foreach (IPAddress ip in ipList)
            {
                textBoxLocalIP.Text = ip.ToString();
            }

            String strDefaultLocalIP = ipList[ipList.Length - 1].ToString();
            NetworkInterface nicDefault = GetNicForIP(strDefaultLocalIP);

            // If adapter looks like a virtual one, try finding a more suitable one
            string nicDesc = nicDefault.Description.ToLower();
            if (nicDesc.Contains("virtual") || nicDesc.Contains("vm") || nicDesc.Contains("tap")) 
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                comboBoxAdapters.Items.Clear();
                foreach (NetworkInterface adapter in adapters)
                {
                    string adapterName = adapter.Name;
                    IPInterfaceProperties ipProperties = adapter.GetIPProperties();
                    if (ipProperties != null)
                    {
                        bool hasGateway = false;
                        try
                        {
                            string gw = string.Join(", ", ipProperties.GatewayAddresses.Select(x => x.Address.ToString()).Where(x => !x.Equals("0.0.0.0")));
                            hasGateway = (gw.Length > 3);
                        }
                        catch (NullReferenceException) { }
                        if (hasGateway) {
                            string adapterDesc = adapter.Description.ToLower();
                            if (!adapterDesc.Contains("virtual") && !adapterDesc.Contains("vm") && !adapterDesc.Contains("tap"))
                            {
                                return adapter;
                            }
                        }
                    }
                }
            }

            return nicDefault;
        }

        private void buttonRepair_Click(object sender, EventArgs e)
        {
            DialogResult dlg;
            dlg = MessageBox.Show("You are about to run the following:\n"
                                + "\n"
                                + "1. WinSock/TCP IP Repair\n"
                                + "2. Clear all Proxy/VPN Settings\n"
                                + "3. Windows Firewall Repair\n"
                                + "\n"
                                + "Note: Restart required to complete repair\n"
                                + "\n"
                                + "Do you want to continue?",
                                  "Information",
                                  MessageBoxButtons.OKCancel,
                                  MessageBoxIcon.Question);

            // Quit if the user clicks Cancel
            if (dlg == DialogResult.Cancel) return;

            String result;

            // STEP 1: Reset TCP/IP and WinSock using NETSH commands
            LogMessage("Resetting TCP/IP");
            ChangeStatus("Resetting TCP/IP", 25);

            result = RunCommand("ipconfig", "/flushdns");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred flushing DNS cache");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int reset all");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting TCP/IP");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int ipv4 reset");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting TCP/IP");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int ipv6 reset");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting TCP/IP");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int ip reset c:\\resetlog.txt");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting TCP/IP");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int ip reset");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting TCP/IP");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int 6to4 reset all");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting TCP/IP (6to4)");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int httpstunnel reset all");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting HTTPSTunnel");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int isatap reset all");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting ISATAP");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int tcp reset all");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting TCP/IP");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int teredo reset all");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting Teredo");
                LogMessage(result);
            };

            result = RunCommand("netsh", "int portproxy reset all");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting PortProxy");
                LogMessage(result);
            };

            result = RunCommand("netsh", "branchcache reset");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting BranchCache");
                LogMessage(result);
            };


            result = RunCommand("netsh", "winhttp reset");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting WinHTTP");
                LogMessage(result);
            };


            result = RunCommand("netsh", "winsock reset c:\\winsock.log");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting WinSock");
                LogMessage(result);
            };


            result = RunCommand("netsh", "winsock reset");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting WinSock");
                LogMessage(result);
            };


            result = RunCommand("netsh", "winsock reset all");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting WinSock");
                LogMessage(result);
            };


            result = RunCommand("netsh", "winsock reset catalog");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting WinSock");
                LogMessage(result);
            };

            LogMessage("Reset TCP/IP");


            // STEP 2: Clear all Internet Explorer proxy settings by modifying registry
            // See support.microsoft.com/kb/2289942 for details
            LogMessage("Clearing Internet Explorer proxy/VPN settings");
            ChangeStatus("Clearing Internet Explorer proxy/VPN settings", 50);

            // Uncheck "Use a proxy server for LAN" setting
            result = RunCommand("reg", "add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v ProxyEnable /t REG_DWORD /d 0 /f");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred disabling proxy settings.");
                LogMessage(result);
            };
            LogMessage("Disabled proxy settings.");

            // Delete any proxy servers
            result = RunCommand("reg", "delete \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v ProxyServer /f");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred deleting proxy server");
                LogMessage(result);
            };
            LogMessage("Deleted proxy servers");

            // Uncheck "always dial my default connection" and set to "never dial a connection"
            result = RunCommand("reg", "add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v EnableAutodial /t REG_DWORD /d 0 /f");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred disabling automatic dialing.");
                LogMessage(result);
            };
            LogMessage("Disabled automatic dialing.");

            // Delete all RAS connections
            string[] sRasList = GetRasNames();
            foreach (var ras in sRasList)
            {
                result = RunCommand("rasphone.exe", "-r \"" + ras + "\"");
                if (result.ToLower().Contains("error "))
                {
                    LogMessage("An error occurred deleting RAS connection \"" + ras + "\"");
                    LogMessage(result);
                };
            }
            LogMessage("Deleted all RAS connections");

            // Uncheck "Use automatic configuration script"
            result = RunCommand("reg", "delete \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /f");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred deleting automatic configuration settings");
                LogMessage(result);
            };
            LogMessage("Deleted automatic configuration settings");


            // STEP 3: Repair Windows Firewall service
            LogMessage("Repairing Windows Firewall service");
            ChangeStatus("Repairing Windows Firewall service", 75);
            string sINFPath = Environment.GetEnvironmentVariable("windir") + "\\inf\\netrass.inf";
            result = RunCommand("Rundll32.exe", "setupapi,InstallHinfSection Ndi-Steelhead 132 " + sINFPath);
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred registering Windows Firewall. Check log for details");
                LogMessage(result);
            };


            LogMessage("Resetting Windows Firewall service");
            ChangeStatus("Resetting Windows Firewall service", 80);
            result = RunCommand("netsh.exe", "firewall reset");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting Windows Firewall settings");
                LogMessage(result);
            };

            ChangeStatus("Resetting Windows Firewall service", 90);
            result = RunCommand("netsh.exe", "advfirewall reset");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred resetting Windows Firewall settings");
                LogMessage(result);
            };

            LogMessage("Repaired Windows Firewall service");

            // Ask for restart confirmation
            FormRestartConfirmation dlgRestart = new FormRestartConfirmation(60);
            dlgRestart.ShowDialog();
            if (dlgRestart.ButtonPressed == 1)
            {
                LogMessage("Restarting the computer");
                ChangeStatus("Restarting the computer...", 100);
                RunCommand("cmd.exe", "/C shutdown /r /t 5");
            }
            else
            {
                MessageBox.Show("You should restart your computer manually.");
                LogMessage("Restart canceled by user");
            }
        }


        // Release and Renew using IPCONFIG command line tool. Log errors to log file, if any.
        private void buttonRenewDHCP_Click(object sender, EventArgs e)
        {
            DoRenewDHCP();
        }

        private void DoRenewDHCP()
        {
            LogMessage("Releasing IP addresses");
            ChangeStatus("Releasing IP addresses", 50);
            String result;

            result = RunCommand("ipconfig.exe", " /release");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred releasing IP addresses");
                LogMessage(result);
            };

            LogMessage("Renewing IP addresses");
            ChangeStatus("Renewing IP addresses", 90);
            result = RunCommand("ipconfig.exe", " /renew");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred renewing IP addresses");
                LogMessage(result);
            };

            LogMessage("Released and renewed all adapters");
            ChangeStatus("Ready", 0);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshNetworkInfo(true);
        }


        // Flush and Re-register DNS Cache using IPCONFIG command line tool. Log errors to log file, if any.
        private void buttonFlushDNS_Click(object sender, EventArgs e)
        {
            DoFlushDNS();
        }

        private void DoFlushDNS()
        {
            LogMessage("Flushing DNS cache");
            ChangeStatus("Flushing DNS cache", 50);
            String result;

            result = RunCommand("ipconfig.exe", " /flushdns");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred flushing DNS cache");
                LogMessage(result);
            };

            LogMessage("Re-registering DNS names");
            ChangeStatus("Re-registering DNS names", 90);
            result = RunCommand("ipconfig.exe", " /registerdns");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred registering DNS names");
                LogMessage(result);
            };

            LogMessage("Flushed DNS cache and re-registered DNS names");
            ChangeStatus("Ready", 0);
        }


        // Clear ARP cache using ARP command line tool. Log errors to log file, if any.
        private void buttonClearARP_Click(object sender, EventArgs e)
        {
            DoClearARP();
        }

        private void DoClearARP()
        {
            LogMessage("Clearing ARP cache");
            ChangeStatus("Clearing ARP cache", 50);
            String result;

            // Step 1
            result = RunCommand("netsh", "interface ip delete arpcache");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred deleting ARP cache");
                LogMessage(result);
            };

            LogMessage("Cleared ARP Table cache");
            ChangeStatus("Cleared ARP Table cache", 70);

            // Step 2
            result = RunCommand("netsh", "interface ipv4 delete destinationcache");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred deleting IPv4 DestinationCache");
                LogMessage(result);
            };

            result = RunCommand("netsh", "interface ipv6 delete destinationcache");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred deleting IPv6 DestinationCache");
                LogMessage(result);
            };

            result = RunCommand("netsh", "interface ipv4 delete neighbors");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred deleting IPv4 neighbors");
                LogMessage(result);
            };

            result = RunCommand("netsh", "interface ipv6 delete neighbors");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred deleting IPv6 neighbors");
                LogMessage(result);
            };

            LogMessage("Route tables cleared");
            ChangeStatus("Route tables cleared", 90);

            LogMessage("Clearing the routing tables of all gateway entries");
            result = RunCommand("route.exe", " -f");
            if (result.ToLower().Contains("failed"))
            {
                LogMessage("An error occurred clearing routing tables");
                LogMessage(result);
            };

            LogMessage("Cleared ARP cache, routing tables and IP configuration");

            // Ask for restart confirmation
            FormRestartConfirmation dlgRestart = new FormRestartConfirmation(60);
            dlgRestart.ShowDialog();
            if (dlgRestart.ButtonPressed == 1)
            {
                LogMessage("Restarting the computer");
                ChangeStatus("Restarting the computer...", 100);
                RunCommand("cmd.exe", "/C shutdown /r /t 5");
            }
            else
            {
                MessageBox.Show("You should restart your computer manually.");
                LogMessage("Restart canceled by user");
            }
            
            ChangeStatus("Ready", 0);
        }


        // This procedure is removed per CB's request
        private void DoClearARP_OLD()
        {
            LogMessage("Clearing ARP cache");
            ChangeStatus("Clearing ARP cache", 50);
            String result;

            result = RunCommand("arp.exe", " -d *");
            if (result.ToLower().Contains("could not finish repairing "))
            {
                LogMessage("An error occurred clearing ARP cache");
                LogMessage(result);
            };

            LogMessage("Clearing the routing tables of all gateway entries");
            result = RunCommand("route.exe", " -f");
            if (result.ToLower().Contains("failed"))
            {
                LogMessage("An error occurred clearing routing tables");
                LogMessage(result);
            };

            LogMessage("Releasing and renewing the IP configuration");
            result = RunCommand("ipconfig.exe", " /release");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred releasing IP addresses");
                LogMessage(result);
            };

            result = RunCommand("ipconfig.exe", " /renew");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred renewing IP addresses");
                LogMessage(result);
            };

            LogMessage("Cleared ARP cache, routing tables and IP configuration");
            ChangeStatus("Ready", 0);
        }


        private void buttonReloadNETBIOS_Click(object sender, EventArgs e)
        {
            DoReloadNETBIOS();
        }

        private void DoReloadNETBIOS()
        {
            LogMessage("Reloading NetBIOS");
            ChangeStatus("Reloading NetBIOS", 50);
            String result;

            result = RunCommand("nbtstat.exe", "-R");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred reloading NetBIOS");
                LogMessage(result);
            };

            LogMessage("Releasing NetBIOS");
            ChangeStatus("Releasing NetBIOS", 90);
            result = RunCommand("nbtstat.exe", "-RR");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred releasing NetBIOS");
                LogMessage(result);
            };

            LogMessage("Reloaded and released NetBIOS");
            ChangeStatus("Ready", 0);
        }


        private void buttonEnableLAN_Click(object sender, EventArgs e)
        {
            DoEnableLAN();
        }

        private void DoEnableLAN()
        {
            LogMessage("Enabling LAN adapters");
            ChangeStatus("Enabling LAN adapters", 25);

            string[] adapters = GetAllAdapterNames();

            foreach (string adapter in adapters)
            {
                if (!adapter.ToLower().Contains("wireless"))
                {
                    LogMessage("Enabling '" + adapter + "'.");
                    ChangeStatus("Enabling '" + adapter + "'.", 50);
                    if (!SetNicStatus(adapter, true))
                    {
                        LogMessage("Error enabling " + adapter);
                    }
                    string result = RunCommand("netsh.exe", "interface set interface \"" + adapter + "\" ENABLED");
                }
            }

            RefreshNetworkInfo(true);
            LogMessage("Enabled LAN adapters");
            ChangeStatus("Ready", 0);
        }


        private void buttonEnableWireless_Click(object sender, EventArgs e)
        {
            DoEnableWireless();
        }

        private void DoEnableWireless()
        {
            LogMessage("Enabling wireless adapters");
            ChangeStatus("Enabling wireless adapters", 25);

            string[] adapters = GetAllAdapterNames();

            foreach (string adapter in adapters)
            {
                if (adapter.ToLower().Contains("wireless"))
                {
                    LogMessage("Enabling '" + adapter + "'.");
                    ChangeStatus("Enabling '" + adapter + "'.", 50);
                    if (!SetNicStatus(adapter, true))
                    {
                        LogMessage("Error enabling " + adapter);
                    }
                    string result = RunCommand("netsh.exe", "interface set interface \"" + adapter + "\" ENABLED");
                }
            }

            RefreshNetworkInfo(true);
            LogMessage("Enabled wireless adapters");
            ChangeStatus("Ready", 0);
        }
        
        private void buttonViewHosts_Click(object sender, EventArgs e)
        {
            DoViewHosts();
        }

        private void DoViewHosts()
        {
            string sHostsPath = Environment.GetEnvironmentVariable("windir") + "\\System32\\Drivers\\Etc\\hosts";
            RunCommand("notepad.exe", sHostsPath);
        }

        private void buttonClearHosts_Click(object sender, EventArgs e)
        {
            DoClearHosts();
        }

        // Overwrites the HOSTS file with the stock default from Microsoft. Creates one if no HOSTS file exists.
        private void DoClearHosts()
        {
            LogMessage("Clearing hosts file changing back to default settings");
            ChangeStatus("Clearing hosts file changing back to default settings", 50);

            string sHostsPath = Environment.GetEnvironmentVariable("windir") + "\\System32\\Drivers\\Etc\\hosts";

            // Log the existing hosts file first
            if (!HostsFileLogged)
            {
                string result = RunCommand("cmd.exe", "/C type \"" + sHostsPath + "\"");
                result = "EXISTING HOSTS FILE CONTENTS:\n" + result;
                LogMessageToFile(result);
            }


            // Remove read-only attribute, if set
            try
            {
                FileInfo fileInfo = new FileInfo(sHostsPath);
                fileInfo.IsReadOnly = false;
                fileInfo.Refresh();
            }
            catch (FileNotFoundException)
            {
                LogMessage("No hosts file found, creating one");
            }

            // Overwrite hosts file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(sHostsPath))
            {
                file.WriteLine("# Copyright (c) 1993-2009 Microsoft Corp.");
                file.WriteLine("#");
                file.WriteLine("# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.");
                file.WriteLine("#");
                file.WriteLine("# This file contains the mappings of IP addresses to host names. Each");
                file.WriteLine("# entry should be kept on an individual line. The IP address should");
                file.WriteLine("# be placed in the first column followed by the corresponding host name.");
                file.WriteLine("# The IP address and the host name should be separated by at least one");
                file.WriteLine("# space.");
                file.WriteLine("#");
                file.WriteLine("# Additionally, comments (such as these) may be inserted on individual");
                file.WriteLine("# lines or following the machine name denoted by a '#' symbol.");
                file.WriteLine("#");
                file.WriteLine("# For example:");
                file.WriteLine("#");
                file.WriteLine("#      102.54.94.97     rhino.acme.com          # source server");
                file.WriteLine("#       38.25.63.10     x.acme.com              # x client host");
                file.WriteLine("#");
                file.WriteLine("127.0.0.1       localhost");
                if (Environment.OSVersion.Version.Major > 5)    // If newer than XP, add IPv6 localhost line
                {
                    file.WriteLine("::1             localhost");
                }
            }

            LogMessage("Hosts file cleared and changed back to default settings");
            ChangeStatus("Ready", 0);
        }


        private void buttonSetDHCP_Click(object sender, EventArgs e)
        {
            DoSetDHCP();
        }

        // Clears static IP settings and enable DHCP
        private void DoSetDHCP()
        {
            string nicName = (string)comboBoxAdapters.SelectedItem;
            NetworkInterface nicSelected;

            FormMessagebox dlg = new FormMessagebox("Clear Static IP Settings (enable DHCP)",
                                                    "Do you want to clear static IP settings for all network "
                                                  + "adapters or only the selected one?",
                                                    "Only the Selected (" + nicName + ")",
                                                    "All Network Adapters",
                                                    "Cancel");
            dlg.ShowDialog();
            
            if (dlg.ButtonPressed == 0 || dlg.ButtonPressed == 3)
            {
                return;
            }

            LogMessage("Clearing static IP settings and set back to DHCP");
            ChangeStatus("Clearing static IP settings and set back to DHCP", 25);

            if (dlg.ButtonPressed == 1)
            {
                nicSelected = GetNic(nicName);
                EnableDHCP(nicSelected);
                LogMessage("Cleared static IP/DNS settings and set back to DHCP (" + nicName + ")");
            }
            else if (dlg.ButtonPressed == 2)
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface nic in nics)
                {
                    EnableDHCP(nic);
                }
                LogMessage("Cleared static IP/DNS settings and set back to DHCP (All Adapters)");
                ChangeStatus("Ready", 0);
            }
    
            ChangeStatus("Ready", 0);
        }

        private void EnableDHCP(NetworkInterface nic)
        {
            IPInterfaceProperties ipProperties = nic.GetIPProperties();
            if (ipProperties != null)
            {
                try
                {
                    //String dhcp = string.Join(", ", ipProperties.DhcpServerAddresses.Select(x => x.ToString()).OrderBy(x => x.Length));
                    String ipAddress = string.Join(", ", ipProperties.UnicastAddresses.Select(x => x.Address.ToString()).OrderBy(x => x.Length));
                    String dnsAddress = string.Join(", ", ipProperties.DnsAddresses.Select(x => x.ToString()).OrderBy(x => x.Length));
                    String subnetMask = string.Join(", ", ipProperties.UnicastAddresses.Select(x => x.IPv4Mask.ToString()).Where(x => !x.Equals("0.0.0.0")));

                    if (!ipAddress.Equals("") && !dnsAddress.Equals(""))
                    {
                        LogMessage("Clearing static IP/DNS settings for '" + nic.Name + "'");
                        ChangeStatus("Clearing static IP/DNS settings for '" + nic.Name + "'", 50);
                        LogMessage("Existing settings for '" + nic.Name + "':");
                        if (!ipAddress.Equals(""))
                        {
                            LogMessage("IP Address: " + ipAddress);
                        }
                        if (!dnsAddress.Equals(""))
                        {
                            LogMessage("DNS Addresses: " + dnsAddress);
                        }
                        LogMessage("Subnet Mask: " + subnetMask);
                    }

                    RunCommand("netsh.exe", "interface ip set address \"" + nic.Name + "\" source=dhcp");

                    if (!dnsAddress.Equals(""))
                    {
                        LogMessage("Clearing DNS settings for '" + nic.Name + "'");
                        ChangeStatus("Clearing DNS settings for '" + nic.Name + "'", 50);
                    }

                    RunCommand("netsh.exe", "interface ip set dns \"" + nic.Name + "\" source=dhcp");
                }
                catch (Exception e)
                {
                    //LogMessage("There is an error getting IP/DNS settings for '" + nicSelected.Name + "'");
                }
            }
        }


        private void buttonGoogleDNS_Click(object sender, EventArgs e)
        {
            DoGoogleDNS();
        }

        private void DoGoogleDNS()
        {
            string nicName = (string)comboBoxAdapters.SelectedItem;

            FormMessagebox dlg = new FormMessagebox("Change to Google DNS",
                                                    "Do you want to set Google DNS for all network "
                                                  + "adapters or only the selected one?",
                                                    "Only the Selected (" + nicName + ")",
                                                    "All Network Adapters",
                                                    "Cancel");
            dlg.ShowDialog();

            if (dlg.ButtonPressed == 0 || dlg.ButtonPressed == 3)
            {
                return;
            }

            LogMessage("Setting all DNS servers to Google DNS");
            ChangeStatus("Setting all DNS servers to Google DNS", 25);

            if (dlg.ButtonPressed == 1)
            {
                RunCommand("netsh.exe", "interface ip set dns \"" + nicName + "\" static 8.8.4.4 primary");
                RunCommand("netsh.exe", "interface ip add dns \"" + nicName + "\" 8.8.8.8 index=1");
                LogMessage("Set DNS servers to Google DNS (" + nicName + ")");
            }
            else if (dlg.ButtonPressed == 2)
            {
                foreach (string adapter in GetAllAdapterNames())
                {
                    LogMessage("Setting DNS server for '" + adapter + "'");
                    ChangeStatus("Setting DNS server for '" + adapter + "'", 50);
                    RunCommand("netsh.exe", "interface ip set dns \"" + adapter + "\" static 8.8.4.4 primary");
                    RunCommand("netsh.exe", "interface ip add dns \"" + adapter + "\" 8.8.8.8 index=1");
                }

                LogMessage("Set DNS servers to Google DNS (All Adapters)");
            }

            ChangeStatus("Ready", 0);
        }

        
        private void buttonClearSSL_Click(object sender, EventArgs e)
        {
            DoClearSSL();
        }

        private void DoClearSSL()
        {
            LogMessage("Clearing SSL state cache");
            ChangeStatus("Clearing SSL state cache", 50);

            string sDllPath = Environment.GetEnvironmentVariable("windir") + "\\system32\\wininet.dll";
            String result = RunCommand("Rundll32.exe", "\"" + sDllPath + "\",DispatchAPICall 3");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred clearing SSL state cache");
                LogMessage(result);
            };

            LogMessage("Cleared SSL state cache");
            ChangeStatus("Ready", 0);
        }

        private void buttonResetInternetSecurity_Click(object sender, EventArgs e)
        {
            DoResetInternetSecurity();
        }

        private void DoResetInternetSecurity()
        {
            LogMessage("Resetting Internet Options Security/Privacy to default");
            ChangeStatus("Resetting Internet Options Security/Privacy to default", 50);
            String result;

            InternetZoneManager izm = new InternetZoneManager();
            izm.CopyTemplatePoliciesToZone(URLTEMPLATE.URLTEMPLATE_MEDHIGH, UrlZone.Internet);
            izm.CopyTemplatePoliciesToZone(URLTEMPLATE.URLTEMPLATE_MEDLOW, UrlZone.Intranet);
            izm.CopyTemplatePoliciesToZone(URLTEMPLATE.URLTEMPLATE_MEDIUM, UrlZone.Trusted);
            izm.CopyTemplatePoliciesToZone(URLTEMPLATE.URLTEMPLATE_HIGH, UrlZone.Untrusted);

            LogMessage("Resetting privacy level to default");
            ChangeStatus("Resetting privacy level to default", 60);
            RunIEPrivacyDefaultRegFile();

            LogMessage("Turning on popup blocker");
            ChangeStatus("Turning on popup blocker", 70);
            result = RunCommand("reg", "add \"HKCU\\Software\\Microsoft\\Internet Explorer\\New Windows\" /v PopupMgr /t REG_DWORD /d 1 /f");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred turning on popup blocker");
                LogMessage(result);
            };

            LogMessage("Setting physical location requests to default");
            ChangeStatus("Setting physical location requests to default", 80);
            result = RunCommand("reg", "add \"HKCU\\Software\\Microsoft\\Internet Explorer\\Geolocation\" /v BlockAllWebsites /t REG_DWORD /d 0 /f");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred setting physical location requests to default");
                LogMessage(result);
            };

            LogMessage("Disabling toolbars and extensions for InPrivate Browsing");
            ChangeStatus("Disabling toolbars and extensions for InPrivate Browsing", 90);
            result = RunCommand("reg", "add \"HKCU\\Software\\Microsoft\\Internet Explorer\\Safety\\PrivacIE\" /v DisableToolbars /t REG_DWORD /d 1 /f");
            if (result.ToLower().Contains("error "))
            {
                LogMessage("An error occurred disabling toolbars and extensions for InPrivate Browsing");
                LogMessage(result);
            };

            LogMessage("Reset Internet Options Security/Privacy to default");
            ChangeStatus("Ready", 0);
        }

        // Event handler for combobox. Called when the user selects a different network adapter
        // Using the adapter combo box
        private void comboBoxAdapters_SelectedValueChanged(object sender, EventArgs e)
        {
            NetworkInterface nic = GetNic((string)comboBoxAdapters.SelectedItem);
            if (nic != null)
            {
                IPv4InterfaceStatistics ipStats = nic.GetIPv4Statistics();
                if (ipStats != null)
                {
                    BytesSent = ipStats.BytesSent;
                    BytesReceived = ipStats.BytesReceived;
                }
            }
            RefreshAdapterInfo((string)comboBoxAdapters.SelectedItem);
        }

        // Initialization work while the main form is loading
        private void FormMain_Load(object sender, EventArgs e)
        {
            labelWarning.Text = "";
            LogMessage(GetOSName());

            LogMessage("NetAdapter Repair All in One v1.2 Loaded");
            // Check if the logged in user is an administrator and show a warning if not
            if (!IsAdministrator())
            {
                LogMessage("Application opened as an Administrator");
                DialogResult dlg;
                dlg = MessageBox.Show("Warning: Application not opened as an Administrator. "
                                    + "Note: Some functions may not work correctly.\n"
                                    + "\n"
                                    + "Do you want to continue?",
                                      "Information",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

                // Quit if the user clicks Cancel
                if (dlg == DialogResult.No)
                {
                    Application.Exit();
                }

                labelWarning.Text = "Warning: Application not opened as an Administrator. Note: Some functions may not work correctly.";

            }
            else  // If the user *is* an administrator
            {
                LogMessage("Application opened as an Administrator");
            }
            RefreshNetworkInfo(true);

            // Print existing network information to the log file
            string result = RunCommand("ipconfig.exe", "/all");
            LogMessageToFile(result);
        }

        // Open URL when copyright link is clicked
        private void labelCopyright_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.connerb.com/");
        }

        private void labelDonate_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=XQUA8QZ8WASS4");
        }

        // Timer for updating the sent/received stats for the selected network adapter every second
        private void timer1_Tick(object sender, EventArgs e)
        {
            //pictureSent.Image = imageList1.Images[0];
            //pictureRecv.Image = imageList1.Images[2];
            this.Refresh();

            NetworkInterface nic = GetNic((string)comboBoxAdapters.SelectedItem);
            if (nic != null)
            {
                IPv4InterfaceStatistics ipStats = nic.GetIPv4Statistics();
                if (ipStats != null)
                {
                    long sentActive = ((ipStats.BytesSent + 1 - BytesSent) / 1024);
                    long recvActive = ((ipStats.BytesReceived + 1 - BytesReceived) / 1024);
                    long sentTotal = ((ipStats.BytesSent + 1 - BytesSentTotal) / 1024 / 1024);
                    long recvTotal = ((ipStats.BytesReceived + 1 - BytesReceivedTotal) / 1024 / 1024);

                    labelNetworkStats.Text = "Sent: " + (sentActive > 0 ? sentActive : 0)  + "KB / " +
                        + (sentTotal > 0 ? sentTotal : 0)  + "MB | Received: "
                        + (recvActive > 0 ? recvActive : 0)  + "KB / "
                        + (recvTotal > 0 ? recvTotal : 0) + "MB";

                    //long sentTick = ((ipStats.BytesSent + 1 - BytesSentTick) / 1024);
                    //long recvTick = ((ipStats.BytesReceived + 1 - BytesReceivedTick) / 1024);
                    //pictureSent.Image = imageList1.Images[recvTick > 0 ? 1 : 0];
                    //pictureRecv.Image = imageList1.Images[recvTick > 0 ? 3 : 2];
                    //BytesSentTick = ipStats.BytesSent;
                    //BytesReceivedTick = ipStats.BytesReceived;
                }
            }
        }

        // Log if the user wants to close the application
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogMessage("User closed the application");
        }

        private void cbAdditionalAll_CheckedChanged(object sender, EventArgs e)
        {
            //setCheckboxStates(cbAdditionalAll.Checked);
        }

        private void setCheckboxStates(bool state)
        {
            cbRenewDHCP.Checked = state;
            cbClearHosts.Checked = state;
            cbSetDHCP.Checked = state;
            cbGoogleDNS.Checked = state;
            cbFlushDNS.Checked = state;
            cbClearARP.Checked = state;
            cbReloadNETBIOS.Checked = state;
            cbClearSSL.Checked = state;
            cbEnableLAN.Checked = state;
            cbEnableWireless.Checked = state;
            cbResetInternetSecurity.Checked = state;
            cbServicesDefault.Checked = state;
            //cbAdditionalAll.Checked = state;
        }

        private void buttonServicesDefault_Click(object sender, EventArgs e)
        {
            DoServicesDefault();
        }

        // StartMode can be "Boot", "System", "Auto", "Manual" or "Disabled"
        public bool SetServiceMode(string ServiceName, string StartMode)
        {
            bool isChanged = false;
            ManagementPath p = new ManagementPath("Win32_Service.Name='" + ServiceName + "'");
            using (ManagementObject service = new ManagementObject(p))
            {
                try
                {
                    string DisplayName = (string)service["DisplayName"];
                    string ExistingMode = (string)service["StartMode"];
                    if (ExistingMode.Equals("Auto"))     // WMI inconsistency
                    {
                        ExistingMode = "Automatic";
                    }
                    if (!ExistingMode.Equals(StartMode))
                    {
                        LogMessage("Setting service '" + DisplayName + "' to '" + StartMode + "' (was: '" + ExistingMode + "')");
                        ManagementBaseObject inputArgs = service.GetMethodParameters("ChangeStartMode");
                        inputArgs["StartMode"] = StartMode;
                        service.InvokeMethod("ChangeStartMode", inputArgs, null);
                        isChanged = true;
                    }
                }
                catch (System.Management.ManagementException e)
                {
                    //LogMessage(e.StackTrace);
                }
            }
            return isChanged;
        }

        // Process a list of services and set their StartMode
        private bool ProcessServiceList(string[] ServiceNames, string ServiceMode)
        {
            bool isChanged = false;
            foreach (string ServiceName in ServiceNames)
            {
                isChanged = SetServiceMode(ServiceName, ServiceMode) || isChanged;
            }
            return isChanged;
        }

        private void DoServicesDefault()
        {
            bool isChanged = false;
            string[] XP_Auto = {"Browser", "Dhcp", "Dnscache", "LanmanServer", "LanmanWorkstation", 
                                "LmHosts", "PlugPlay", "SharedAccess", "W32Time", "wscsvc", "WZCSVC"};
            string[] XP_Manual = {"dot3svc", "EapHost", "Nla", "WinHttpAutoProxySvc" };
            string[] Vista_Auto = {"BFE", "Browser", "Dhcp", "Dnscache", "LanmanServer", "LanmanWorkstation", 
                                   "lmhosts", "MpsSvc", "netprofm", "NlaSvc", "nsi", "PlugPlay", "W32Time", 
                                   "wscsvc"};
            string[] Vista_Manual = {"dot3svc", "EapHost", "WinHttpAutoProxySvc", "Wlansvc", "WMPNetworkSvc"};
            string[] W7_Auto = {"BFE", "Dhcp", "Dnscache", "LanmanServer", "LanmanWorkstation", "lmhosts", 
                                "MpsSvc", "NlaSvc", "nsi", "PlugPlay", "wscsvc"};
            string[] W7_Manual = {"Browser", "dot3svc", "EapHost", "HomeGroupProvider", "netprofm", "W32Time", 
                                  "WinHttpAutoProxySvc", "Wlansvc", "WMPNetworkSvc", "WwanSvc"};
            string[] W8_Auto = {"BFE", "Dhcp", "Dnscache", "LanmanServer", "LanmanWorkstation", "lmhosts", 
                                "MpsSvc", "NlaSvc", "nsi", "Wcmsvc", "wscsvc"};
            string[] W8_Manual = {"Browser", "dot3svc", "EapHost", "HomeGroupProvider", "NcaSvc", "NcdAutoSetup", 
                                  "netprofm", "PlugPlay", "W32Time", "WinHttpAutoProxySvc", "Wlansvc", 
                                  "WMPNetworkSvc", "WwanSvc"};

            int VMajor = Environment.OSVersion.Version.Major;
            int VMinor = Environment.OSVersion.Version.Minor;

            LogMessage("Setting Network Windows Services to Default");
            ChangeStatus("Setting Network Windows Services to Default", 50);
            if ((VMajor == 5) && ((VMinor == 1) || (VMinor == 2)))  // Windows XP or XP 64-Bit
            {
                isChanged = isChanged || ProcessServiceList(XP_Auto, "Automatic");
                isChanged = isChanged || ProcessServiceList(XP_Manual, "Manual");

            } else if ((VMajor == 6) && (VMinor == 0)) {            // Windows Vista
                isChanged = isChanged || ProcessServiceList(Vista_Auto, "Automatic");
                isChanged = isChanged || ProcessServiceList(Vista_Manual, "Manual");

            } else if ((VMajor == 6) && (VMinor == 1)) {            // Windows 7
                isChanged = isChanged || ProcessServiceList(W7_Auto, "Automatic");
                isChanged = isChanged || ProcessServiceList(W7_Manual, "Manual");

            } else if ((VMajor == 6) && ((VMinor == 2) || (VMinor == 3))) {  // Windows 8/8.1
                isChanged = isChanged || ProcessServiceList(W8_Auto, "Automatic");
                isChanged = isChanged || ProcessServiceList(W8_Manual, "Manual");
            }
            else
            {
                LogMessage("Unsupported Windows version; default service settings cannot be determined");
            }
            if (!isChanged)
            {
                LogMessage("All services was already in their default states; no changes were made");
            }
            else
            {
                FormRestartConfirmation dlgRestart = new FormRestartConfirmation(60);
                dlgRestart.ShowDialog();
                if (dlgRestart.ButtonPressed == 1)
                {
                    LogMessage("Restarting the computer");
                    ChangeStatus("Restarting the computer...", 100);
                    RunCommand("cmd.exe", "/C shutdown /r /t 5");
                }
                else
                {
                    MessageBox.Show("You should restart your computer manually.");
                    LogMessage("Restart canceled by user");
                }
            }
            ChangeStatus("Ready", 0);
        }

        private void buttonRunAll_Click(object sender, EventArgs e)
        {
            if (cbRenewDHCP.Checked) {
                DoRenewDHCP();
            }

            if (cbClearHosts.Checked) {
                DoClearHosts();
            }

            if (cbSetDHCP.Checked) {
                DoSetDHCP();
            }

            if (cbGoogleDNS.Checked) {
                DoGoogleDNS();
            }

            if (cbFlushDNS.Checked) {
                DoFlushDNS();
            }

            if (cbClearARP.Checked) {
                DoClearARP();
            }

            if (cbReloadNETBIOS.Checked) {
                DoReloadNETBIOS();
            }

            if (cbClearSSL.Checked) {
                DoClearSSL();
            }

            if (cbEnableLAN.Checked) {
                DoEnableLAN();
            }

            if (cbEnableWireless.Checked) {
                DoEnableWireless();
            }

            if (cbResetInternetSecurity.Checked) {
                DoResetInternetSecurity();
            }

            if (cbServicesDefault.Checked) {
                DoServicesDefault();
            }

            setCheckboxStates(false);
        }

        private void buttonResetStats_Click(object sender, EventArgs e)
        {
            NetworkInterface nic = GetNic((string)comboBoxAdapters.SelectedItem);
            if (nic != null)
            {
                IPv4InterfaceStatistics ipStats = nic.GetIPv4Statistics();
                if (ipStats != null)
                {
                    BytesSent = ipStats.BytesSent;
                    BytesReceived = ipStats.BytesReceived;
                    BytesSentTotal = ipStats.BytesSent;
                    BytesReceivedTotal = ipStats.BytesReceived;
                }
            }
            richTextBoxLogArea.Clear();
        }

        private void DoPing(string Name, string Address)
        {
            LogMessage("Pinging '" + Name + "' (" + Address + ")");
            ChangeStatus("Pinging '" + Name + "' (" + Address + ")", 30);

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;     // 1 seconds
            try
            {
                PingReply reply = pingSender.Send(Address, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    LogMessage("Pinged '" + Name + "' (" + Address + ") successfully (" + reply.RoundtripTime + " ms)");
                    return;
                }
                else
                {
                    LogMessage("Ping unsuccessful for '" + Name + "' (" + Address + ")");
                }
            } catch (Exception e) {
                LogMessage("Ping unsuccessful for '" + Name + "' (" + Address + ")");
            }
            finally
            {
                ChangeStatus("Ready", 0);
            }
        }

        private void buttonPingIP_Click(object sender, EventArgs e)
        {
            DoPing("Google", "74.125.239.128");
            DoPing("Cloudflare", "198.41.213.157");
        }

        private void buttonPingDNS_Click(object sender, EventArgs e)
        {
            DoPing("Google", "google.com");
            DoPing("Cloudflare", "cloudflare.com");
        }

        private RegistryKey FindRegistryKeyForNic(NetworkInterface nic)
        {
            RegistryKey rk = Registry.LocalMachine;
            rk = rk.OpenSubKey("SYSTEM");
            rk = rk.OpenSubKey("CurrentControlSet");
            rk = rk.OpenSubKey("Control");
            rk = rk.OpenSubKey("Class");
            rk = rk.OpenSubKey("{4D36E972-E325-11CE-BFC1-08002BE10318}");

            // Look for each subkey (0001, 0002, etc) and try to find our adapter
            foreach (string keyname in rk.GetSubKeyNames())
            {
                RegistryKey subkey = rk.OpenSubKey(keyname, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (nic.Description.Equals(subkey.GetValue("DriverDesc")))  // Adapter found!
                {
                    return subkey;
                }
            }

            return null;
        }


        private void buttonSpoof_Click(object sender, EventArgs e)
        {
            DoSpoof();
        }

        private void DoSpoof()
        {
            string oldMAC = "";
            string newMAC = "";
            string spoofedMAC = "";
            bool isSpoofed = false;
            NetworkInterface nic = GetNic((string)comboBoxAdapters.SelectedItem);
            if (nic != null)
            {
                oldMAC = string.Join(":", (from z in nic.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());
                RegistryKey key = FindRegistryKeyForNic(nic);
                if (key != null)
                {
                    spoofedMAC = (string) key.GetValue("NetworkAddress", "");
                    isSpoofed = !spoofedMAC.Equals("");
                }
            }

            int dlgButton = 3;
            FormDialog dlg;
            while (dlgButton == 3)      // Generate a new MAC if Randomize button is clicked
            {
                Byte[] newMacBytes = new Byte[6];
                new Random().NextBytes(newMacBytes);
                // First 2 bytes of MAC should be the same
                newMacBytes[0] = nic.GetPhysicalAddress().GetAddressBytes()[0];
                newMacBytes[1] = nic.GetPhysicalAddress().GetAddressBytes()[1];
                newMAC = string.Join(":", (from z in newMacBytes select z.ToString("X2")).ToArray());

                dlg = new FormDialog("MAC Spoofing",
                                     "You can spoof your MAC address if the adapter supports it. "
                                   + "This is a random MAC address for you, but you can change it. "
                                   + "The current MAC address is \"" + oldMAC + "\""
                                   + (isSpoofed ? " (Spoofed)." : " (Physical)."),
                                     newMAC,
                                     "Change MAC",
                                     "Cancel",
                                     "Randomize",
                                     "Delete Spoofing");
                dlg.ShowDialog();
                dlgButton = dlg.ButtonPressed;

                if (dlgButton == 0 || dlgButton == 2)     // Cancel button clicked or dialog closed
                {
                    return;
                }
                else if (dlgButton == 1)               // "Change MAC" button clicked
                {
                    newMAC = dlg.Value;
                    if (newMAC.Split(':').Count() == 6)
                    {
                        RegistryKey key = FindRegistryKeyForNic(nic);
                        if (key != null)
                        {
                            // Set registry value with the new MAC address
                            key.SetValue("NetworkAddress", newMAC.Replace(":", ""));

                            string result;

                            // Now disable and enable the network adapter
                            if (!SetNicStatus(nic.Name, false))
                            {
                                LogMessage("Error disabling " + nic.Name);
                            }
                            result = RunCommand("netsh.exe", "interface set interface \"" + nic.Name + "\" DISABLED");

                            if (!SetNicStatus(nic.Name, true))
                            {
                                LogMessage("Error re-enabling " + nic.Name);
                            }
                            result = RunCommand("netsh.exe", "interface set interface \"" + nic.Name + "\" ENABLED");

                            RefreshAdapterInfo((string)comboBoxAdapters.SelectedItem);

                            LogMessage("MAC address of '" + nic.Name + "' changed from '" + oldMAC + "' to '" + newMAC + "'");
                        }
                        else
                        {
                            LogMessage("MAC spoofing failed. Cannot find registry location for '" + nic.Name + "'");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid MAC address");
                    }
                }
                else if (dlgButton == 4)               // "Clear MAC" button clicked
                {
                    RegistryKey key = FindRegistryKeyForNic(nic);
                    if (key != null)
                    {
                        // Delete registry value with the new MAC address
                        key.DeleteValue("NetworkAddress", false);

                        string result;

                        // Now disable and enable the network adapter
                        if (!SetNicStatus(nic.Name, false))
                        {
                            LogMessage("Error disabling " + nic.Name);
                        }
                        result = RunCommand("netsh.exe", "interface set interface \"" + nic.Name + "\" DISABLED");

                        if (!SetNicStatus(nic.Name, true))
                        {
                            LogMessage("Error re-enabling " + nic.Name);
                        }
                        result = RunCommand("netsh.exe", "interface set interface \"" + nic.Name + "\" ENABLED");

                        RefreshAdapterInfo((string)comboBoxAdapters.SelectedItem);

                        nic = GetNic((string)comboBoxAdapters.SelectedItem);
                        if (nic != null)
                        {
                            newMAC = string.Join(":", (from z in nic.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());
                        }

                        LogMessage("MAC address of '" + nic.Name + "' changed from '" + oldMAC + "' to default '" + newMAC + "'");
                    }
                    else
                    {
                        LogMessage("MAC spoofing failed. Cannot find registry location for '" + nic.Name + "'");
                    }
                }
            }
        }
    }
}

