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
        public static double delta = 10;
        Image Gup_B;

        public MainWindow()
        {
            InitializeComponent();
            Gup_B = new Image { Width=100, Height=100};
            Gup_B.Source = new BitmapImage(new Uri("/gup_b_right_trans.png", UriKind.Relative));
            mainCanvas.Children.Add(Gup_B);
            mainCanvas.Background = Brushes.Blue;
            Canvas.SetLeft(Gup_B, 50);
            Canvas.SetTop(Gup_B, 50);
            ///MainWindow.KeyDownEvent += MainWindowGetKey;
        }

        public void MainWindowGetKey(object sender, KeyEventArgs e) {
            if (Keyboard.IsKeyDown(Key.Up))
            {
                if (Keyboard.IsKeyDown(Key.Left))
                    MoveObject(Gup_B, "nw");
                else if (Keyboard.IsKeyDown(Key.Right))
                    MoveObject(Gup_B, "ne");
                else
                    MoveObject(Gup_B, "n");
            }
            else if (Keyboard.IsKeyDown(Key.Down))
            {
                if (Keyboard.IsKeyDown(Key.Left))
                    MoveObject(Gup_B, "sw");
                else if (Keyboard.IsKeyDown(Key.Right))
                    MoveObject(Gup_B, "se");
                else
                    MoveObject(Gup_B, "s");
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                if (Keyboard.IsKeyDown(Key.Up))
                    MoveObject(Gup_B, "ne");
                else if (Keyboard.IsKeyDown(Key.Down))
                    MoveObject(Gup_B, "se");
                else
                    MoveObject(Gup_B, "e");

            }
            else if (Keyboard.IsKeyDown(Key.Left))
            {
                if (Keyboard.IsKeyDown(Key.Up))
                    MoveObject(Gup_B, "nw");
                else if (Keyboard.IsKeyDown(Key.Down))
                    MoveObject(Gup_B, "sw");
                else
                    MoveObject(Gup_B, "w");
            }
            else
                ;
        }

        private static void MoveObject(Object o, string direction)
        {
            Image e = (Image)o;

            double pos = 0;
            double top = 0;
            double left = 0;
            Point p;
            switch (direction)
            {
                case "n":
                    pos = Canvas.GetTop(e);
                    Canvas.SetTop(e, pos - delta);
                    break;

                case "ne":
                    top = Canvas.GetTop(e);
                    left = Canvas.GetLeft(e);
                    Canvas.SetTop(e, top - delta);
                    Canvas.SetLeft(e, left + delta);
                    break;

                case "e":
                    pos = Canvas.GetLeft(e);
                    Canvas.SetLeft(e, pos + delta);
                    break;

                case "se":
                    top = Canvas.GetTop(e);
                    left = Canvas.GetLeft(e);
                    Canvas.SetTop(e, top + delta);
                    Canvas.SetLeft(e, left + delta);
                    break;

                case "s":
                    pos = Canvas.GetTop(e);
                    Canvas.SetTop(e, pos + delta);
                    break;

                case "sw":
                    top = Canvas.GetTop(e);
                    left = Canvas.GetLeft(e);
                    Canvas.SetTop(e, top + delta);
                    Canvas.SetLeft(e, left - delta);
                    break;

                case "w":
                    pos = Canvas.GetLeft(e);
                    Canvas.SetLeft(e, pos - delta);
                    break;

                case "nw":
                    top = Canvas.GetTop(e);
                    left = Canvas.GetLeft(e);
                    Canvas.SetTop(e, top - delta);
                    Canvas.SetLeft(e, left - delta);
                    break;
            }
            //CombinedGeometry g = new CombinedGeometry(e, StationaryEllipse);
            // EllipseGeometry eg1 = new EllipseGeometry(e);
            // EllipseGeometry eg2 = new EllipseGeometry(StationaryEllipse);
            // if (e.IntersectsWith)
            if (e.Name == "StationaryEllipse")
                return;

            Rect r1 = new Rect(Canvas.GetLeft(e), Canvas.GetTop(e), e.Width, e.Height);
            //Rect r2 = new Rect(Canvas.GetLeft(StationaryEllipse), Canvas.GetTop(StationaryEllipse), StationaryEllipse.Width, StationaryEllipse.Height);
            //EllipseGeometry eg1 = new EllipseGeometry(r1);
            //EllipseGeometry eg2 = new EllipseGeometry(r2);
            //CombinedGeometry g = new CombinedGeometry(eg1, eg2);
            //g.GeometryCombineMode = GeometryCombineMode.Intersect;
            //if (double.IsInfinity(g.Bounds.Bottom) ||
            //        double.IsInfinity(g.Bounds.Left) ||
            //        double.IsInfinity(g.Bounds.Right) ||
            //        double.IsInfinity(g.Bounds.Top))   // NOTE:  this will not calculate if StationaryEllipse == e
            //    StationaryEllipse.Fill = Brushes.Aquamarine;
            //else
            //{
            //    StationaryEllipse.Fill = Brushes.Red;
            //    MoveObject(StationaryEllipse, direction);
            //}

            ////rectreasure;
            //Rect r = new Rect() { Width = treasure.Width, Height = treasure.Height, X = Canvas.GetLeft(treasure), Y = Canvas.GetTop(treasure) };
            //RectangleGeometry treasureGeometry = new RectangleGeometry(r);
            //CombinedGeometry g2 = new CombinedGeometry(eg1, treasureGeometry);

            /*
             * The above code gets an infinite vector if there's a geometry intersection otherwise the vector is finite?  Need more info....
             */
            //var a = 2;
            //g2.GeometryCombineMode = GeometryCombineMode.Intersect;
            //if (double.IsInfinity(g2.Bounds.Bottom) ||
            //        double.IsInfinity(g2.Bounds.Left) ||
            //        double.IsInfinity(g2.Bounds.Right) ||
            //        double.IsInfinity(g2.Bounds.Top))
            //{
            //    treasure.Fill = Brushes.Yellow;
            //    //mainCanvas.Children;
            //    var kids = mainCanvas.Children;
            //    for (int i = 0; i < mainCanvas.Children.Count; i++)
            //    {
            //        UIElement ui = mainCanvas.Children[i];
            //        if (ui.GetType().Name == "Image")
            //        {
            //            Image im = (Image)ui;
            //            if (im.Name == "gups")
            //            {
            //                mainCanvas.Children.RemoveAt(i);
            //            }
            //        }
            //    }
            //}

            //else
            //{
            //    treasure.Fill = Brushes.Orange;
            //    Image i = new Image();
            //    i.Name = "gups";
            //    i.Source = new BitmapImage(new Uri("/gups.jpg", UriKind.Relative));
            //    mainCanvas.Children.Add(i);
            //    Canvas.SetTop(i, 100);
            //    Canvas.SetLeft(i, 100);
            //}

        }


    }
}
