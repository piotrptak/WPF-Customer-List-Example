using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Helpers
{
    internal class PatientInfoHelpers
    {
        internal static PatientInfo GeneratePatient(int postfix)
        {
            return new PatientInfo
            {
                PatientID="PatientID"+postfix,
                PatientNameGroup1="Group_1"+postfix,
                PatientNameGroup2="Group_2"+postfix,
                PatientNameGroup3="Group_3"+postfix,
                PatientSex="MALE",
                EthnicGroup="EthnicGroup",
                PatientBirthDate= (DateTime?)CommonHelpers.RandomDay(),
                PatientComment="Comment"+postfix,
                PatientDisease="Disease"+postfix,
                PatientInfoID=postfix
            };
        }
    }
}
