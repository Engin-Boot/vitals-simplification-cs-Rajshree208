using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsAssignment
{
    public abstract class Alert
    {

        public abstract void sendAlert(string vitalName, string message);
    }

    class AlertWithSMS : Alert
    {
        public override void sendAlert(string vitalName, string message)
        {
            Console.WriteLine("Alert using SMS-->" + vitalName + " " + message);
        }
    }

    class AlertWithAlarm : Alert
    {
        public override void sendAlert(string vitalName, string message)
        {
            Console.WriteLine("Alert using Alarm-->" + vitalName + " " + message);
        }
    }
}
