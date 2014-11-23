using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace AutoSleep
{
    public partial class Form1 : Form
    {
        int _intervalInSecs;
        Timer _checkInputIntervalTimer;
        bool _started = false;

        public Form1()
        {
            InitializeComponent();
            SystemEvents.PowerModeChanged += OnPowerChange;
            Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_started)
                Start();
            else
                Stop();

   
        }

        /// <summary>
        /// Start The Timer that checks if there has been any input
        /// </summary>
        private void Start()
        {
            if (SecsTbox.Text != "")
            {
                int intervalInMinutes;
                if (Int32.TryParse(SecsTbox.Text, out intervalInMinutes))
                {
                    _intervalInSecs = intervalInMinutes * 60;
                    if (_checkInputIntervalTimer == null)
                        _checkInputIntervalTimer = new Timer();
                    _checkInputIntervalTimer.Interval = 1000; //checks every seconds
                    _checkInputIntervalTimer.Tick += checkInput_Tick;
                    _checkInputIntervalTimer.Start();
                    _started = true;
                    button1.Text = "Stop";
                }
            }
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        private void Stop()
        {
            if (_checkInputIntervalTimer != null)
            {
                _checkInputIntervalTimer.Stop();
                _checkInputIntervalTimer.Tick -= checkInput_Tick;
            }
            _started = false;
            button1.Text = "Start";
        }

        void checkInput_Tick(object sender, EventArgs e)
        {

            var lastInput = IdleTimeFinder.GetLastInputTime(); //last input in milliseconds

            

            if (lastInput > _intervalInSecs * 1000) 
            {
                bool isFullscreen = false;
                if (fullscreenChk.Checked)
                    isFullscreen = IsForegroundFullScreen();

                if (!isFullscreen)
                {
                    Stop();
                    Application.SetSuspendState(PowerState.Suspend, false, true);
                }
            }
        }

  

        private void OnPowerChange(object s, PowerModeChangedEventArgs e) 
        {
            switch ( e.Mode ) 
            {
                case PowerModes.Resume:
                    Console.WriteLine("RESUME");
                    Timer delayStartTimer = new Timer();
                    delayStartTimer.Interval = 60000;
                    delayStartTimer.Tick += delayStartTimer_Tick;
                    delayStartTimer.Start();
                break;
                case PowerModes.Suspend:

                Console.WriteLine("SUSPEND");
                break;
            }
        }

        /// <summary>
        /// After resume, the timer is restarted after a minute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void delayStartTimer_Tick(object sender, System.EventArgs e)
        {
            ((Timer)sender).Stop();
            ((Timer)sender).Tick -= delayStartTimer_Tick;
            Console.WriteLine("RESTART TIMER");
            Start();
        }


        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref RECT rect);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public static bool IsForegroundFullScreen()
        {
            bool fullscreen = false ;

            foreach (var screen in Screen.AllScreens)
            {
               fullscreen|= IsForegroundFullScreen(screen);
            }

            Console.WriteLine("checking fullscreen = {0}", fullscreen);
            return fullscreen;
        }

        public static bool IsForegroundFullScreen(Screen screen)
        {
            if (screen == null)
            {
                screen = Screen.PrimaryScreen;
            }
            RECT rect = new RECT();
            GetWindowRect(new HandleRef(null, GetForegroundWindow()), ref rect);
            return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top).Contains(screen.Bounds);
        }


        internal struct LASTINPUTINFO
        {
            public uint cbSize;

            public uint dwTime;
        }

        public class IdleTimeFinder
        {
            [DllImport("User32.dll")]
            private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

            [DllImport("Kernel32.dll")]
            private static extern uint GetLastError();

            public static uint GetIdleTime()
            {
                LASTINPUTINFO lastInPut = new LASTINPUTINFO();
                lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
                GetLastInputInfo(ref lastInPut);

                return ((uint)Environment.TickCount - lastInPut.dwTime);
            }
            /// <summary>
            /// Get the Last input time in ticks
            /// </summary>
            /// <returns></returns>
            public static uint GetLastInputTime()
            {
                LASTINPUTINFO lastInPut = new LASTINPUTINFO();
                lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
                if (!GetLastInputInfo(ref lastInPut))
                {
                    throw new Exception(GetLastError().ToString());
                }
                return ((uint)Environment.TickCount - lastInPut.dwTime);
            }

          

        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                mynotifyicon.Visible = true;
             //   mynotifyicon.ShowBalloonTip(500);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                mynotifyicon.Visible = false;
            }
        }

        private void mynotifyicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

          
        }

        private void mynotifyicon_Click(object sender, System.EventArgs e)
        {

            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
