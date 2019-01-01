using System.Collections.Generic;
using System.Threading.Tasks;
using ExifReader.Extensibility;

namespace PhotSortComponent.Extensibility
{
    public interface IImageDataCollector
    {
        Task<IList<IExifDataDto>> ReadExifDataOfFiles(string folderName);
    }
}