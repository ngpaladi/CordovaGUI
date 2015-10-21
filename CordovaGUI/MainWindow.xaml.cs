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
using System.Windows.Forms;

namespace CordovaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Session CurrentSession;

        public MainWindow()
        {
            InitializeComponent();

            image.Click += Image_Click;
            newProject.Click += NewProject_Click;
            openProject.Click += OpenProject_Click;
            buildIOS.Click += BuildIOS_Click;
            buildAndroid.Click += BuildAndroid_Click;
            updateCordova.Click += UpdateCordova_Click;



        }
        public long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }
        public void submitCMD(string pgm, string args, string dir,  bool show)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if (!show)
            {
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }
            else
            {
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            }
            startInfo.FileName = pgm;
            startInfo.WorkingDirectory = dir;
            startInfo.Arguments = args;
            process.StartInfo = startInfo;
            process.Start();
           // Process.Start(pgm, args);

        }

        public void submitCMD(string pgm, string args, bool show)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
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
            submitCMD("npm", "install -g cordova@latest", "", true);
            //Process.Start("npm", "install -g cordova@latest");
        }

        private void BuildAndroid_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BuildIOS_Click(object sender, RoutedEventArgs e)
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
            string name = "NewProject";
            string path = "C:\\";


            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = "C:\\";

            DialogResult result = folderDialog.ShowDialog();
            path = folderDialog.SelectedPath;

            //System.Windows.Forms.MessageBox.Show(path);

            name = Microsoft.VisualBasic.Interaction.InputBox("Enter project name:", "Cordova", "NewProject", 200, 200);

        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            Process.Start("https://cordova.apache.org/");
        }
    }
}
