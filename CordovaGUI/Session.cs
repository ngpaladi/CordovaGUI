using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CordovaGUI
{
    public class Session : MainWindow
    {
        private long startTime;
        private long endTime;
        /*private Process process;
        private ProcessStartInfo processStartInfo;*/
        public Session()
        {
            startTime = UnixTimeNow();
            /*process = new Process();
            processStartInfo = new ProcessStartInfo();*/
 
        }
        public long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

       /* public void submitCMD(string pgm, string args, bool show)
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
            Process.Start(pgm, args);

        }
        */
        ~Session()
        {
            endTime = UnixTimeNow();
        }
    }

}
