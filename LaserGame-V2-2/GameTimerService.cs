using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserGame_V2_2
{
    public class GameTimerService
    {
        MainService main;

        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        TimeSpan time = new TimeSpan();
        TimeSpan initTime = new TimeSpan();


        public GameTimerService(MainService main)
        {
            this.main = main;

            gameTimer.Interval = new TimeSpan(0, 0, 0, 1);
            gameTimer.Tick += everySecond;
        }
        public TimeSpan getTime()
        {
            return time;
        }
        public TimeSpan getInitTime()
        {
            return initTime;
        }

        public void setTime(TimeSpan _time)
        {
            time = _time;
            initTime = _time;
        }
        public void setInitTime(TimeSpan _time)
        {
            initTime = _time;
        }

        public void start(TimeSpan _time)
        {
            main.playing = true;
            time = _time;
            initTime = _time;
            gameTimer.Start();
        }
        public void start()
        {
            main.playing = true;
            time = initTime;
            gameTimer.Start();
        }
        public void stop(TimeSpan _newtime)
        {
            main.playing = false;
            time = _newtime;
            doEverySecond();
            gameTimer.Stop();
        }
        public void stop()
        {
            main.playing = false;
            time = initTime;
            doEverySecond();
            gameTimer.Stop();
        }
        private async void everySecond(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                doEverySecond();
            });
        }

        private async void doEverySecond()
        {
            time = time.Subtract(new TimeSpan(0, 0, 0, 1));
            if(time.Seconds < 0)
            {
                stop(initTime);
            }
            main.materials.getKills();
        }
    }
}
