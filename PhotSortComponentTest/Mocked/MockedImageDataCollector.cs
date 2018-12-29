using System;
using System.Collections.Generic;
using ExifReader.Extensibility;
using ExifTool.Dto;
using PhotSortComponent.Extensibility;

namespace PhotSortComponentTest.Mocked
{
    public class MockedImageDataCollector : IImageDataCollector
    {
        public IList<IExifDataDto> ReadExifDataOfFiles(string folderName)
        {
            var listOfFakeImages = new List<IExifDataDto>();

            var firstImageList = GenerateImageList("IMG17{0:00}", new DateTime(2018, 10, 31, 18, 0, 0), 200, 20);

            listOfFakeImages.AddRange(firstImageList);

            var secondImageList = GenerateImageList("IMG18{0:00}", new DateTime(2018, 10, 31, 18, 2, 21), 200, 20);

            listOfFakeImages.AddRange(secondImageList);

            var thirdImageList = GenerateImageList("IMG19{0:00}", new DateTime(2018, 10, 31, 18, 4, 42), 200, 10);

            listOfFakeImages.AddRange(thirdImageList);

            return listOfFakeImages;
        }

        private IList<IExifDataDto> GenerateImageList(string startName, DateTime startDateTime, int isoLevel, int numberOfImages)
        {
            var listOfImages = new List<IExifDataDto>();

            for (int i = 0; i < numberOfImages; i++)
            {
                var image = new ExifDataDto
                {
                    FileName = string.Format(startName, i),
                    TakenDateTime = startDateTime.AddSeconds(i * 5),
                    IsoLevel = isoLevel
                };
                listOfImages.Add(image);
            }
            return listOfImages;
        }
    }
}