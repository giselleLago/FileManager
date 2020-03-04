namespace FileManager.DataAccess.Data
{
    public interface IAbstractFactory
    {
        IStudentDao Create(DataFormat format);
    }
}
