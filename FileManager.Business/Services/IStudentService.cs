using FileManager.Business.DTOs;
using FileManager.Common.Layer;
using System.Collections.Generic;

namespace FileManager.Business.Services
{
    public interface IStudentService
    {
        DataFormat DataFormat { get; set; }
        List<StudentDto> GetAll();
        StudentDto Create(StudentDto student);
        StudentDto Update(StudentDto student);
        void Delete(StudentDto student);
    }
}
