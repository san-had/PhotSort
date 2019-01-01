using System.Threading.Tasks;
using ExifReader.Extensibility;

namespace ExifTool.Extensibility
{
    public interface IExifReader
    {
        Task<IExifDataDto> ReadExifData(string fileName);
    }
}