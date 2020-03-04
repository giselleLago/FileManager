namespace FileManager.DataAccess.Data.Services
{
    public interface IAbstractFactory
    {
        IStudentDao Create(DataFormat format);
    }
}
