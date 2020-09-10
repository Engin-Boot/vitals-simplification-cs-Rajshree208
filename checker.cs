using System;
using System.Diagnostics;

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

        class VitalsCheck
        {

            public bool vitalsIsOk(Alert alert, string vitalName, float value, float lower, float upper)
            {

                if (value < lower)
                {
                    string message = "IS LOW !!";
                    alert.sendAlert(vitalName, message);
                    return false;
                }
                else if (value > upper)
                {
                    string message = "IS HIGH !!";
                    alert.sendAlert(vitalName, message);
                    return false;
                }
                return true;
            }

            public bool vitalsAreOk(Alert alert, VitalsParameters p)
            {

                int countOfTrueValues = 0;
                bool vitalStatus;
                for (int i = 0; i < p.total_no_vitals; i++)
                {
                    string vitalname = p.vital_names[i];
                    vitalStatus = vitalsIsOk(alert, p.vital_names[i], p.vital_values[i], VitalsParameters.map_lowerlimit[vitalname], VitalsParameters.map_upperlimit[vitalname]);
                    if (vitalStatus == true)
                    {
                        countOfTrueValues++;
                    }
                }
                return (countOfTrueValues == p.total_no_vitals);
            }
        }

        class VitalsParameters
        {
            public int total_no_vitals;
            public string[] vital_names;
            public float[] vital_values;

            public static IDictionary<string, float> map_lowerlimit = new Dictionary<string, float>(){
                { "BPM", 70.0f },
                { "SPO2", 90.0f },
                { "RESPIRATORY", 30.0f},
                {"BLOODPRESSURE",60.0f },
                {"HEARTRATE",90.0f }
            };

            public static IDictionary<string, float> map_upperlimit = new Dictionary<string, float>(){
                { "BPM", 150.0f },
                { "SPO2", float.MaxValue },
                { "RESPIRATORY", 95.0f},
                {"BLOODPRESSURE",150.0f },
                {"HEARTRATE", 120.0f }
            };
            public VitalsParameters(int t, string[] vitalNames, float[] vitalValues)
            {
                total_no_vitals = t;
                vital_names = new string[total_no_vitals];
                vital_values = new float[total_no_vitals];
                Array.Copy(vitalNames, vital_names, vitalNames.Length);
                Array.Copy(vitalValues, vital_values, vitalValues.Length);
            }
        }

        class Checker
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
