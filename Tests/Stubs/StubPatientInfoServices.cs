using DAL;
using DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Helpers;

namespace Tests.Stubs
{
    public class StubPatientInfoServices : IGenericRepositoryServices<PatientInfo>
    {
        IList<PatientInfo> patientsStub;
        public StubPatientInfoServices()
        {
            this.patientsStub = new List<PatientInfo>();
            for (int i = 0; i < 10; i++)
            {
                this.patientsStub.Add(PatientInfoHelpers.GeneratePatient(i));
            }
        }

        public PatientInfo Add(PatientInfo entity)
        {
            var currentPatient = patientsStub.FirstOrDefault(d => d.PatientInfoID.Equals(entity.PatientInfoID));
            if(currentPatient==null)
            {
                patientsStub.Add(entity);
                return entity;
            }
            throw new ArgumentException("Patient already exists");
        }

        public bool Update(PatientInfo entity)
        {
            var currentPatient = patientsStub.FirstOrDefault(d => d.PatientInfoID.Equals(entity.PatientInfoID));
            if (currentPatient != null)
            {
                currentPatient.PatientID = entity.PatientID;
                currentPatient.PatientNameGroup1 = entity.PatientNameGroup1;
                currentPatient.PatientNameGroup2 = entity.PatientNameGroup2;
                currentPatient.PatientSex = entity.PatientSex;
                currentPatient.PatientBirthDate = entity.PatientBirthDate;

            }
            throw new ArgumentException("Patient does not exist");
        }

        public bool Delete(PatientInfo entity)
        {
            var currentPatient = patientsStub.FirstOrDefault(d => d.PatientInfoID.Equals(entity.PatientInfoID));
            if(currentPatient!=null)
            {
                patientsStub.Remove(currentPatient);
                return true;
            }
            throw new ArgumentException("Patient does not exist");
        }

        public PatientInfo Get(Func<PatientInfo, bool> filter)
        {
            return patientsStub.FirstOrDefault(filter);
        }

        public IList<PatientInfo> GetAll()
        {
            return patientsStub;
        }
    }
}
