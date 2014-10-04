using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WebTimer
{
    public class WTimer : INotifyPropertyChanged
    {
        private int codingMinutes;
        private int surfingMinutes;
        private string validCommand;
        private Timer timer;
        private TimeSpan time;

        public event PropertyChangedEventHandler PropertyChanged;

        public string TimeFormatted
        {
            get
            {
                return String.Format("{0}:{1}",
                    Math.Floor(time.TotalMinutes).ToString().PadLeft(2,'0'),
                    time.Seconds.ToString().PadLeft(2, '0'));
            }
        }
        
        public string ValidCommand
        {
            get { return validCommand; }
            private set {
                validCommand = value;
                NotifyPropertyChanged();
            }
        }

        public int CodingMinutes
        {
            get { return codingMinutes; }
            set {
                codingMinutes = value;
                NotifyPropertyChanged();
            }
        }

        public int SurfingMinutes
        {
            get { return surfingMinutes; }
            set {
                surfingMinutes = value;
                NotifyPropertyChanged();
            }
        }

        public WTimer()
        {
            timer = new Timer(1000);
            time = new TimeSpan(0, 0, 0);
            timer.Elapsed += timer_Elapsed;
            ValidCommand = "Start";

        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            time = time.Add(new TimeSpan(0, 0, 1));
            NotifyPropertyChanged("TimeFormatted");
        }

        public void Toggle()
        {
            if (timer.Enabled)
            {
                Stop();
            }
            else
            {
                Start();
            }
        }

        public void Start()
        {
            timer.Start();
            ValidCommand = "Stop";
        }

        public void Stop()
        {
            timer.Stop();
            ValidCommand = "Start";
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
    }
}
