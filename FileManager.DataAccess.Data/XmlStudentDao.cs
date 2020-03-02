using FileManager.Common.Layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace FileManager.DataAccess.Data
{
    public class XmlStudentDao : IStudentDao
    {
        
        private const string FileName = "students.xml";
        public List<Student> GetAll()
        {
            if (File.Exists(FileName))
            {
                return DeserializeObject();
            }

            return new List<Student>();
        }

        public Student Create(Student student)
        {
            var studentList = GetAll();
            studentList.Add(student);
            SerializeObject(studentList);
            return student;
        }

        public Student Update(Student studentUpdate)
        {
            var studentList = GetAll();
            var student = studentList.FirstOrDefault(x => x.Id == studentUpdate.Id);
            if (student == null)
            {
                throw new StudentNotFoundException();
            }
            student.Name = studentUpdate.Name;
            student.LastName = studentUpdate.LastName;
            student.Age = studentUpdate.Age;
            SerializeObject(studentList);
            return studentUpdate;
        }

        public void Delete(Student studentDelete)
        {
            var studentList = GetAll();
            var student = studentList.FirstOrDefault(x => x.Id == studentDelete.Id);
            if (student == null)
            {
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
