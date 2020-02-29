using FileManager.Common.Layer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace FileManager.DataAccess.Data
{
    public class JsonGenerator : IStudentRepository
    {
        public string GetAll(IList<Student> studentList)
        {
            var jsonStudentList = JsonConvert.SerializeObject(studentList);
            return jsonStudentList;
        }

        public Student Create(Student student)
        {
            throw new NotImplementedException();
        }

        public Student Read(Student student)
        {
            throw new NotImplementedException();
        }

        public Student Update(Student student)
        {
            throw new NotImplementedException();
        }

        public Student Delete(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
