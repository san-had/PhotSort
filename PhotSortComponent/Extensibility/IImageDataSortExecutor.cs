using System.Collections.Generic;
using PhotSortComponent.Dto;

namespace PhotSortComponent.Extensibility
{
    public interface IImageDataSortExecutor
    {
        IList<string> SortImages(IList<ContainerDto> imageContainers);

        IList<string> CreateSortedResultList(IList<ContainerDto> imageContainers);
    }
}