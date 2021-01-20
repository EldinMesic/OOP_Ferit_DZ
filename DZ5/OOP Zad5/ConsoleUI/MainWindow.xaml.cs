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
using OOP_Zad5;
namespace ConsoleUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Show mainShow = new Show();
        List<Episode> episodes = new List<Episode>();
        int index=-1;
        int flag = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            mainShow = Utilities.LoadFromAPI(SearchBox.Text);

            DescriptionBlock.Text = mainShow.ToString();
            SeasonPicker.SelectedItem = "Season 1";
            episodes = mainShow.GetEpisodes(1);
            EpisodeBox.ItemsSource = episodes;
            Imagebox.Source = new BitmapImage(new Uri(mainShow.image.Original, UriKind.Absolute));

            int number = SeasonPicker.Items.Count;
            for(int i=2; i <= number; i++)
            {
                SeasonPicker.Items.Remove($"Season {i}");
            }
            int counter = 0;
            foreach(var season in mainShow.Seasons)
            {
                counter++;
                if (flag == 1 && counter == 1) { }
                else
                    SeasonPicker.Items.Add($"Season {counter}");
                
                    
            }
            flag = 1;

            SeasonPicker.Items.Refresh();
            EpisodeBox.Items.Refresh();
            SearchBox.Clear();
        }


        private void SeasonPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index = int.Parse(SeasonPicker.SelectedItem.ToString().Remove(0, 7));

            episodes = mainShow.GetEpisodes(index);
            EpisodeBox.ItemsSource = episodes;
            EpisodeBox.Items.Refresh();

        }

        private void EpisodeBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Episode episode = EpisodeBox.SelectedItem as Episode;
            string message = $"{episode.Name}\n\n{episode.Summary}";
            MessageBox.Show(message);
        }
    }
}
