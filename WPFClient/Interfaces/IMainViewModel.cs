using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFObjects;

namespace WPFClient.Interfaces
{
    public interface IMainViewModel
    {
        ObservableCollection<WPFPatientInfo> Patients { get; set; }
        WPFPatientInfo SelectedPatient { get; set; }
        void Add(WPFPatientInfo patientInfo);
        bool CanAdd(WPFPatientInfo patientInfo);
        void Delete(WPFPatientInfo patientInfo);
        bool CanDelete(WPFPatientInfo patientInfo);
        void Update(WPFPatientInfo patientInfo);
        bool CanUpdate(WPFPatientInfo patientInfo);
    }
}
