using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;

namespace Tests
{
    [TestClass]
    public class MainViewModelTests : TestsBase
    {
        
        [TestMethod]
        public void GetPatients_Success()
        {
            var patients = patientsServices.GetAll();
            Assert.IsNotNull(patients);
            Assert.IsTrue(patients.Count > 0);
        }

        [TestMethod]
        public void AddPatient_Success()
        {
            //Arrange
            var patient = PatientInfoHelpers.GeneratePatient(1000);
            //Act
            var newlyCreatedPatient = patientsServices.Add(patient);
            //Assert
            Assert.AreEqual(patient, newlyCreatedPatient);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void AddPatient_Failure_PatientAlreadyExists()
        {
            //Arrange
            var patient = PatientInfoHelpers.GeneratePatient(1000);
            //Act
            var newlyCreatedPatient = patientsServices.Add(patient);
            var newlyCreatedPatient2 = patientsServices.Add(patient);
            //Assert
        }
        
        //Implement more tests here
    }
}
