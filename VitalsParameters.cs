using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsAssignment
{
    class VitalsParameters
    {
        public int total_no_vitals;
        public string[] vital_names;
        public float[] vital_values;

        public static IDictionary<string,float> map_lowerlimit = new Dictionary<string, float>(){
            { "BPM", 70.0f },
            { "SPO2", 90.0f },
            { "RESPIRATORY", 30.0f},
            {"BLOODPRESSURE",60.0f },
            {"HEARTRATE",90.0f }
        };

        public static IDictionary<string,float> map_upperlimit = new Dictionary<string, float>(){
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
}
