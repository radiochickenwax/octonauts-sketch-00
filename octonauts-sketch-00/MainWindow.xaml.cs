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

namespace octonauts_sketch_00
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Image Gup_B = new Image { Width=100, Height=100};
            Gup_B.Source = new BitmapImage(new Uri("/gup_b_right_trans.png", UriKind.Relative));
            mainCanvas.Children.Add(Gup_B);
            mainCanvas.Background = Brushes.Blue;
            Canvas.SetLeft(Gup_B, 50);
            Canvas.SetTop(Gup_B, 50);
        }
    }
}
