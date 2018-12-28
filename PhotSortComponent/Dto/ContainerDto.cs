using System.Collections.Generic;
using ExifReader.Extensibility;

namespace PhotSortComponent.Dto
{
    public class ContainerDto
    {
        public ContainerDto()
        {
            ImageList = new List<IExifDataDto>();
        }

        public string ContainerName { get; set; }

        public IList<IExifDataDto> ImageList { get; set; }
    }
}