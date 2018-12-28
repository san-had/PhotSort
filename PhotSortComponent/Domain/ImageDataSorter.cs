using System;
using System.Collections.Generic;
using ExifReader.Extensibility;
using PhotSortComponent.Dto;
using PhotSortComponent.Extensibility;

namespace PhotSortComponent.Domain
{
    public class ImageDataSorter : IImageDataSorter
    {
        private const int THRESHOLD = 45;

        private const string CONTAINER_NAME = "var";

        public IList<ContainerDto> GetSortedImages(IList<IExifDataDto> images)
        {
            var containerList = new List<ContainerDto>();

            ContainerDto container = new ContainerDto(); ;

            int containerNameIndex = 1;

            DateTime prevImageDateTime = DateTime.MinValue;

            int prevIsoLevel = 0;

            for (int i = 0; i < images.Count; i++)
            {
                var isInNewSequence = GetIsInNewSequence(
                    prevImageDateTime,
                    images[i].TakenDateTime,
                    prevIsoLevel,
                    images[i].IsoLevel);

                if (isInNewSequence)
                {
                    if (i > 0)
                    {
                        containerList.Add(container);
                        container = new ContainerDto();
                        containerNameIndex++;
                    }

                    container.ContainerName = $"{CONTAINER_NAME}{containerNameIndex}";
                }
                container.ImageList.Add(images[i]);

                prevImageDateTime = images[i].TakenDateTime;
                prevIsoLevel = images[i].IsoLevel;
            }
            containerList.Add(container);

            return containerList;
        }

        private bool GetIsInNewSequence(
            DateTime prevImageDateTime,
            DateTime takenDateTime,
            int prevIsoLevel,
            int currentIsoLevel)
        {
            var diffInSeconds = takenDateTime.Subtract(prevImageDateTime).TotalSeconds;

            return diffInSeconds > THRESHOLD || prevIsoLevel != currentIsoLevel;
        }
    }
}