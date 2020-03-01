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
            IStudentDao jsonList = new JsonStudentDao();
            var j = jsonList.GetAll();
        }
    }
}
