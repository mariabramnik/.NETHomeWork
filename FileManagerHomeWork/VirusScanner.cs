using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileManagerHomeWork
{
    static class VirusScanner
    {
        public static string isInfected;
        static VirusScanner()
        {
            isInfected = ConfigurationManager.AppSettings.Get("Key0");

        }
        public static string ISInfected{ get { return isInfected; } }
        public static bool IsFileInfected(int mfSize, string mfPath)
        {
            int num = ReturnKeyInt(isInfected);
            bool res = false;
            if(mfSize == num)
            {
                throw new InfectedFileDetectedException($"File with paht : { mfPath } is Infected");
            }

                return res;
        }
        private static int ReturnKeyInt(string key)
        {
            int num = 0;
            bool res = false;
            res = Int32.TryParse(key, out num);
            return num;

        }
    }
}
