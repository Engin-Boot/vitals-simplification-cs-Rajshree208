using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            AlertWithSMS alertSms = new AlertWithSMS();
            AlertWithAlarm alertAlarm=new AlertWithAlarm();
            VitalsCheck checkVitals = new VitalsCheck();

            string[] vitalNames1 = { "BPM", "RESPIRATORY", "SPO2", "BLOODPRESSURE", "HEARTRATE" };
            float[] vitalValues1 = { 40, 89, 99, 50, 130 };

            VitalsParameters vitalsForPatient1 = new VitalsParameters(5, vitalNames1, vitalValues1);

            string[] vitalNames2 = { "BPM", "SPO2", "RESPIRATORY" };
            float[] vitalValues2 = { 100, 90, 25 };

            VitalsParameters vitalsForPatient2 = new VitalsParameters(3, vitalNames2, vitalValues2);

            checkVitals.vitalsAreOk(alertSms, vitalsForPatient1);
            checkVitals.vitalsAreOk(alertAlarm, vitalsForPatient2);
            Console.ReadKey();
        }
    }
}
