using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserGame_V2_2
{
    public class Materials
    {
        MainService main;
        public List<Material> materials = new List<Material>();

        public Materials(MainService main)
        {
            this.main = main;
        }

        public Material createMaterial(string ip, MaterialType _type)
        {
            if(getMaterial(ip) == null) { 
                Material player = new Material(main, _type, ip);
                materials.Add(player);
                return player;
            }
            return null;
        }

        public void removeMaterial(string ip)
        {
            Material toRemove = null;
            foreach(var material in materials)
            {
                if (material.ip == ip) toRemove = material;
            }
            materials.Remove(toRemove);
        }

   
        public bool containsMaterial(string ip)
        {
            foreach (var material in materials)
                if (material.ip == ip) return true;
            return false;
        }

        public Material getMaterial(string ip)
        {
            foreach (var material in materials)
                if (material.ip == ip) return material;
            return null;
        }

        internal void clearTeams()
        {
            foreach (var material in materials)
            {
                material.team = "";
            }
        }

        internal void randomTeams()
        {
            bool switchTeam = true;
            foreach (var material in materials)
            {
                material.color = "";

                if (switchTeam)
                {
                    material.team = "BLUE";
                    material.color = main.config.teamBlueColorCmd;
                    switchTeam = false;
                }
                else if (!switchTeam)
                {
                    material.team = "RED";
                    material.color = main.config.teamRedColorCmd;
                    switchTeam = true;
                }

                material.setColor(true);
            }
        }

        internal void randomSelfs()
        {
            int switchColorSelf = 0;
            foreach (var material in materials)
            {
                material.color = "";

                switch (switchColorSelf)
                {
                    case 0: material.color = main.config.player1; break;
                    case 1: material.color = main.config.player2; break;
                    case 2: material.color = main.config.player3; break;
                    case 3: material.color = main.config.player4; break;
                    case 4: material.color = main.config.player5; break;
                    case 5: material.color = main.config.player6; break;
                    case 6: material.color = main.config.player7; break;
                    case 7: material.color = main.config.player8; break;
                    case 8: material.color = main.config.player9; break;
                    default: material.color = main.config.playerElse; break;
                }
               
                switchColorSelf++;
                material.setColor(true);
            }
        }


        internal void stop()
        {
            foreach (Material material in materials)
                material.Stop();
        }

        internal void start()
        {
            foreach (Material material in materials)
                material.Start();
        }

        internal void setcolor(bool enable = true)
        {
            foreach (Material material in materials)
                material.setColor(enable);
        }

        internal void commandPlayer(string command)
        {
            foreach (Material material in materials)
                material.setCommandPlayer(command);
        }

        internal async void getKills()
        {
            foreach (Material material in materials)
                material.getKills();
        }

        internal Material getSelectedMaterial()
        {
            foreach (var material in materials)
                if (material.uiPlayer.isSelected) return material;
            return null;
        }

        internal Material selectNextMaterialInList(Material fromMaterial)
        {
            var material = getNextMaterialInList(fromMaterial);
            if (material == null)
            {
                fromMaterial.uiPlayer.selectPlayer();
                return null;
            }
            material.uiPlayer.selectPlayer();
            return material;
        }
        internal Material getNextMaterialInList(Material fromMaterial)
        {
            if (materials.Contains(fromMaterial))
            {
                int i = materials.IndexOf(fromMaterial);
                if (i + 1 < materials.Count)
                    return materials[i + 1];
            }
            return null;
        }
    }
}
