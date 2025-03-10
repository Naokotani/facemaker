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

namespace M01_First_WPF_Proj
{
    public partial class Occupation: Page
    {
        Frame _MainFrame;
        ViewModel model { get; set; }
        public CommandHandler occupationCMD; 
        public CommandHandler hobbyCMD; 
        public CommandHandler petCMD;
        public Occupation(Frame MainFrame)
        {
            InitializeComponent();
            _MainFrame = MainFrame;
            model = MainFrame.DataContext as ViewModel;

            var details = new PersonalDetails();

            petCMD = new CommandHandler(param => model.pet = details.getCommandString(param), true);

            occupationCombo.Text = model.occupation;   

            hobbyCombo.Text = model.hobby;   

            DataContext = new
            {
                occupation = occupationCMD,
                hobby = hobbyCMD,
                pet = petCMD,
            };

            if (model.pet == "Cats")
            {
                catRadio.IsChecked = true;
                dogRadio.IsChecked= false;
            } else
            {
                dogRadio.IsChecked = true;
                catRadio.IsChecked = false;
            }
        }

        private void hobby_combo(object sender, RoutedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            var hobby = cb.SelectedIndex;
            if(model != null)
            {
                model.hobby = parseHobby(hobby);
            }
        }

        private void occupation_combo(object sender, RoutedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            var occupation = cb.SelectedIndex;
            if (model != null)
            {
                model.occupation = parseOccupation(occupation);
            }
        }

        private void next_click(object sender, RoutedEventArgs e)
        {
            _MainFrame.Navigate(new FacePage(_MainFrame));
        }

        private void prev_click(object sender, RoutedEventArgs e)
        {
            _MainFrame.Navigate(new NamePage(_MainFrame));
        }

        private string parseOccupation(int index)
        {
            switch (index)
            {
                case 0:
                    return "Denist";
                case 1:
                    return "Miner";
                default:
                    return "Circus Performer";
            }
        }

        private string parseHobby(int index)
        {
            switch (index)
            {
                case 0:
                    return "Golf";
                case 1:
                    return "Cards";
                default:
                    return "Sailing";
            }
        }
    }
}
