using DAL;
using DomainServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Interfaces;
using WPFObjects;
using Mappers;

namespace WPFClient.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private IGenericRepositoryServices<PatientInfo> patientServices;
        private ObservableCollection<WPFPatientInfo> patients;
        private WPFPatientInfo selectedPatient;
        private WPFPatientInfo transientPatient;
        private WPFPatientInfo lastPatientOriginalValue;
        private RelayCommand<WPFPatientInfo> savePatientCommand;
        private RelayCommand<WPFPatientInfo> cancelPatientSaveCommand;

        public MainViewModel(IGenericRepositoryServices<PatientInfo> patientServices, IMessageBoxService messageBoxService)
            :base(messageBoxService)
        {
            this.patientServices = patientServices;
            var domPatients = patientServices.GetAll();
            if(domPatients!=null)
            {
                this.patients = new ObservableCollection<WPFPatientInfo>();
                foreach (var item in domPatients)
                {
                    this.patients.Add(item.Map());
                }
            }
        }

        public ObservableCollection<WPFPatientInfo> Patients
        {
            get { return this.patients; }
            set
            {
                this.patients = value;
                NotifyPropertyChanged("Patients");
            }
        }

        public WPFPatientInfo SelectedPatient
        {
            get { return this.selectedPatient; }
            set
            {
                this.selectedPatient = value;
                EnsureSave(value);
                NotifyPropertyChanged("SelectedPatient");
            }
        }

        private void EnsureSave(WPFPatientInfo patientInfo)
        {
            if (transientPatient != null)
            {
                if (transientPatient.IsDirty)
                {
                    if (base.MessageBoxService.Show("Do you want to save changes?", "Test", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Warning) == System.Windows.MessageBoxResult.Yes)
                    {
                        Update(patientInfo);
                        this.transientPatient = this.selectedPatient;
                    }
                    else
                    {
                        this.selectedPatient = this.lastPatientOriginalValue;
                    }
                    this.transientPatient.SetIsDirty(false);
                }
            }
            this.lastPatientOriginalValue = selectedPatient.MapWPFToWPF();
            this.transientPatient = selectedPatient;            
        }

        public void Add(WPFPatientInfo patientInfo)
        {
            patientServices.Add(patientInfo.Map());
        }
        public bool CanAdd(WPFPatientInfo patientInfo)
        {
            return true;
        }

        public void Delete(WPFPatientInfo patientInfo)
        {
            patientServices.Delete(patientInfo.Map());
        }
        public bool CanDelete(WPFPatientInfo patientInfo)
        {
            return true;
        }
        public bool CanUpdate(WPFPatientInfo patientInfo)
        {
            return patientInfo!=null && patientInfo.IsDirty;
        }

        public void Update(WPFPatientInfo patientInfo)
        {
            if(patientServices.Update(patientInfo.Map()))
            {
                patientInfo.SetIsDirty(false);
                this.transientPatient = selectedPatient;
                NotifyPropertyChanged("SelectedPatient");
            }
        }

        private void CancelPatientSave(WPFPatientInfo patientInfo)
        {
            this.selectedPatient = this.lastPatientOriginalValue;
            this.transientPatient = selectedPatient;
            NotifyPropertyChanged("SelectedPatient");
        }

        public RelayCommand<WPFPatientInfo> SavePatientCommand
        {
            get
            {
                return this.savePatientCommand ??
                    (
                    this.savePatientCommand = new RelayCommand<WPFPatientInfo>
                        (
                        patientInfo => { Update(patientInfo); },
                        patientInfo => { return CanUpdate(patientInfo); }
                        ));

            }
        }

        public RelayCommand<WPFPatientInfo> CancelPatientSaveCommand
        {
            get
            {
                return this.cancelPatientSaveCommand ??
                    (
                    this.cancelPatientSaveCommand = new RelayCommand<WPFPatientInfo>
                        (
                        patientInfo => { CancelPatientSave(patientInfo); },
                        patientInfo => { return CanUpdate(patientInfo); }
                        ));

            }
        }
    }
}
