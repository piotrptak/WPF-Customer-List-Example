using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFObjects;

namespace Mappers
{
    public static class PatientMapper
    {
        public static PatientInfo Map(this WPFPatientInfo wpfPatientInfo)
        {
            Mapper.CreateMap<WPFPatientInfo, PatientInfo>();
            return Mapper.Map<WPFPatientInfo, PatientInfo>(wpfPatientInfo);
        }
        public static WPFPatientInfo Map(this PatientInfo patientInfo)
        {
            Mapper.CreateMap<PatientInfo, WPFPatientInfo>();
            return Mapper.Map<PatientInfo, WPFPatientInfo>(patientInfo);
        }
        public static WPFPatientInfo MapWPFToWPF(this WPFPatientInfo wpfPatientInfo)
        {
            Mapper.CreateMap<WPFPatientInfo, WPFPatientInfo>();
            return Mapper.Map<WPFPatientInfo, WPFPatientInfo>(wpfPatientInfo);
        }
    }
}
