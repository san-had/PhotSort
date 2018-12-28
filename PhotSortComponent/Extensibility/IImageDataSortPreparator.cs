using System.Collections.Generic;
using ExifReader.Extensibility;
using PhotSortComponent.Dto;

namespace PhotSortComponent.Extensibility
{
    public interface IImageDataSortPreparator
    {
        void PrepareImages(IList<ContainerDto> imageContainers, string[] containerNames);

        void SetContainerNames(IList<ContainerDto> imageContainers, string[] containerNames);

        void SetNewFullPathForImage(string containerName, IExifDataDto image);

        void SetNewFullPathForImages(IList<ContainerDto> imageContainers);
    }
}