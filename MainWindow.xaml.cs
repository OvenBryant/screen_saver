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

using System.Windows.Threading;

namespace _02.屏幕保护程序
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();   // 运用定时器画直线
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //   Canvas容器的大小  570   443
            Random rnd = new Random();
            #region 坐标随机
                int _x1 = rnd.Next(570);
                int _y1 = rnd.Next(443);
                int _x2 = rnd.Next(570);
                int _y2 = rnd.Next(443);
            #endregion
            #region 颜色随机
                byte r = (byte)rnd.Next(255);
                byte g = (byte)rnd.Next(255);
                byte b = (byte)rnd.Next(255);
            #endregion

            Line line = new Line();
            line.X1 = _x1;
            line.Y1 = _y1;
            line.X2 = _x2;
            line.Y2 = _y2;
            line.Stroke = new SolidColorBrush(Color.FromRgb(r, g, b));  // 0~255
            line.StrokeThickness = 2;
            Can.Children.Add(line);
        }


        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Can.Children.Clear();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
