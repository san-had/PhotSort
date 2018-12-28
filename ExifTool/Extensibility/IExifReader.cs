using ExifReader.Extensibility;

namespace ExifTool.Extensibility
{
    public interface IExifReader
    {
        IExifDataDto ReadExifData(string fileName);
    }
}