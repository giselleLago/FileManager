using FileManager.Business.DTOs;
using FileManager.Common.Layer;
using FileManager.Common.Layer.Entities;
using FileManager.DataAccess.Data.Services;
using System.Collections.Generic;
using System.Linq;

namespace FileManager.Business.Services
{
    public class StudentService : IStudentService
    {
        private DataFormat _dataFormat;
        private IStudentDao _studentDao;

        public DataFormat DataFormat
        {
            get
            {
                return _dataFormat;
            }
            set
            {
                _dataFormat = value;
                var factory = new StudentDaoFactory();
                _studentDao = factory.Create(_dataFormat);
            }
        }

        public StudentService()
        {
            DataFormat = DataFormat.JSON;
        }

        public StudentDto Create(StudentDto student)
        {
            var entity = ToStudent(student);
            var result = _studentDao.Create(entity);
            return ToStudentDto(result);
        }

        public void Delete(StudentDto student)
        {
            var entity = ToStudent(student);
            _studentDao.Delete(entity);
        }

        public List<StudentDto> GetAll()
        {
            var entities = _studentDao.GetAll();
            return entities.Select(x => ToStudentDto(x)).ToList();
        }

        public StudentDto Update(StudentDto student)
        {
            var entity = ToStudent(student);
            var result = _studentDao.Update(entity);
            return ToStudentDto(result);
        }

        private Student ToStudent(StudentDto studentDto)
        {
            return new Student
            {
                Age = studentDto.Age,
                Id = studentDto.Id,
                LastName = studentDto.LastName,
                Name = studentDto.Name
            };
        }

        private StudentDto ToStudentDto(Student student)
        {
            return new StudentDto
            {
                Age = student.Age,
                Id = student.Id,
                LastName = student.LastName,
                Name = student.Name
            };
        }
    }
}
