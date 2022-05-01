
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaserGame_V2_2
{
    /// <summary>
    /// Logique d'interaction pour PlayerElmtUserControl.xaml
    /// </summary>
    public partial class PlayerEUC : UserControl
    {
        PlayersGrid parent;
        internal Material player { get; set; }

        internal bool isSelect { get; set; }
        internal SolidColorBrush selectBackgroundInfo { get; set; }
        internal SolidColorBrush normalBackgroundInfo { get; set; }

        public PlayerEUC(PlayersGrid parent, bool _isTitle)
        {
            this.parent = parent;
            InitializeComponent();

            normalBackgroundInfo = Brushes.Transparent;
            selectBackgroundInfo = new SolidColorBrush(Color.FromArgb(255, 100, 232, 100));

            if (_isTitle)
            {
                grid_background.Background = System.Windows.Media.Brushes.White;
            }
            else
            {
                int fontWeight = 8;
                grid_infos.Background = normalBackgroundInfo;
                lb1_ip.FontStretch = FontStretch.FromOpenTypeStretch(fontWeight);
                lb2_id.FontStretch = FontStretch.FromOpenTypeStretch(fontWeight);
                lb3_pseudo.FontStretch = FontStretch.FromOpenTypeStretch(fontWeight);
                lb4_team.FontStretch = FontStretch.FromOpenTypeStretch(fontWeight);
                lb5_color.FontStretch = FontStretch.FromOpenTypeStretch(fontWeight);
                lb6_kill.FontStretch = FontStretch.FromOpenTypeStretch(fontWeight);
                lb7_death.FontStretch = FontStretch.FromOpenTypeStretch(fontWeight);
                lb8_score.FontStretch = FontStretch.FromOpenTypeStretch(fontWeight);
            }

        }

        private void grid_infos_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(player != null)
                player.uiPlayer.selectPlayer();
        }
    }
}
