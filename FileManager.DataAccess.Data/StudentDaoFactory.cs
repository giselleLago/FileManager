namespace FileManager.DataAccess.Data
{
    public static class StudentDaoFactory
    {
        public static IStudentDao Create(DataFormat format)
        {
            switch (format)
            {
                case DataFormat.JSON:
                    {
                        return new JsonStudentDao();
                    }
                default:
                    {
                        return new XmlStudentDao();
                    }
            }
        }
    }
}
