using FileManager.Common.Layer.Entities;
using FileManager.Common.Layer.Exceptions;
using log4net;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace FileManager.DataAccess.Data.Services
{
    public class TxtStudentDao : IStudentDao
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(TxtStudentDao));
        private readonly string FileName = ConfigurationManager.AppSettings["txt"].ToString();
        public List<Student> GetAll()
        {
            if (File.Exists(FileName))
            {
                return DeserializeObject();
            }
            logger.Info("The file dosen't exist. Return empty list.");
            return new List<Student>();
        }

        public Student Create(Student student)
        {
            var studentList = GetAll();
            studentList.Add(student);
            SerializeObject(studentList);
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
            SerializeObject(studentList);
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
            SerializeObject(studentList);
        }

        private void SerializeObject(List<Student> studentList)
        {
            using (var tw = new StreamWriter(FileName))
            {
                foreach (var item in studentList)
                {
                    tw.WriteLine(string.Format("{0},{1},{2},{3}", item.Id, item.Name, item.LastName, item.Age));
                }
            }
        }
        private List<Student> DeserializeObject()
        {
            var studentList = new List<Student>();
            var logFile = File.ReadLines(FileName).ToList();
            for (int i = 0; i < logFile.Count; i++)
            {
                var line = logFile.ElementAt(i);
                var data = line.Split(',');
                var student = new Student
                {
                    Id = int.Parse(data[0]),
                    Name = data[1],
                    LastName = data[2],
                    Age = int.Parse(data[3])
                };
                studentList.Add(student);
            }
            return studentList;
        }
    }
}
