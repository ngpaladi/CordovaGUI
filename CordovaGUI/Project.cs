using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordovaGUI
{
    partial class Project : Session
    {
        private string name;
        private string path;
        private long createTime;
        private long buildTime;
        private string buildTimeString;
        private string cfgFile;
        private string createTimeString;
        private string cdpPath;
        private string reverseDomain;
        private string username;

        public void makeNewProject(string projectName, string projectPath)
        {
            path = projectPath;
            name = projectName;
            createTime = UnixTimeNow(); //Inherited from Session
            buildTime = 0;
            createTimeString = createTime.ToString();
            buildTimeString = buildTime.ToString();
            cdpPath = projectPath + projectName + "\\" + projectName + ".cdp";
            username = Environment.UserName;
            reverseDomain = "com." + username + "." + projectName;

            //create project and .cdp file
            //string toCMD1 = "cd " + projectPath;
            //submitCMD("cmd.exe", toCMD1);
            string toCMD2 = "create " + projectName + " " + reverseDomain + " " + projectName;
            submitCMD("cordova", toCMD2, projectPath, true);
            string[] lines = { name, reverseDomain, createTimeString, buildTimeString };
            System.IO.File.WriteAllLines(@cdpPath, lines);
        }
        public void loadProject(string CfgFilePath)
        {
            //read project .cdp file

        }

        public string getName()
        {
            return name;
        }
        public void setName(string newName)
        {
            name = newName;
        }
        public string getPath()
        {
            return path;
        }
        public void setPath(string newPath)
        {
            path = newPath;
        }

    }
}
