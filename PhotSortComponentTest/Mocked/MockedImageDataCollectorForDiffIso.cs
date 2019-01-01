using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExifReader.Extensibility;
using ExifTool.Dto;
using PhotSortComponent.Extensibility;

namespace PhotSortComponentTest.Mocked
{
    public class MockedImageDataCollectorForDiffIso : IImageDataCollector
    {
        public async Task<IList<IExifDataDto>> ReadExifDataOfFiles(string folderName)
        {
            var listOfFakeImages = new List<IExifDataDto>();

            var firstImageList = await GenerateImageList("IMG17{0:00}", new DateTime(2018, 10, 31, 18, 0, 0), 200, 20);

            listOfFakeImages.AddRange(firstImageList);

            var secondImageList = await GenerateImageList("IMG18{0:00}", new DateTime(2018, 10, 31, 18, 2, 6), 200, 20);

            listOfFakeImages.AddRange(secondImageList);

            var thirdImageList = await GenerateImageList("IMG19{0:00}", new DateTime(2018, 10, 31, 18, 4, 12), 200, 10);

            listOfFakeImages.AddRange(thirdImageList);

            return listOfFakeImages;
        }

        private async Task<IList<IExifDataDto>> GenerateImageList(string startName, DateTime startDateTime, int isoLevel, int numberOfImages)
        {
            var listOfImages = new List<IExifDataDto>();

            await Task.Run(() =>
            {
                for (int i = 0; i < numberOfImages; i++)
                {
                    var image = new ExifDataDto
                    {
                        FileName = string.Format(startName, i),
                        TakenDateTime = startDateTime.AddSeconds(i * 5),
                        IsoLevel = i < (numberOfImages / 2) ? isoLevel / 2 : isoLevel
                    };
                    listOfImages.Add(image);
                }
            });

            return listOfImages;
        }
    }
}