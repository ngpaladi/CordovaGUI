﻿using System;
using System.IO;
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
using System.Threading;

namespace CordovaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private Project CurrentProject;
        public Session CurrentSession;

        public MainWindow()
        {
            
            InitializeComponent();
            CurrentProject = new Project();
            image.Click += Image_Click;
            newProject.Click += NewProject_Click;
            openProject.Click += OpenProject_Click;
            buildWindows.Click += BuildWindows_Click;
            buildAndroid.Click += BuildAndroid_Click;
            updateCordova.Click += UpdateCordova_Click;



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
            submitCMD("npm", "install -g cordova@latest", true);
            //Process.Start("npm", "install -g cordova@latest");
        }

        private void BuildAndroid_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            submitCMD("cordova", "platform add android", CurrentProject.getBuildPath(), true);
            submitCMD("cordova", "build android", CurrentProject.getBuildPath(), true);
            CurrentProject.buildUpdate();
        }

        private void BuildWindows_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            submitCMD("cordova", "platform add windows", CurrentProject.getBuildPath(), true);
            submitCMD("cordova", "build windows", CurrentProject.getBuildPath(), true);
            CurrentProject.buildUpdate();
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            string path;
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "c:\\Users\\"+Environment.UserName+"\\Documents\\";
            file.Filter = "cdp files (*.cdp)|*.cdp|All files (*.*)|*.*";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.ShowDialog();
            //if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                string[] readText = File.ReadAllLines(path, Encoding.UTF8);
                CurrentProject.loadProject(readText[0], readText[1], readText[2], readText[3], path);
            }
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            string name = "NewProject";
            string path = "c:\\Users\\" + Environment.UserName + "\\Documents\\";


            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = "c:\\Users\\" + Environment.UserName + "\\Documents\\";

            DialogResult result = folderDialog.ShowDialog();
            path = folderDialog.SelectedPath;


            //System.Windows.Forms.MessageBox.Show(path);

            name = Microsoft.VisualBasic.Interaction.InputBox("Enter project name:", "Cordova", "NewProject", 200, 200);
            name.Replace(' ', '_');
            //Project CurrentProject = new Project();
            CurrentProject.makeNewProject(name, path);
            submitCMD("cordova", CurrentProject.getCreateArgs(), CurrentProject.getPath(), true);
            System.Threading.Thread.Sleep(5000);
            string[] cdpText = { CurrentProject.getName(), CurrentProject.getPath(), CurrentProject.getCreateTimeStr(), CurrentProject.getBuildTimeStr()  };
            System.Threading.Thread.Sleep(5000);
            File.WriteAllLines(CurrentProject.getCdpPath(), cdpText, Encoding.UTF8);


        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            Process.Start("https://cordova.apache.org/");
        }
       
    }
}
