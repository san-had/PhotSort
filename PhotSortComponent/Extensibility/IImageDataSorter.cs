using System.Collections.Generic;
using ExifReader.Extensibility;
using PhotSortComponent.Dto;

namespace PhotSortComponent.Extensibility
{
    public interface IImageDataSorter
    {
        IList<ContainerDto> GetSortedImages(IList<IExifDataDto> images);
    }
}