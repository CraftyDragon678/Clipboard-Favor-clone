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

namespace ClipboardCavor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String formerText;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var windowCM = new ClipboardManager(this);
            windowCM.ClipboardChanged += OnClipboardChange;
        }

        private void OnClipboardChange(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                if (Clipboard.ContainsText())
                {
                    String text = Clipboard.GetText();
                    if (formerText != text)
                    {
                        formerText = text;
                        Debug.WriteLine(text);

                        Overlay win = new Overlay(formerText);
                        win.Dispatcher.Invoke(new Action(() => win.Show()));
                        Thread.Sleep(5000);
                        win.Dispatcher.Invoke(new Action(() => win.Close()));
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
