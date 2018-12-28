using System.Collections.Generic;
using ExifReader.Extensibility;

namespace PhotSortComponent.Extensibility
{
    public interface IImageDataCollector
    {
        IList<IExifDataDto> ReadExifDataOfFiles(string folderName);
    }
}