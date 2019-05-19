using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LegionStats
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PlayerNameToAdd.Text))
            {
                PlayersList.Items.Add(PlayerNameToAdd.Text);
                PlayerNameToAdd.Text = string.Empty;

            }

        }

        private void GetPlayersInfo(object sender, RoutedEventArgs e)
        {
            if (PlayersList.Items.Count > 0)
            {
                foreach (var player in PlayersList.Items)
                {
                    var result = postPlayerInfo(player.ToString());

                }
            }

        }

        private Result postPlayerInfo(string playerName)
        {

            Result ret = new Result();




            return ret;
        }
    }
}
