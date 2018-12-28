using System;
using System.IO;
using System.Linq;
using ExifReader.Extensibility;
using ExifTool.Dto;
using ExifTool.Extensibility;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace ExifTool
{
    public class ExifReader : IExifReader
    {
        public IExifDataDto ReadExifData(string fullPath)
        {
            var directory = ImageMetadataReader.ReadMetadata(fullPath).OfType<ExifSubIfdDirectory>().FirstOrDefault();

            if (directory == null)
            {
                return null;
            }

            var exifData = new ExifDataDto();

            exifData.FileName = Path.GetFileName(fullPath);
            exifData.Directory = Path.GetDirectoryName(fullPath);
            exifData.FullPath = fullPath;

            exifData.TakenDateTime = GetTakendateTime(directory) ?? default(DateTime);
            exifData.IsoLevel = GetIsoLevel(directory) ?? default(int);

            return exifData;
        }

        private DateTime? GetTakendateTime(ExifSubIfdDirectory directory)
        {
            if (directory.TryGetDateTime(ExifDirectoryBase.TagDateTimeOriginal, out var dateTime))
            {
                return dateTime;
            }

            return null;
        }

        private int? GetIsoLevel(ExifSubIfdDirectory directory)
        {
            if (directory.TryGetInt32(ExifDirectoryBase.TagIsoEquivalent, out var iso))
            {
                return iso;
            }

            return null;
        }
    }
}