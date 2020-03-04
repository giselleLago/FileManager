using FileManager.Common.Layer;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace FileManager.DataAccess.Data
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

        public Student Update(Student studentUpdate)
        {
            var studentList = GetAll();
            var student = studentList.FirstOrDefault(x => x.Id == studentUpdate.Id);
            if (student == null)
            {
                logger.Warn("Student not found.");
                throw new StudentNotFoundException();
            }
            student.Name = studentUpdate.Name;
            student.LastName = studentUpdate.LastName;
            student.Age = studentUpdate.Age;
            var json = JsonConvert.SerializeObject(studentList);
            File.WriteAllText(FileName, json);
            return studentUpdate;
        }

        public void Delete(Student studentDelete)
        {
            var studentList = GetAll();
            var student = studentList.FirstOrDefault(x => x.Id == studentDelete.Id);
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
