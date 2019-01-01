using System.Collections.Generic;
using System.Threading.Tasks;
using PhotSortComponent.Dto;

namespace PhotSortComponent.Extensibility
{
    public interface IImageDataSortExecutor
    {
        Task<IList<string>> SortImages(IList<ContainerDto> imageContainers);

        IList<string> CreateSortedResultList(IList<ContainerDto> imageContainers);
    }
}