using System.Collections.Generic;
using System.Linq;
using ExifReader.Extensibility;
using ExifTool.Dto;
using PhotSortComponent.Dto;
using PhotSortComponent.Extensibility;

namespace PhotSortComponentTest.Mocked
{
    public class MockedImageDataSorter : IImageDataSorter
    {
        public IList<ContainerDto> GetSortedImages(IList<IExifDataDto> images)
        {
            var containers = GenerateContainers(3, 20).ToList();

            var darkContainer = GenerateContainers(1, 10);

            containers.AddRange(darkContainer);

            return containers;
        }

        private IList<ContainerDto> GenerateContainers(int numberOfContainers, int numberOfImages)
        {
            string containerDefaultName = "var{0}";

            var containerList = new List<ContainerDto>();

            for (int i = 0; i < numberOfContainers; i++)
            {
                var indexOfContainer = i + 1;
                var container = new ContainerDto { ContainerName = string.Format(containerDefaultName, indexOfContainer.ToString()) };
                container.ImageList = GenerateImageList(numberOfImages);
                containerList.Add(container);
            }

            return containerList;
        }

        private IList<IExifDataDto> GenerateImageList(int numberOfImages)
        {
            string imageStartName = "IMG17{0:00}.CR2";
            string fullPath = @"D:\Pictures\2018\2018_10_31\{0}";
            string directory = @"D:\Pictures\2018\2018_10_31";

            var listOfImages = new List<IExifDataDto>();

            for (int i = 0; i < numberOfImages; i++)
            {
                string fileName = string.Format(imageStartName, i);
                var image = new ExifDataDto
                {
                    FileName = fileName,
                    FullPath = string.Format(fullPath, fileName),
                    Directory = directory,
                    IsoLevel = 800
                };
                listOfImages.Add(image);
            }
            return listOfImages;
        }
    }
}