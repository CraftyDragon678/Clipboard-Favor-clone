using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClipboardCavor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String formerText;
        double left;
        double top;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var windowCM = new ClipboardManager(this);
            windowCM.ClipboardChanged += OnClipboardChange;

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = 400;
            double windowHeight = 150;

            left = (screenWidth - windowWidth) / 2;
            top = screenHeight - windowHeight - 100;
        }

        private void OnClipboardChange(object sender, EventArgs e)
        {
            /*Thread thread = new Thread(() =>
            {
                if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();
                    if (formerText != text || true)
                    {
                        formerText = text;
                        Debug.WriteLine(text);

                        Overlay win = new Overlay(formerText, left, top);
                        *//*win.Dispatcher.Invoke(delegate { 
                            win.Show();
                            Thread.Sleep(5000);
                            win.Close();
                        });*//*
                        win.Dispatcher.Invoke(() => win.Show());
                        Thread.Sleep(5000);
                        win.Dispatcher.Invoke(() => win.Close());

                        *//*win.Dispatcher.Invoke(delegate { win.Close(); });*//*
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();*/

            Thread thread = new Thread(() =>
            {
                if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();
                    if (formerText != text)
                    {
                        formerText = text;
                        Debug.WriteLine(text);

                        Dispatcher.Invoke(() => { 
                            Overlay win = new Overlay(formerText, left, top);
                            win.Show(); 
                        });
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
