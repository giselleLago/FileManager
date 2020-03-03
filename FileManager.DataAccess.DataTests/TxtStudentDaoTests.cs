using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data.Tests
{
    [TestClass()]
    public class TxtStudentDaoTests
    {
        private const string FileName = "students.txt";

        [TestInitialize]
        public void Setup()
        {
            var txtStudentDao = new TxtStudentDao();
            txtStudentDao.Create(new Student { Id = 1, Name = "ParaTestear", LastName = "safsdf", Age = 6 });
            txtStudentDao.Create(new Student { Id = 2, Name = "ParaTestear", LastName = "safsdf", Age = 6 });
            txtStudentDao.Create(new Student { Id = 3, Name = "ParaTestear", LastName = "safsdf", Age = 6 });
            txtStudentDao.Create(new Student { Id = 4, Name = "ParaTestear", LastName = "safsdf", Age = 6 });
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
            var txtStudentDao = new TxtStudentDao();
            var list = txtStudentDao.GetAll();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void Create_GivenOneStudentInFile_ShouldReturnAListWithOneElement()
        {
            var student = new Student
            {
                Id = 7,
                Name = "Pepe",
                LastName = "Perez",
                Age = 21
            };
            var txtStudentDao = new TxtStudentDao();
            txtStudentDao.Create(student);
            var list = txtStudentDao.GetAll();
            Assert.AreEqual(5, list.Count);
        }

        [TestMethod()]
        public void Update_GivenAnEmptyFile_ShouldReturnAListWithOneElement()
        {
            var student = new Student
            {
                Id = 2
            };
            var txtStudentDao = new TxtStudentDao();
            txtStudentDao.Update(student);
            var list = txtStudentDao.GetAll();
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod()]
        public void Delete_GivenOneStudentInFile_ShouldReturnAnEmptyList()
        {
            var student = new Student
            {
                Id = 1
            };
            var txtStudentDao = new TxtStudentDao();
            txtStudentDao.Delete(student);
            var list = txtStudentDao.GetAll();
            Assert.AreEqual(3, list.Count);
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            File.Delete(FileName);
        }
    }
}