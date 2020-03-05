using FileManager.Common.Layer.Entities;
using FileManager.Common.Layer.Exceptions;
using log4net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace FileManager.DataAccess.Data.Services
{
    public class JsonStudentDao : IStudentDao
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(JsonStudentDao));
        private readonly string FileName = ConfigurationManager.AppSettings["json"].ToString();
        public List<Student> GetAll()
        {
            if (File.Exists(FileName))
            {
                var readText = File.ReadAllText(FileName);
                var studentList = JsonConvert.DeserializeObject<List<Student>>(readText);
                return studentList;
            }
            logger.Info("The file dosen't exist. Return empty list.");
            return new List<Student>();
        }

        public Student Create(Student student)
        {
            var studentList = GetAll();
            studentList.Add(student);
            var json = JsonConvert.SerializeObject(studentList);
            File.WriteAllText(FileName, json);
            return student;
        }

        public Student Update(Student student)
        {
            var studentList = GetAll();
            var oldStudent = studentList.FirstOrDefault(x => x.Id == student.Id);
            if (oldStudent == null)
            {
                logger.Warn("Student not found.");
                throw new StudentNotFoundException();
            }
            oldStudent.Name = student.Name;
            oldStudent.LastName = student.LastName;
            oldStudent.Age = student.Age;
            var json = JsonConvert.SerializeObject(studentList);
            File.WriteAllText(FileName, json);
            return student;
        }

        public void Delete(int studentId)
        {
            var studentList = GetAll();
            var student = studentList.FirstOrDefault(x => x.Id == studentId);
            if (student == null)
            {
                logger.Warn("Student not found.");
                throw new StudentNotFoundException();
            }
            studentList.Remove(student);
            var json = JsonConvert.SerializeObject(studentList);
            File.WriteAllText(FileName, json); 
        }
    }
}
