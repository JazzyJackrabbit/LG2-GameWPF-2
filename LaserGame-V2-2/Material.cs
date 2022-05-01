using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserGame_V2_2
{
    public class Material
    {
        MainService main;

        public string ip;
        public MaterialType type;

        //player
        public string idlaser;
        public string pseudo;
        public string color;
        public string team;
        public double kill;
        public double death;
        public double score;
        internal List<string> buffer;
        internal int bufferPos;

        //UI
        public UIPlayer uiPlayer;

        public Material(MainService main, MaterialType _type, string _ip)
        {
            this.main = main;
            uiPlayer = new UIPlayer(main, this);
            type = _type;
            ip = _ip;
        }

        public int getIdLaser()
        {
            //todo revoir
            Task<string> task = main.espService.postAsync(ip, "player", "PC");

            string _buffer = getBuffer().Result;

            string id = _buffer.Split('D')[_buffer.Split('D').Length - 1];
            id = id.Split('z')[0];

            this.idlaser = id;

            int idlaserInt = Convert.ToInt32(id);

            return idlaserInt;
        }
        public Task<string> getBuffer()
        {
            Task<string> task = main.espService.postAsync(ip, "server", "");
            return task;
        }
        public Task<string> Start()
        {
            Task<string> task = main.espService.postAsync(ip, "player", "S");
            return task;
        }
        public Task<string> Stop()
        {
            Task<string> task = main.espService.postAsync(ip, "player", "E");
            return task;
        }

        public Task<string> setColor(bool enableColor)
        {
            if(enableColor != true)
            {
                Task<string> task = main.espService.postAsync(ip, "player", main.config.NoColorCmd);
                return task;
            }
            else if(team == "BLUE")
            {
                Task<string> task = main.espService.postAsync(ip, "player", main.config.teamBlueColorCmd);
                return task;
            }
            else if (team == "RED")
            {
                Task<string> task = main.espService.postAsync(ip, "player", main.config.teamRedColorCmd);
                return task;
            }
            else
            {
                Task<string> task = main.espService.postAsync(ip, "player", color);
                return task;
            }
        }

        internal Task<string> setCommandPlayer(string command)
        {
            Task<string> task = main.espService.postAsync(ip, "player", command);
            return task;
        }

        internal async void getKills()
        {
            string newBufferStr = getBuffer().Result;
            string[] newBufferArr = newBufferStr.Split('K');
            List<string> newBuffer = new List<string>();
            bool setNewBuffer = false;
            foreach (string sub in newBufferArr)
                if(sub.Length >= 2)
                {
                    setNewBuffer = true;
                    newBuffer.Add(sub);
                }

            if (buffer == null) buffer = newBuffer;
            if (team == null) team = "SELF";

            if (buffer.Count < newBuffer.Count)
            {
                List<Material> killers = bufferToKillers(newBuffer, buffer.Count);

                death += killers.Count; 
                score -= main.scoreService.death * killers.Count;

                foreach (Material killer in killers) //main.materials.materials) // main.materials.materials)
                {
                    if (idlaser != killer.idlaser)
                    {
                        if (team == killer.team && (team.ToUpper() == "BLUE" || team.ToUpper() == "RED"))
                            killer.score -= main.scoreService.teamkill;
                        else
                        {
                            killer.score += main.scoreService.gunkill;
                            killer.kill += 1;
                        }
                    }
                    else
                    {
                        score -= main.scoreService.death;
                        score += main.scoreService.autokill;
                    }
                }
                if(setNewBuffer)
                    buffer = newBuffer;

            }
        }

        private List<Material> bufferToKillers(List<string> _resultOutput, int _withStartPosition)
        {
            List<Material> killers = new List<Material>();

            for (int i = _withStartPosition ; i < _resultOutput.Count; i++)
            {
                string id = "" + _resultOutput[i][0] + _resultOutput[i][1]; // erreur buffer pas terminé

                Material killer = findById(id);
                if (killer != null)
                {
                    killers.Add(killer);
                }
            }

            return killers;
        }

        private Material findById(string _id)
        {
            foreach (Material p in main.materials.materials)
            {
                if (_id == p.idlaser) return p;
            }
            return null;
        }

    }

}
