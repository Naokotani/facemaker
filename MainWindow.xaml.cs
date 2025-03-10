using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class MainWindow : Window
    {
        Page namePage;
        ViewModel model { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            model = new ViewModel();
            this.DataContext = model;
            namePage = new PeoplePage(MainFrame);
            MainFrame.Navigate(namePage);
            model.occupation = "Dentist";
            model.hobby = "Golf";
            DataAccess dataAccess = new DataAccess();
            dataAccess.populateHobbyTable();
            dataAccess.populateOccupationTable();
        }

        private void OpenHelpPage_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://naokotani.github.io/",
                UseShellExecute = true
            });
        }


    }
    }
