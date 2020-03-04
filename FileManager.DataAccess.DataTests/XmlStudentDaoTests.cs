using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Configuration;
using FileManager.Common.Layer.Entities;
using FileManager.DataAccess.Data.Services;

namespace FileManager.DataAccess.Data.Tests
{
    [TestClass()]
    public class XmlStudentDaoTests
    {
        private readonly static string FileName = ConfigurationManager.AppSettings["xml"].ToString();

        [TestInitialize]
        public void Setup()
        {
            var xmlStudentDao = new XmlStudentDao();
            xmlStudentDao.Create(new Student { Id = 1, Name = "ParaTestear", LastName = "safsdf", Age = 6 });
            xmlStudentDao.Create(new Student { Id = 2, Name = "ParaTestear", LastName = "safsdf", Age = 6 });
            xmlStudentDao.Create(new Student { Id = 3, Name = "ParaTestear", LastName = "safsdf", Age = 6 });
            xmlStudentDao.Create(new Student { Id = 4, Name = "ParaTestear", LastName = "safsdf", Age = 6 });
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            File.Delete(FileName);
        }

        [TestMethod()]
        public void GetAll_GivenNonExistentFile_ShouldReturnAnEmptyList()
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
            var xmlStudentDao = new XmlStudentDao();
            var list = xmlStudentDao.GetAll();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void Create_GivenAFourStudentsInFile_ShouldReturnAListWithFiveElement()
        {
            var student = new Student
            {
                Id = 5,
                Name = "Pepe",
                LastName = "Perez",
                Age = 21
            };
            var xmlStudentDao = new XmlStudentDao();
            xmlStudentDao.Create(student);
            var list = xmlStudentDao.GetAll();
            Assert.AreEqual(5, list.Count);
        }

        [TestMethod()]
        public void Update_GivenFourStudentsInFile_ShouldReturnAListWithSixElement()
        {
            var student = new Student
            {
                Id = 1
            };
            var xmlStudentDao = new XmlStudentDao();
            xmlStudentDao.Update(student);
            var list = xmlStudentDao.GetAll();
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod()]
        public void Delete_GivenOneStudentInFile_ShouldReturnAnEmptyList()
        {
            var student = new Student
            {
                Id = 1
            };
            var xmlStudentDao = new XmlStudentDao();
            xmlStudentDao.Delete(student);
            var list = xmlStudentDao.GetAll();
            Assert.AreEqual(3, list.Count);
        }
        [ClassCleanup]
        public static void ClassCleanUp()
        {
            File.Delete(FileName);
        }
    }
}