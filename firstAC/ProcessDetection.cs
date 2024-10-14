using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstAC
{
    class ProcessDetection
    {

        public static bool detected;
        public static List<string> currentlyRunning = new List<string>();
        public static string[] suspiciousName = {"Cheat", "Debugger", "x64dbg", "IDA Pro"};
        public static string ignoreName = AppDomain.CurrentDomain.FriendlyName;

        public static void UpdateProcess()
        {
            Process[] running = Process.GetProcesses();

            foreach (Process process in running) {
                currentlyRunning.Add(process.ProcessName);
            }

        }

        public static void FindProcess()
        {
            foreach(string name in currentlyRunning)
            {
                foreach(string susp in suspiciousName)
                {
                    if (name.Contains(susp) && !name.Equals(ignoreName))
                    {
                        detected = true;
                        Console.WriteLine("[DETECTED] nameProcess: "+name);
                        return;
                    }
                }
            }
        }


    }

}
