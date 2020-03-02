using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data.Tests
{
    [TestClass()]
    public class XmlStudentDaoTests
    {
        private const string FileName = "students.xml";

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
        public void GetAll_GivenOneStudentInFile_ShouldReturnAListWithOneElement()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><ArrayOfStudent xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Student>    <Id>1</Id>    <Name>Peter</Name>    <LastName>Parker</LastName>    <Age>22</Age>  </Student><Student>    <Id>1</Id>    <Name>Peter</Name>    <LastName>Parker</LastName>    <Age>22</Age>  </Student></ArrayOfStudent>";
            File.WriteAllText(FileName, xml);
            var xmlStudentDao = new XmlStudentDao();
            var list = xmlStudentDao.GetAll();
            Assert.AreEqual(2, list.Count);
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
            var xmlStudentDao = new XmlStudentDao();
            xmlStudentDao.Create(student);
            var list = xmlStudentDao.GetAll();
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod()]
        public void Delete_GivenOneStudentInFile_ShouldReturnAnEmptyList()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><ArrayOfStudent xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Student>    <Id>1</Id>    <Name>Peter</Name>    <LastName>Parker</LastName>    <Age>22</Age>  </Student></ArrayOfStudent>";
            File.WriteAllText(FileName, xml);
            var student = new Student
            {
                Id = 1
            };
            var xmlStudentDao = new XmlStudentDao();
            xmlStudentDao.Delete(student);
            var list = xmlStudentDao.GetAll();
            Assert.AreEqual(0, list.Count);
        }
    }
}