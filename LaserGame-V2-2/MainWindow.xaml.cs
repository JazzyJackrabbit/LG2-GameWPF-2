using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaserGame_V2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        internal MainService main;

        string teamGameComboText = "Team Game";
        string selfGameComboText = "Self Game";

        public PlayersGrid playersGrid;

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new();

        public MainWindow()
        {
            InitializeComponent();

            main = new MainService();

            _cb_timeBeforeStart.Items.Add("00:00:00"); _cb_timeBeforeStart.SelectedIndex = _cb_timeBeforeStart.Items.Count - 1;
            _cb_timeBeforeStart.Items.Add("00:00:15");
            _cb_timeBeforeStart.Items.Add("00:00:30");
            _cb_timeBeforeStart.Items.Add("00:00:45");
            _cb_timeBeforeStart.Items.Add("00:01:00");
            _cb_timeBeforeStart.Items.Add("00:01:30");
            _cb_timeBeforeStart.Items.Add("00:02:00");

            _cb_timeGame.Items.Add("00:00:02");
            _cb_timeGame.Items.Add("00:05:00");
            _cb_timeGame.Items.Add("00:10:00");
            _cb_timeGame.Items.Add("00:15:00"); _cb_timeGame.SelectedIndex = _cb_timeGame.Items.Count - 1;
            _cb_timeGame.Items.Add("00:20:00");
            _cb_timeGame.Items.Add("00:30:00");
            _cb_timeGame.Items.Add("00:45:00");
            _cb_timeGame.Items.Add("00:60:00");

            _cb_reanimationTime.Items.Add("0");
            _cb_reanimationTime.Items.Add("250");
            _cb_reanimationTime.Items.Add("500");
            _cb_reanimationTime.Items.Add("750");
            _cb_reanimationTime.Items.Add("1000");
            _cb_reanimationTime.Items.Add("1250");
            _cb_reanimationTime.Items.Add("1500");
            _cb_reanimationTime.Items.Add("1750");
            _cb_reanimationTime.Items.Add("2000"); 
            _cb_reanimationTime.Items.Add("2250");
            _cb_reanimationTime.Items.Add("2500"); _cb_reanimationTime.SelectedIndex = _cb_reanimationTime.Items.Count - 1;
            _cb_reanimationTime.Items.Add("2750");
            _cb_reanimationTime.Items.Add("3000");
            _cb_reanimationTime.Items.Add("3500");
            _cb_reanimationTime.Items.Add("4000");
            _cb_reanimationTime.Items.Add("4500");
            _cb_reanimationTime.Items.Add("5000");
            _cb_reanimationTime.Items.Add("6000");
            _cb_reanimationTime.Items.Add("7000");
            _cb_reanimationTime.Items.Add("8000");
            _cb_reanimationTime.Items.Add("9000");
            _cb_reanimationTime.Items.Add("10000");

            _cb_gameMode.Items.Add(teamGameComboText);
            _cb_gameMode.Items.Add(selfGameComboText); _cb_gameMode.SelectedIndex = _cb_gameMode.Items.Count - 1;

            _cb_playerTeam.IsEnabled = false;

            refreshNetwork();

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            dispatcherTimer.Start();

            _lb_playersPlayers.SelectedIndex = 0;

            setScore();

            main.materials.randomSelfs();

        }

        // Timer 250 ms
        private async void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            /* _lb_hotspotStatus.Content = 
             main.hotspot.hotspot.Status.ToString();

             displayPlayersGrid();*/

            if (!main.playing)
            {
                main.gameTimer.setTime(timeStrToTimeSpan(_cb_timeGame.Text));
                grid_total.Background = new SolidColorBrush(Color.FromRgb(
                    (byte)(255 * 0.4 / 2),
                    (byte)(255 * 0.5 / 2),
                    (byte)(255 * 0.7 / 2)
                    ));

                refreshPlayersGrid();
            }
            else
            {
                grid_total.Background = new SolidColorBrush(Color.FromRgb(
                  (byte)(255 * 0.2 / 2),
                  (byte)(255 * 0.8 / 2),
                  (byte)(255 * 0.2 / 2)
                  ));

                refreshPlayersGrid();
            }

            _lb_timergame.Content = TimeSpanTotimeStr(main.gameTimer.getTime());


        }

        


        private void _btn_addMaterialPlayer_Click(object sender, RoutedEventArgs e)
        {
            if(_lb_availableMaterials.SelectedIndex >= 0)
            {
                string selectedIp = _lb_availableMaterials.SelectedItem.ToString();
                addPlayer(selectedIp);
            }
        }

        private void _btn_rmvMaterialPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (_lb_materialPlayers.SelectedIndex >= 0)
            {
                string selectedIp = _lb_materialPlayers.SelectedItem.ToString();
                rmvPlayer(selectedIp);
            }
        }

        private void _btn_addMaterialAutomaticLaser_Click(object sender, RoutedEventArgs e)
        {

            Xceed.Wpf.Toolkit.MessageBox.Show("Not available yet.");
        }

        private void _btn_rmvMaterialAutomaticLaser_Click(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("Not available yet.");
        }

        private void _btn_addMaterialOther_Click(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("Not available yet.");
        }

        private void _btn_rmvMaterialOther_Click(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("Not available yet.");
        }

        private void _cb_timeBeforeStart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void _cb_timeGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (main.playing == false)
            main.gameTimer.setTime(timeStrToTimeSpan(_cb_timeGame.Text));
        }

        private void _cb_gameMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!main.playing)
                try
                {
                    _cb_playerTeam.IsEnabled = false;
                    _cb_playerTeam.Items.Clear();

                    main.materials.clearTeams();

                    _tb_playerColor.IsEnabled = true;
                    if (_cb_gameMode.SelectedItem.ToString()  == teamGameComboText)
                    {
                        _cb_playerTeam.IsEnabled = true;

                        _tb_playerColor.IsEnabled = false;
                        _tb_playerColor.Text = "";

                        _cb_playerTeam.Items.Add("BLUE");
                        _cb_playerTeam.Items.Add("RED"); _cb_playerTeam.SelectedIndex = _cb_playerTeam.Items.Count - 1;

                        _tb_playerColor.Text = main.config.teamRedColorCmd;

                        main.materials.randomTeams();

                    }
                    else
                    {
                        main.materials.randomSelfs();
                    }


                    refreshPlayersGrid();
                }
                catch
                {
                    _cb_playerTeam.IsEnabled = false;
                }
        }

        private void _tb_hotspot_ssid_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void _tb_hotspot_password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private async void refreshPlayersGrid()
        {
            // refresh
            playersGrid = new PlayersGrid(main, _lb_playersPlayers, _grid_playersTitle); 
            _lb_playersPlayers.ItemsSource = playersGrid.loadPlayers(main.materials);
        }

        private void setScore()
        {
            try
            {
                main.scoreService.set(
                    Convert.ToInt32(_tb_scoreKill.Text),
                    Convert.ToInt32(_tb_scoreDeath.Text),
                    Convert.ToInt32(_tb_scoreAutokill.Text),
                    Convert.ToInt32(_tb_scoreTeamKill.Text),
                    Convert.ToInt32(_tb_scoreKillGun.Text)
                );
            }
            catch
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Error");
            }

        }
        private void _btn_setScores_Click(object sender, RoutedEventArgs e)
        {
            setScore();
        }

        private void btn_startgame_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                main.start(timeStrToTimeSpan(_cb_timeGame.Text));

            }
            catch { }
        }

        private TimeSpan timeStrToTimeSpan(string timestr)
        {
            if (timestr != "")
            {
                int seconds = Convert.ToInt32(timestr.Split(':')[2]);
                int minuts = Convert.ToInt32(timestr.Split(':')[1]);
                int hours = Convert.ToInt32(timestr.Split(':')[0]);
                TimeSpan time = new(hours, minuts, seconds);
                return time;
            }
            return new TimeSpan(0);
        }
        private string TimeSpanTotimeStr(TimeSpan timespan)
        {
            string timestr = "";
            timestr += timespan.Hours.ToString().PadLeft(2, '0') + ":";
            timestr += timespan.Minutes.ToString().PadLeft(2, '0') + ":";
            timestr += timespan.Seconds.ToString().PadLeft(2, '0');
            return timestr;
        }

        private void btn_stopgame_Click(object sender, RoutedEventArgs e)
        {
            main.stop();

            _lb_playersPlayers.SelectedIndex = 0;
        }

        private void _btn_refreshMaterials_Click(object sender, RoutedEventArgs e)
        {
            refreshMaterials();
        }

        private void refreshMaterials(bool playersToo = false)
        {
            int numMaterialsMin = Convert.ToInt32(_tb_nMaterialsMin.Text);
            int numMaterialsMax = Convert.ToInt32(_tb_nMaterialsMax.Text);
            int timeoutScan = Convert.ToInt32(_tb_scantimeout.Text);

            List<string> ips = main.network.getClients(numMaterialsMin, numMaterialsMax, timeoutScan);


            _lb_availableMaterials.Items.Clear();
            foreach (string ip in ips)
                _lb_availableMaterials.Items.Add(ip);

            if (playersToo)
            {
                foreach (string ip in ips)
                    addPlayer(ip);
            }
        }

        private void _btn_setPlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Material selectedPlayer = main.materials.getSelectedMaterial();
                PlayerEUC playerEUC;
                if (selectedPlayer != null) { 
                    selectedPlayer.pseudo = _tb_playerPseudo.Text;
                    selectedPlayer.color = _tb_playerColor.Text;
                    selectedPlayer.team = _cb_playerTeam.Text;

                    refreshPlayersGrid();

                    _tb_playerPseudo.Text = "";

                    selectedPlayer.setColor(true);

                    main.materials.selectNextMaterialInList(selectedPlayer);
                }
            }
            catch { }
        }

        private async void addPlayer(string ip)
        {
            Material createdMaterial = main.materials.createMaterial(ip, MaterialType.Player);
            if (createdMaterial != null) {

                // idLaser
                createdMaterial.getIdLaser().ToString();

                _lb_materialPlayers.Items.Add(ip);

                // refresh
                refreshPlayersGrid();

            }

        }

        private void rmvPlayer(string ip)
        {
            main.materials.removeMaterial(ip);
            _lb_materialPlayers.Items.Remove(ip);

            // refresh
            refreshPlayersGrid();

        }

        /* private void displayPlayersGrid()
         {
             _dg_playersPlayers.IsReadOnly = true;
             if (playersGrid == null)
             {
                 playersGrid = new PlayersGrid();
                 _dg_playersPlayers.ItemsSource = playersGrid.loadPlayers(main.materials);
             }
         }*/



        private void _btn_refreshNetwork_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                refreshNetwork();
            }
            catch { }
        }


        public bool initNetwork = true;
        private void refreshNetwork()
        {

            var networks = main.network.getNetworks();
            _cb_network.Items.Clear();

            foreach (var network in networks)
                _cb_network.Items.Add(network.Item2);

            if (initNetwork)
            {
                foreach (var network in networks)
                    if (network.Item3.ToString() == main.config.defaultIpAddrHotspot) 
                    {
                        _cb_network.SelectedItem = network.Item2;

                        refreshMaterials(true);


                        initNetwork = false;

                    }
            }

        }

        private void _cb_network_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
                int index = _cb_network.SelectedIndex;
                var network = main.network.networks[index];
                main.network.lastNetworkUser = network;
            }
            catch {
                main.network.lastNetworkUser = null;
            }
        }

        private void _btn_virtualRouterOpen_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("./MarsWifi/marswifi.exe");
        }

        private void _btn_virtualRouterPass_Click(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show("passwd00");
        }

        private void _btn_setPlayerColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dlg = new();

            // mapinfo color: https://www.tydac.ch/color/  (red = blue ; blue = red)
            int IV1 = 127;
            int IV2 = 255;
            dlg.CustomColors = new int[]{
            1*IV1, 256*IV1, 65536*IV1, 257*IV1, 65537*IV1, 65792*IV1, 65793*IV1, 0,
            1*IV2, 256*IV2, 65536*IV2, 257*IV2, 65537*IV2, 65792*IV2, 65793*IV2, 0,
            };

            float multiplicatorLightness = main.config.multiplicatorLightness;;

            dlg.ShowDialog();
            System.Drawing.Color clr = dlg.Color;

            ColorGun cg = new(new RGB(clr.R, clr.G, clr.B));
            string clrcmd = cg.getColorStringCmd(multiplicatorLightness);

            _btn_setPlayerColor.Background = cg.getColorBrush(clrcmd, 1 / multiplicatorLightness);

            _tb_playerColor.Text = clrcmd;

            refreshPlayersGrid();
        }

        private void _cb_playerTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(_cb_playerTeam.Text == "RED")
            {
                _tb_playerColor.Text = main.config.teamRedColorCmd;
            }
            else if(_cb_playerTeam.Text == "BLUE")
            {
                _tb_playerColor.Text = main.config.teamBlueColorCmd;
            }
        }

        private void _cb_reanimationTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                int ms = Convert.ToInt32(_cb_reanimationTime.SelectedValue.ToString());
                string command = "T" + (ms / 250).ToString().PadLeft(2, '0');

                main.materials.commandPlayer(command);
            }
            catch { }
        }
    }
}
