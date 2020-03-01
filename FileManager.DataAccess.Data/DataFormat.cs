

using System.ComponentModel;

namespace FileManager.DataAccess.Data
{
    public enum DataFormat
    {
        [Description("JSON")]
        JSON = 0,
        [Description("XML")]
        XML = 1
    }
}