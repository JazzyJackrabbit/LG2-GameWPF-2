using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LaserGame_V2_2
{
    public class PlayersGrid
    {
        MainService main;
        ListBox listBox;
        Grid gridTitle;

        public List<PlayerEUC> players = new();

        public PlayersGrid(MainService main, ListBox listBox, Grid gridTitle)
        {
            this.main = main;
            this.listBox = listBox;
            this.gridTitle = gridTitle;

            gridTitle.Children.Add(new PlayerEUC(this, true));
        }

        public List<PlayerEUC> loadPlayers(Materials materials)
        {

            players = new List<PlayerEUC>();

            foreach (var material in materials.materials)
                if (material.type == MaterialType.Player)
                {
                    PlayerEUC playerGrid = new(this, false);

                    refreshPlayer(playerGrid, material);

                    if (playerGrid != null) players.Add(playerGrid);

                }
            return players;
        }

        public List<PlayerEUC> actuPlayers(List<PlayerEUC> currentPlayersGrid, Materials materials)
        {
            
            // todo recheck
            if (materials.materials.Count > players.Count)
            {
                currentPlayersGrid = loadPlayers(materials);
            }
            if (materials.materials.Count < players.Count && players.Count > 0)
            {
                currentPlayersGrid = loadPlayers(materials);
            }

            return currentPlayersGrid;
           
        }
        public void refreshPlayer(PlayerEUC playerEUC, Material material)
        {
            playerEUC.player = material;

            playerEUC.lb1_ip.Content = material.ip;
            playerEUC.lb2_id.Content = material.idlaser;
            playerEUC.lb3_pseudo.Content = material.pseudo;
            playerEUC.lb4_team.Content = material.team;
            playerEUC.lb5_color.Content =  material.color;
            playerEUC.lb5_color.Foreground = new ColorGun(material.color).getColorBrush(material.color);
            playerEUC.grid_background.Background = new ColorGun(material.color).getColorBrush(material.color, 1 / main.config.multiplicatorLightness);
            playerEUC.lb7_death.Content = material.death;
            playerEUC.lb6_kill.Content = material.kill;
            playerEUC.lb8_score.Content = material.score;

            if (material.uiPlayer.isSelected)
                playerEUC.grid_infos.Background = playerEUC.selectBackgroundInfo;
            else
                playerEUC.grid_infos.Background = playerEUC.normalBackgroundInfo;
        }

    }

}
