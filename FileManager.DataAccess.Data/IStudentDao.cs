using FileManager.Common.Layer.Entities;
using System.Collections.Generic;

namespace FileManager.DataAccess.Data
{
    public interface IStudentDao
    {
        List<Student> GetAll();
        Student Create(Student student);
        Student Update(Student studentUpdate);
        void Delete(Student studentDelete);
    }
}
