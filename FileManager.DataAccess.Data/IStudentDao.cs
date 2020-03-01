using FileManager.Common.Layer;
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
