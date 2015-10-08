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
using System.Diagnostics;

namespace CordovaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Session CurrentSession;
        // public Project CurrentProject;

        public MainWindow()
        {
            InitializeComponent();

            image.Click += Image_Click;
            newProject.Click += NewProject_Click;
            openProject.Click += OpenProject_Click;
            buildProject.Click += BuildProject_Click;
            cordovaPlugins.Click += CordovaPlugins_Click;
            updateCordova.Click += UpdateCordova_Click;



        }
        public void submitCMD(string pgm, string args, bool show)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            if (!show)
            {
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }
            else
            {
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            }
            startInfo.FileName = pgm;
            startInfo.Arguments = args;
            process.StartInfo = startInfo;
            process.Start();
           // Process.Start(pgm, args);

        }

        private void UpdateCordova_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            submitCMD("npm", "install -g cordova@latest", true);
            //Process.Start("npm", "install -g cordova@latest");
        }

        private void CordovaPlugins_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BuildProject_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            Process.Start("https://cordova.apache.org/");
        }
    }
}
