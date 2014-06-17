using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices
{
    public class PatientsServices : IGenericRepositoryServices<PatientInfo>
    {
        TestEntities context;

        public PatientsServices()
        {
            context = new TestEntities();
        }

        public PatientInfo Add(PatientInfo entity)
        {
            this.context.PatientInfo.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public bool Update(PatientInfo entity)
        {
            var currentPatient = context.PatientInfo.FirstOrDefault(d => d.PatientInfoID.Equals(entity.PatientInfoID));
            if(currentPatient!=null)
            {
                currentPatient.PatientID = entity.PatientID;
                currentPatient.PatientNameGroup1 = entity.PatientNameGroup1;
                currentPatient.PatientNameGroup2 = entity.PatientNameGroup2;
                currentPatient.PatientBirthDate = entity.PatientBirthDate;
                currentPatient.PatientSex = entity.PatientSex;
                return context.SaveChanges()>0;
                
            }
            throw new ArgumentException("Patient does not exist");
        }

        public bool Delete(PatientInfo entity)
        {
            var currentPatient = context.PatientInfo.FirstOrDefault(d => d.PatientInfoID.Equals(entity.PatientInfoID));
            if (currentPatient != null)
            {
                context.PatientInfo.Remove(currentPatient);
                return context.SaveChanges()>0;
            }
            throw new ArgumentException("Patient does not exist");
        }

        public PatientInfo Get(Func<PatientInfo, bool> filter)
        {
            return context.PatientInfo.FirstOrDefault(filter);
        }

        public IList<PatientInfo> GetAll()
        {
            return context.PatientInfo.ToList();
        }
    }
}
