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
        Game game = new Game(5, 5); //INICJALIZACJA GRY MOŻNA ZMIENIC DLUGOSC STATKOW I ICH ILOSC

        public MainWindow()
        {
            InitializeComponent();

            game.setShips();
            System.Diagnostics.Debug.WriteLine("Udało się");


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int whatHappened = game.handleClient(button.Name);

            switch (whatHappened)
            {
                case 1:
                    textBlock.Text = "Brawo - trafiłeś!! Strzelaj dalej";
                    button.Background = Brushes.Green;
                    break;
                case 0:
                    textBlock.Text = "Pudło [*], spróbuj jeszcze raz";
                    button.Background = Brushes.Orange;
                    break;
                case -1:
                    break;
            }
            if (game.isOver())
            {
                textBlock.Text = "GRATKI WYGRAŁEŚ W: " + game.RoundNumber;

            }

        }

    }
}
