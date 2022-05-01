using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaserGame_V2_2
{
    public class MainService
    {
        public NetworkService network;
        public Materials materials;
        public ESPService espService;
        public ScoreService scoreService;
        public GameTimerService gameTimer;
        public ConfigService config;
        public bool playing = false;

        public MainService()
        {
            network = new NetworkService();
            materials = new Materials(this);
            espService = new ESPService();
            scoreService = new ScoreService();
            gameTimer = new GameTimerService(this);
            config = new ConfigService();
        }

        internal void start(TimeSpan timeSpan)
        {
            materials.setcolor(true);
            materials.start();
            gameTimer.start(timeSpan);
        }

        internal void stop()
        {
            materials.setcolor(false);
            materials.stop();
            gameTimer.stop();
        }
    }
}
