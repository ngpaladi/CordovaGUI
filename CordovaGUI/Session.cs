using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordovaGUI
{
    public class Session
    {
        private long startTime;
        private long endTime;
        public Session()
        {
            startTime = UnixTimeNow();


        }
        public long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }
        public void submitCMD(string pgm, string args)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = pgm;
            startInfo.Arguments = args;
            process.StartInfo = startInfo;
            process.Start();
        }
        ~Session()
        {
            endTime = UnixTimeNow();
        }
    }

}
