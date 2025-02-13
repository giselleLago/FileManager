﻿using FileManager.Common.Layer.Entities;
using FileManager.Common.Layer.Exceptions;
using log4net;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Serialization;


namespace FileManager.DataAccess.Data.Services
{
    public class XmlStudentDao : IStudentDao
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(XmlStudentDao));
        private readonly string FileName = ConfigurationManager.AppSettings["xml"].ToString();
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
            var serializer = new XmlSerializer(studentList.GetType());
            using (var writer = new StreamWriter(FileName))
            {
                serializer.Serialize(writer, studentList);
            }
        }

        private List<Student> DeserializeObject()
        {
            var xml = File.ReadAllText(FileName);
            var serializer = new XmlSerializer(typeof(List<Student>));
            return (List<Student>)serializer.Deserialize(new StringReader(xml));
        }
    }
}
