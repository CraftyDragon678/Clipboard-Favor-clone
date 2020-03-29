using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClipboardCavor
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Overlay : Window
    {
        public Overlay(String text, double left, double top)
        {
            InitializeComponent();

            str.Text = text;
            Left = left;
            Top = top;
        }

        private void TimerTick(object sender, EventArgs e) {
            DispatcherTimer timer1 = (DispatcherTimer)sender;
            timer1.Stop();
            timer1.Tick -= TimerTick;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper wndHelper = new WindowInteropHelper(this);

            int exStyle = (int)HookUtil.GetWindowLong(wndHelper.Handle, (int)HookUtil.GetWindowLongFields.GWL_EXSTYLE);

            exStyle |= (int)HookUtil.ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            HookUtil.SetWindowLong(wndHelper.Handle, (int)HookUtil.GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5d);
            timer.Tick += TimerTick;
            timer.Start();
        }
    }
}
