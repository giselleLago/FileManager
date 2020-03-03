using FileManager.Common.Layer;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager.DataAccess.Data
{
    public class TxtStudentDao
    {
        private const string FileName = "students.txt";
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
