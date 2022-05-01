using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserGame_V2_2
{
    public class ScoreService
    {
        public double kill = 0;
        public double death = 0;
        public double autokill = 0;
        public double teamkill = 0;
        public double gunkill = 0;

        public void set(double kill,double death,double autokill,double teamkill,double gunkill)
        {
            this.kill = kill;
            this.death = death;
            this.autokill = autokill;
            this.teamkill = teamkill;
            this.gunkill = gunkill;
        }

    }
}
