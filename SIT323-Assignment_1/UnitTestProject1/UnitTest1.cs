using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIT323_Assignment_1;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        readonly TaskAllocation testTask = new TaskAllocation();
        readonly Configuration testCon = new Configuration();
        [TestMethod]
        public void TestComputingTaskRunTime()
        {
            //Arrange
            double expectedRunTime = Math.Round(1 * 2 / 2.3, 2);
            //Act
            testCon.Parse(@"..\..\..\Files for Unit Testing\Test1.csv");
            testTask.Parse(@"..\..\..\Files for Unit Testing\Test1.tan");
            double runTime = testCon.CaluationTaskRunTime(1, 1);
            runTime = Math.Round(runTime, 2);
            //Assert
            Assert.AreEqual(expectedRunTime, runTime, "the amount of task runtime is incorrect");
        }

        [TestMethod]
        public void TestComputingTaskEnergy()
        {
            //Arrange
            double expectedEnergy = 17.74;
            //Act
            testCon.Parse(@"..\..\..\Files for Unit Testing\Test1.csv");
            testTask.Parse(@"..\..\..\Files for Unit Testing\Test1.tan");
            double runTime = Math.Round(testCon.CaluationTaskEnergy(2, "2"), 2);
            //Assert
            Assert.AreEqual(expectedEnergy, runTime, "the amount of task energy is incorrect");
        }

        [TestMethod]
        public void TestComputingAllocationRunTime()
        {
            //Arrange
            double expectedRunTime = 2.61;
            //Act
            testCon.Parse(@"..\..\..\Files for Unit Testing\Test1.csv");
            testTask.Parse(@"..\..\..\Files for Unit Testing\Test1.tan");
            double runTime = Math.Round(testCon.CaluationRunTime(testTask.allocationList[0]), 2);
            //Assert
            Assert.AreEqual(expectedRunTime, runTime, "the amount of allocation runtime is incorrect");
        }

        [TestMethod]
        public void TestComputingAllocationEnergy()
        {
            //Arrange
            double expectedRunTime = 155.77;
            //Act
            testCon.Parse(@"..\..\..\Files for Unit Testing\Test1.csv");
            testTask.Parse(@"..\..\..\Files for Unit Testing\Test1.tan");
            double runTime = Math.Round(testCon.CaluationAllocationEnergy(testTask.allocationList[0]), 2);
            //Assert
            Assert.AreEqual(expectedRunTime, runTime, "the amount of allocation runtime is incorrect");
        }

        [TestMethod]
        public void TestValidatingAllocation()
        {
            //Arrange
            bool expectedCheck = false;
            //Act
            testTask.Parse(@"..\..\..\Files for Unit Testing\Test3.tan");
            bool isValid = testTask.allocationList[1].Check();
            //Assert
            Assert.AreEqual(expectedCheck, isValid, "the allocation check method is incorrect");
        }

        [TestMethod]
        public void TestCsvFile()
        {
            //Arrange
            bool expectedCheck = false;
            //Act
            Configuration con = new Configuration();
            bool isValid = con.Parse(@"..\..\..\Files for Unit Testing\Test3.csv");
            //Assert
            Assert.AreEqual(expectedCheck, isValid, "the CSV file check method is incorrect");
        }

        [TestMethod]
        public void TestTanFile()
        {
            //Arrange
            bool expectedCheck = false;
            //Act
            TaskAllocation task = new TaskAllocation();
            bool isValid = task.Parse(@"..\..\..\Files for Unit Testing\Test3.tan");
            //Assert
            Assert.AreEqual(expectedCheck, isValid, "the TAN file check method incorrect");
        }
    }
}
