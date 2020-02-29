using FileManager.Common.Layer;
using System.Collections.Generic;

namespace FileManager.DataAccess.Data
{
    public interface IStudentRepository
    {
        string GetAll(IList<Student> studentList);
        Student Create(Student student);
        Student Read(Student student);

        Student Update(Student student);
        Student Delete(Student student);
    }
}
