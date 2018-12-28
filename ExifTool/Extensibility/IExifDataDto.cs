using System;

namespace ExifReader.Extensibility
{
    public interface IExifDataDto
    {
        string FileName { get; set; }

        string Directory { get; set; }

        string DirectoryNew { get; set; }

        string FullPath { get; set; }

        string FullPathNew { get; set; }

        DateTime TakenDateTime { get; set; }

        int IsoLevel { get; set; }
    }
}