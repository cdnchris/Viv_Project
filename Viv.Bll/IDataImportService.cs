using System.Threading.Tasks;

namespace Viv.Bll
{
    public interface IDataImportService
    {
        Task ImportDataAsync(byte[] fileData);
        Task ClearAllDataAsync();
    }
}
