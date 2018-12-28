using System.Collections.Generic;
using System.IO;
using ExifReader.Extensibility;
using ExifTool.Extensibility;
using PhotSortComponent.Extensibility;

namespace PhotSortComponent.Domain
{
    public class ImageDataCollector : IImageDataCollector
    {
        private readonly IExifReader exifDataReader;

        public ImageDataCollector(IExifReader exifDataReader)
        {
            this.exifDataReader = exifDataReader;
        }

        public IList<IExifDataDto> ReadExifDataOfFiles(string folderName)
        {
            var filesData = new List<IExifDataDto>();

            foreach (var filePath in Directory.EnumerateFiles(folderName))
            {
                var fileData = ReadExifDataOfFile(filePath);
                filesData.Add(fileData);
            }
            return filesData;
        }

        private IExifDataDto ReadExifDataOfFile(string filePath)
        {
            var exifDataDto = exifDataReader.ReadExifData(filePath);
            return exifDataDto;
        }
    }
}