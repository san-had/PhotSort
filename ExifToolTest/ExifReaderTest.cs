using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExifToolTest
{
    [TestClass]
    public class ExifReaderTest
    {
        [TestMethod]
        public void ReadExifData()
        {
            string fileName = @"..\..\Resources\IMG_1759.CR2";
            string fullPath = Path.GetFullPath(fileName);

            var exifReader = new ExifTool.ExifReader();
            var exifDataDto = exifReader.ReadExifData(fullPath);

            string expectedFileName = "IMG_1759.CR2";
            string actualFileName = exifDataDto.FileName;

            string expectedDirectory = Path.GetDirectoryName(fullPath);
            string actualDirectory = exifDataDto.Directory;

            string expectedFullPath = fullPath;
            string actualFullPath = exifDataDto.FullPath;

            DateTime expectedDateTime = new DateTime(2018, 10, 31, 5, 1, 56);
            DateTime actualDateTime = exifDataDto.TakenDateTime;

            int expectedIsoLevel = 200;
            int actualIsoLevel = exifDataDto.IsoLevel;

            Assert.AreEqual(expectedFileName, actualFileName);
            Assert.AreEqual(expectedDirectory, actualDirectory);
            Assert.AreEqual(expectedFullPath, actualFullPath);

            Assert.AreEqual(expectedDateTime, actualDateTime);
            Assert.AreEqual(expectedIsoLevel, actualIsoLevel);
        }
    }
}