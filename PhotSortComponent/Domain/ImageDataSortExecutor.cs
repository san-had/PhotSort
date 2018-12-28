using System.Collections.Generic;
using System.IO;
using System.Linq;
using PhotSortComponent.Dto;
using PhotSortComponent.Extensibility;

namespace PhotSortComponent.Domain
{
    public class ImageDataSortExecutor : IImageDataSortExecutor
    {
        public IList<string> SortImages(IList<ContainerDto> imageContainers)
        {
            MoveImages(imageContainers);

            var sortResultList = CreateSortedResultList(imageContainers);

            return sortResultList;
        }

        public IList<string> CreateSortedResultList(IList<ContainerDto> imageContainers)
        {
            var sortResultList = new List<string>();

            foreach (var container in imageContainers)
            {
                var sortResultRecord = $"{container.ContainerName} - {container.ImageList.Count().ToString()} x {container.ImageList.First().IsoLevel.ToString()}";
                sortResultList.Add(sortResultRecord);
            }
            return sortResultList;
        }

        private void MoveImages(IList<ContainerDto> imageContainers)
        {
            foreach (var container in imageContainers)
            {
                foreach (var image in container.ImageList)
                {
                    Directory.CreateDirectory(image.DirectoryNew);
                    File.Move(image.FullPath, image.FullPathNew);
                }
            }
        }
    }
}