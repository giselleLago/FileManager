using FileManager.Common.Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FileManager.DataAccess.Data.Tests
{
    [TestClass()]
    public class JsonStudentDaoTests
    {
        private const string FileName = "students.json";

        [TestMethod()]
        public void GetAll_GivenNonExistentFile_ShouldReturnAnEmptyList()
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
            var jsonStudentDao = new JsonStudentDao();
            var list = jsonStudentDao.GetAll();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void GetAll_GivenOneStudentInFile_ShouldReturnAListWithOneElement()
        {
            var json = "[{ \"Name\":\"Pepe\", \"LastName\":\"Perez\", \"Age\": 20}]";
            File.WriteAllText(FileName, json);
            var jsonStudentDao = new JsonStudentDao();
            var list = jsonStudentDao.GetAll();
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod()]
        public void Create_GivenAnEmptyFile_ShouldReturnAListWithOneElement()
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
            var student = new Student
            {
                Name = "Pepe",
                LastName = "Perez",
                Age = 21
            };
            var jsonStudentDao = new JsonStudentDao();
            jsonStudentDao.Create(student);
            var jsonList = jsonStudentDao.GetAll();
            Assert.AreEqual(1, jsonList.Count);
        }
        [TestMethod()]
        public void Create_GivenOneStudentInFile_ShouldReturnAListWithTwoElements()
        {
            var json = "[{ \"Name\":\"Pepe\", \"LastName\":\"Perez\", \"Age\": 20}]";
            File.WriteAllText(FileName, json);
            var student = new Student
            {
                Name = "Pepe",
                LastName = "Perez",
                Age = 21
            };
            var jsonStudentDao = new JsonStudentDao();
            jsonStudentDao.Create(student);
            var jsonList = jsonStudentDao.GetAll();
            Assert.AreEqual(2, jsonList.Count);
        }
        [TestMethod()]
        public void Update_GivenOneStudentInFile_ShouldReturnAStudentWithDiferentNameAndAge()
        {
            var json = "[{ \"Id\":\"1\", \"Name\":\"Pepe\", \"LastName\":\"Perez\", \"Age\": 20}]";
            File.WriteAllText(FileName, json);
            var student = new Student
            {
                Id = "1",
                Name = "Max",
                LastName = "Perez",
                Age = 21
            };
            var jsonStudentDao = new JsonStudentDao();
            var updateStudent = jsonStudentDao.Update(student);
            jsonStudentDao.GetAll();
            Assert.AreEqual(updateStudent.Name, student.Name);
            Assert.AreEqual(updateStudent.LastName, student.LastName);
            Assert.AreEqual(updateStudent.Age, student.Age);
        }
        [TestMethod()]
        public void Delete_GivenOneStudentInFile_ShouldReturnAnEmptyList()
        {
            var json = "[{ \"Id\":\"1\", \"Name\":\"Pepe\", \"LastName\":\"Perez\", \"Age\": 20}]";
            File.WriteAllText(FileName, json);
            var student = new Student
            {
                Id = "1"
            };
            var jsonStudentDao = new JsonStudentDao();
            jsonStudentDao.Delete(student);
            var jsonList = jsonStudentDao.GetAll();
            Assert.AreEqual(0, jsonList.Count);
        }
    }
}