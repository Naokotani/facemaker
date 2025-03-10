using System;
using System.Collections.Generic;
using System.IO;
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

    public partial class FacePage : Page
    {
        public CommandHandler hairCMD; 
        public CommandHandler eyesCMD; 
        public CommandHandler noseCMD;
        public CommandHandler mouthCMD;
        private Frame _MainFrame;
        public ViewModel model { get; set; }
        public FacePage(Frame MainFrame)
        {
            InitializeComponent();
            _MainFrame = MainFrame;
            model = _MainFrame.DataContext as ViewModel;
            BuildFace buildFace = new BuildFace(myCanvas, _MainFrame);
            
            // Initialize with instantiated object
            hairCMD = new CommandHandler(param => model.hair = buildFace.hair(param), true);
            eyesCMD = new CommandHandler(param => model.eyes = buildFace.eyes(param), true);
            noseCMD = new CommandHandler(param => model.nose = buildFace.nose(param), true);
            mouthCMD = new CommandHandler(param => model.mouth = buildFace.mouth(param), true);

            DataContext = new
            {
                hair = hairCMD,
                eyes = eyesCMD,
                nose = noseCMD,
                mouth = mouthCMD,
            };

            // Key Bindings
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.hair("1"), true), new KeyGesture(Key.F1, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.hair("2"), true), new KeyGesture(Key.F2, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.hair("3"), true), new KeyGesture(Key.F3, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.eyes("1"), true), new KeyGesture(Key.F4, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.eyes("2"), true), new KeyGesture(Key.F5, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.eyes("3"), true), new KeyGesture(Key.F6, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.nose("1"), true), new KeyGesture(Key.F7, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.nose("2"), true), new KeyGesture(Key.F8, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.nose("3"), true), new KeyGesture(Key.F9, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.mouth("1"), true), new KeyGesture(Key.F10, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.mouth("2"), true), new KeyGesture(Key.F11, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(new CommandHandler(param => buildFace.mouth("3"), true), new KeyGesture(Key.F12, ModifierKeys.None)));

            model.hair = buildFace.hair("1");
            model.eyes = buildFace.eyes("1");
            model.nose = buildFace.nose("1");
            model.mouth = buildFace.mouth("1");
        }

        /// <summary>
        /// Random Number generator for line positions.
        /// </summary>
        Random random = new Random();

        public void PlaceImage(int x, int y, string path)
        {
            // Need to create a new image every time we place a copy on the canvas
            var img = new Image();

            var bmimg = new BitmapImage(new Uri(path, UriKind.Relative));

            // Minimum image attributes
            img.Source = bmimg;
            img.Width = bmimg.Width;  // exception if images not copied down
            img.Height = bmimg.Height;

            // Attach to canvas in position
            Canvas.SetLeft(img, x);
            Canvas.SetTop(img, y);
            myCanvas.Children.Add(img);
        }

        private void eyes_slider(object sender, RoutedEventArgs e)
        {
            BuildFace buildFace = new BuildFace(myCanvas, _MainFrame);
            Slider slider = sender as Slider;
            object value = (object)slider.Value;
            buildFace.eyes(value.ToString());
        }

        private void nose_combo(object sender, RoutedEventArgs e)
        {
            BuildFace buildface = new BuildFace(myCanvas, _MainFrame);
            ComboBox cb = sender as ComboBox;
            int selection = cb.SelectedIndex + 1;
            buildface.nose((object)selection.ToString());
        }

        private void random_face(object sender, RoutedEventArgs e)
        {
            BuildFace buildFace = new BuildFace(myCanvas, _MainFrame);
            int hair = random.Next(1, 4);
            int eyes = random.Next(1, 4);
            int nose = random.Next(1, 4);
            int mouth = random.Next(1, 4);

            model.hair = buildFace.hair(hair.ToString());
            model.nose = buildFace.eyes(eyes.ToString());
            model.nose = buildFace.nose(nose.ToString());
            model.mouth = buildFace.mouth(mouth.ToString());
        }

        private void save_face(object sender, RoutedEventArgs e)
        {
            var db = new DataAccess();
            db.AddPerson(model);
            this.NavigationService.Navigate(new PeoplePage(_MainFrame));
        }

        private void prev_click(object sender, RoutedEventArgs e)
        {
            _MainFrame.Navigate(new Occupation(_MainFrame));
        }

        private void reset()
        {
            model.occupation = "Dentist";
            model.hobby = "Golf";
            model.pet = null;
            model.eyes = null;
            model.nose = null;
            model.mouth = null;
            model.hair = null;
            model.address = "";
            model.lName = "";
            model.fName = "";
            _MainFrame.Navigate(new NamePage(_MainFrame));
        }

        private void cancel_face(object sender, RoutedEventArgs e)
        {
            reset();
        }
    }
}
