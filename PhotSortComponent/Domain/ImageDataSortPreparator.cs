using System.Collections.Generic;
using System.Linq;
using ExifReader.Extensibility;
using PhotSortComponent.Dto;
using PhotSortComponent.Extensibility;

namespace PhotSortComponent.Domain
{
    public class ImageDataSortPreparator : IImageDataSortPreparator
    {
        public void PrepareImages(IList<ContainerDto> imageContainers, string[] containerNames)
        {
            SetContainerNames(imageContainers, containerNames);

            SetNewFullPathForImages(imageContainers);
        }

        public void SetContainerNames(IList<ContainerDto> imageContainers, string[] containerNames)
        {
            int containerNameIndex = 0;
            for (int i = 0; i < imageContainers.Count; i++)
            {
                if (imageContainers[i].ImageList.Count == 10)
                {
                    int isoLevel = imageContainers[i].ImageList.First().IsoLevel;
                    imageContainers[i].ContainerName = $"dark{isoLevel.ToString()}";
                }
                else
                {
                    string newContainerName = containerNames?.ElementAtOrDefault<string>(containerNameIndex);
                    if (!string.IsNullOrEmpty(newContainerName))
                    {
                        imageContainers[i].ContainerName = newContainerName;
                        containerNameIndex++;
                    }
                }
            }
        }

        public void SetNewFullPathForImage(string containerName, IExifDataDto image)
        {
            image.DirectoryNew = $"{image.Directory}\\{containerName}";
            image.FullPathNew = $"{image.Directory}\\{containerName}\\{image.FileName}";
        }

        public void SetNewFullPathForImages(IList<ContainerDto> imageContainers)
        {
            for (int i = 0; i < imageContainers.Count; i++)
            {
                string containerName = imageContainers[i].ContainerName;

                for (int j = 0; j < imageContainers[i].ImageList.Count; j++)
                {
                    SetNewFullPathForImage(containerName, imageContainers[i].ImageList[j]);
                }
            }
        }
    }
}