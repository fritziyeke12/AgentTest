using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AgentToCall
{
    public class Agent
    {
        static NotifyIcon? trayIcon = null;
        static EventLog? eventLog = null;

        [STAThread]
        public static void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the tray icon
            trayIcon = new NotifyIcon();
            trayIcon.Icon = new Icon("diamond.ico");  // Replace with your icon path
            trayIcon.Visible = true;
            trayIcon.Text = "Event Notification Agent";

            // Use ContextMenuStrip instead of ContextMenu
            ContextMenuStrip trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Exit", null, OnExit);
            trayIcon.ContextMenuStrip = trayMenu;

            // Start monitoring event logs
            StartMonitoring();

            // Keep the app running
            Application.Run();
        }

        public static void StartMonitoring()
        {
            // Define the event log to monitor (Application, System, or custom)
            eventLog = new EventLog("MyNewerLog");
            eventLog.EntryWritten += new EntryWrittenEventHandler(OnEventLogWritten);
            eventLog.EnableRaisingEvents = true;  // Start listening for events
        }

        private static void OnEventLogWritten(object source, EntryWrittenEventArgs e)
        {
           /* if (e.Entry.InstanceId == 0) // Example filter for a specific event ID
            {*/
                // Here, you'd trigger a notification or log the event
                ShowNotification($"Event ID {e.Entry.InstanceId} logged!");
                OpenWpfWindow($"Event ID {e.Entry.InstanceId} was logged in the event log.");
           /* }*/
        }

        private static void ShowNotification(string message)
        {
            if(trayIcon != null)
            {
                trayIcon.BalloonTipTitle = "Event Notification";
                trayIcon.BalloonTipText = message;
                trayIcon.ShowBalloonTip(3000); // Show balloon notification for 3 seconds
            }            
        }

        private static void OpenWpfWindow(string message)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = @"C:\Users\fritz\hax\SweetNothings\AgentToCall\NotifyWindow\bin\Debug\net6.0-windows\NotifyWindow.exe",  // Full path to your WPF executable
                Arguments = "\"" + message + "\"",  // Ensure the message is correctly wrapped in quotes
                UseShellExecute = true,  // Run the process independently of the current process
                CreateNoWindow = true  // Don’t create a console window
            };

            Process.Start(startInfo);
        }

        private static void OnExit(object? sender, EventArgs e)
        {
            if(trayIcon != null)
            {
                trayIcon.Visible = false;
            }            
            Application.Exit();
        }
    }
}