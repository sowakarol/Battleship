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

namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game(5, 5);

        public MainWindow()
        {
            InitializeComponent();
            game.setShips();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            System.Diagnostics.Debug.WriteLine(button.Name);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
