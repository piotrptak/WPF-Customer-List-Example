using DAL;
using DomainServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Stubs;

namespace Tests
{
    [TestClass]
    public class TestsBase
    {
        protected IGenericRepositoryServices<PatientInfo> patientsServices;
        [TestInitialize]
        public void Initialize()
        {
            this.patientsServices = new StubPatientInfoServices();
                //for intergration tests use new PatientsServices();
        }
    }
}
