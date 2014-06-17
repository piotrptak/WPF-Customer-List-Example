using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WPFObjects
{
    public class WPFPatientInfo : BaseViewModel, IDataErrorInfo
    {
        //private PatientInfo patientInfo;
        private string patientID;
        private int patientInfoID;
        private string patientNameGroup1;
        private string patientNameGroup2;
        private Nullable<DateTime> patientBirthDate;

        private bool isDirty;
        
        public WPFPatientInfo()
        {
            //this.patientInfo = new PatientInfo();
        }
        

        public string PatientID
        {
            get { return this.patientID; }
            set
            {
                SetIsDirty(!string.IsNullOrEmpty(this.patientID) && this.patientID != value ? true : false);
                this.patientID = value;
                NotifyPropertyChanged("PatientID");
            }
        }

        public int PatientInfoID
        {
            get { return this.patientInfoID; }
            set
            {
                //CheckDataChange("PatientInfoID", value);
                patientInfoID = value;
                NotifyPropertyChanged("PatientInfoID");
            }
        }
        public string PatientNameGroup1
        {
            get { return this.patientNameGroup1; }
            set
            {
                //CheckDataChange("PatientNameGroup1", value);
                this.patientNameGroup1 = value;
                NotifyPropertyChanged("PatientNameGroup1");
            }
        }
        public string PatientNameGroup2
        {
            get { return this.patientNameGroup2; }
            set
            {
                //CheckDataChange("PatientNameGroup2", value);
                this.patientNameGroup2 = value;
                NotifyPropertyChanged("PatientNameGroup2");
            }
        }
        public string PatientNameGroup3 { get; set; }
        public Nullable<System.DateTime> PatientBirthDate
        {
            get { return this.patientBirthDate; }
            set
            {
                this.patientBirthDate = value;
                NotifyPropertyChanged("PatientBirthDate");
            }
        }
        public string PatientSex { get; set; }
        public string EthnicGroup { get; set; }
        public string PatientComment { get; set; }
        public byte[] PatientInfoTS { get; set; }
        public string PatientFileInfo { get; set; }
        public string PatientDisease { get; set; }

        public void SetIsDirty(bool isDirty=true)
        {
            this.IsDirty = isDirty;
        }


        public bool IsDirty
        {
            get { return this.isDirty; }
            set
            {
                this.isDirty = value;
                NotifyPropertyChanged("IsDirty");
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {

            get {

                string result = string.Empty;
                switch(columnName)
                {
                    case "PatientID": if (string.IsNullOrEmpty(PatientID)) result = "Cannot be null"; break;
                    case "PatientNameGroup1": if (string.IsNullOrEmpty(PatientNameGroup1)) result = "Cannot be null"; break;
                    case "PatientNameGroup2": if (string.IsNullOrEmpty(PatientNameGroup2)) result = "Cannot be null"; break;
                        //implement other properties

                }
                return result;
            }
        }
    }
}
