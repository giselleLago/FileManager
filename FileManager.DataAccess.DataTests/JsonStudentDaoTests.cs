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
    }
}