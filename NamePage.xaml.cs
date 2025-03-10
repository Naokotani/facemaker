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
    /// <summary>
    /// Interaction logic for NamePage.xaml
    /// </summary>
    public partial class NamePage : Page
    {
        Frame _MainFrame;
        ViewModel model {  get; set; }
        public NamePage(Frame MainFrame)
        {
            InitializeComponent();
            _MainFrame = MainFrame;
            model = MainFrame.DataContext as ViewModel;
            lNameText.Text = model.lName;
            fNameText.Text = model.fName;
            addressText.Text = model.address;
        }
        private void next_click(object sender, RoutedEventArgs e)
        {
            model.lName = lNameText.Text;
            model.fName = fNameText.Text;
            model.address = addressText.Text;
            _MainFrame.Navigate(new Occupation(_MainFrame));
        }
    }
}
