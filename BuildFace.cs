using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace M01_First_WPF_Proj
{

    public class BuildFace
    {

        private Canvas _mainCanvas;
        private CheckBox hatCheck;
        private CheckBox hairCheck;
        private CheckBox spikeCheck;
        private Slider eyeSlider;
        private ComboBox noseCombo;
        private RadioButton mouth1;
        private RadioButton mouth2;
        private RadioButton mouth3;
        private ViewModel model;
        /// <summary>
        /// One place where commands can be called from keybindings, 
        /// Menu, or Controls.
        /// 
        /// Also, this code can be (could be) unit tested....or call something 
        /// that can be unit tested.
        /// </summary>

        public BuildFace(Canvas mainCanvas, Frame MainFrame) {
            _mainCanvas = mainCanvas;
            if(model != null)
            {
                model = MainFrame.DataContext as ViewModel;
            }
            hatCheck = (CheckBox)_mainCanvas.FindName("hatCheck");
            hairCheck = (CheckBox)_mainCanvas.FindName("hairCheck");
            spikeCheck = (CheckBox)_mainCanvas.FindName("spikeCheck");
            eyeSlider = (Slider)_mainCanvas.FindName("slider1");
            noseCombo = (ComboBox)_mainCanvas.FindName("comboTest");
            mouth1 = (RadioButton)_mainCanvas.FindName("mouth1");
            mouth2 = (RadioButton)_mainCanvas.FindName("mouth2");
            mouth3 = (RadioButton)_mainCanvas.FindName("mouth3");
        }

public string hair(object param)
{
    var path = $"pack://application:,,,/images/hair{param}.png";
    if(model != null)
    {
        model.hair = path;
    }
    placeImage(300, 145, path);
    return path;
}

public string eyes(object param)
{
    var path = $"pack://application:,,,/images/eyes{param}.png";
    if(model != null)
    {
        model.eyes = path;
    }
    placeImage(300, 300, path);
    return path;
}

public string nose(object param)
{
    var path = $"pack://application:,,,/images/nose{param}.png";
    if(model != null)
    {
        model.nose = path;
    }
    placeImage(300, 360, path);
    return path;
}

public string mouth(object param)
{
    var path = $"pack://application:,,,/images/mouth{param}.png";
    if(model != null)
    {
        model.mouth = path;
    }
    placeImage(300, 425, path);
    return path;
}

private void placeImage(int x, int y, string path)
{
    BitmapImage bm = new BitmapImage(new Uri(path, UriKind.Absolute));

            Image img = new Image();

            img.Source = bm;
            img.Width = bm.Width;
            img.Height = bm.Height;

            Canvas.SetLeft(img, x);
            Canvas.SetTop(img, y);
            
            _mainCanvas.Children.Add(img);
        }
    }
}
