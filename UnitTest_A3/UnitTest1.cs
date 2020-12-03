using NUnit.Framework;
using WebApplication4.Models;
//Unit tests for with assignment 3
namespace WebAppTest_A3
{
    public class jobModel
    {
        [SetUp]

        [Test]
        public void averagesalary_test()
        {
            JobModel softwareEngineer = new JobModel();
            softwareEngineer.id = 0;
            softwareEngineer.name = "Software Engineer";
            softwareEngineer.salarySum = 100000;
            softwareEngineer.workerCount = 100;
            double expectedAverage = 1000;
            double actualAverage = softwareEngineer.averageSalary;
            Assert.AreEqual(expectedAverage, actualAverage);
        }

        [Test]
        public void addWorker_test()
        {
            JobModel softwareEngineer = new JobModel();
            softwareEngineer.id = 0;
            softwareEngineer.name = "Software Engineer";
            softwareEngineer.salarySum = 100000;
            softwareEngineer.workerCount = 99;

            softwareEngineer.addWorker(2000);

            double expectedCount = 100;
            double expectedAverage = 1020;

            Assert.AreEqual(expectedCount, softwareEngineer.workerCount);
            Assert.AreEqual(expectedAverage, softwareEngineer.averageSalary);

        }


        [Test]
        public void removeWorker_test()
        {
            JobModel softwareEngineer = new JobModel();
            softwareEngineer.id = 0;
            softwareEngineer.name = "Software Engineer";
            softwareEngineer.salarySum = 2020000;
            softwareEngineer.workerCount = 101;

            softwareEngineer.removeWorker(20000);

            double expectedCount = 100;
            double expectedAverage = 20000;

            Assert.AreEqual(expectedCount, softwareEngineer.workerCount);
            Assert.AreEqual(expectedAverage, softwareEngineer.averageSalary);

        }


        [Test]
        public void test_createPerson()
        {
            JobModel softwareEngineer = new JobModel();
            softwareEngineer.id = 0;
            softwareEngineer.name = "Software Engineer";
            softwareEngineer.salarySum = 2020000;
            softwareEngineer.workerCount = 99;

            PersonModel test_person = new PersonModel(5, "Test Person", softwareEngineer, 20000);

            double expectedCount = 100;
            double expectedAverage = 20400;

            Assert.AreEqual(expectedCount, softwareEngineer.workerCount);
            Assert.AreEqual(expectedAverage, softwareEngineer.averageSalary);

        }


    }
}