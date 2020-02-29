using FileManager.Common.Layer;
using FileManager.DataAccess.Data;
using System;
using System.Collections.Generic;


namespace FileManager.Presentation.WinSite
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var list = new List<Student>
            {
                new Student { StudentId = 1, Name = "Pepe", SurName = "Pepe", Age = 12},
                new Student { StudentId = 2, Name = "Pepe", SurName = "Pepe", Age = 12},
                new Student { StudentId = 3, Name = "Pepe", SurName = "Pepe", Age = 12},
                new Student { StudentId = 4, Name = "Pepe", SurName = "Pepe", Age = 12},
                new Student { StudentId = 5, Name = "Pepe", SurName = "Pepe", Age = 12}
            };
            IStudentRepository jsonList = new JsonGenerator();
            var j = jsonList.GetAll(list);
        }
    }
}
