using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsAssignment
{
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
}
