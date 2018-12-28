using System;
using ExifReader.Extensibility;

namespace ExifTool.Dto
{
    public class ExifDataDto : IExifDataDto
    {
        public string FileName { get; set; }

        public DateTime TakenDateTime { get; set; }

        public int IsoLevel { get; set; }

        public string Directory { get; set; }

        public string DirectoryNew { get; set; }

        public string FullPath { get; set; }

        public string FullPathNew { get; set; }
    }
}