using FileManager.Common.Layer;
using FileManager.Common.Layer.Exceptions;
using log4net;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace FileManager.DataAccess.Data
{
    public class StudentDaoFactory : IAbstractFactory
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(StudentDaoFactory));
        public IStudentDao Create(DataFormat format)
        {
            var root = XElement.Load("repositoryConfiguration.xml");
            var element = root.Elements("Type")
                .FirstOrDefault(x => x.Attribute("Id").Value == format.ToString());

            if (element == null)
            {
                logger.Fatal("Unsupported data format.");
                throw new UnsupportedDataFormatException();
            }
            
            var typeName = element.Element("class").Value;
            var assembly = Assembly.GetExecutingAssembly();
            Type daoType = assembly.GetType(typeName);
            return Activator.CreateInstance(daoType) as IStudentDao;
        }
    }
}
