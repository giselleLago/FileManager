﻿using FileManager.Common.Layer.Entities;
using System.Collections.Generic;

namespace FileManager.DataAccess.Data.Services
{
    public interface IStudentDao
    {
        List<Student> GetAll();
        Student Create(Student student);
        Student Update(Student student);
        void Delete(int studentId);
    }
}
