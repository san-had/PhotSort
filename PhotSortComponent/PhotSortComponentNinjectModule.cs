using ExifReader.Extensibility;
using ExifTool.Dto;
using ExifTool.Extensibility;
using Ninject.Modules;
using PhotSortComponent.Domain;
using PhotSortComponent.Extensibility;

namespace PhotSortComponent
{
    public class PhotSortComponentNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IExifDataDto>().To<ExifDataDto>();
            Bind<IExifReader>().To<ExifTool.ExifReader>();
            Bind<IImageDataCollector>().To<ImageDataCollector>();
            Bind<IImageDataSorter>().To<ImageDataSorter>();
            Bind<IImageDataSortPreparator>().To<ImageDataSortPreparator>();
            Bind<IImageDataSortExecutor>().To<ImageDataSortExecutor>();
            Bind<IMainSorter>().To<PhotSortMainComponent>();
        }
    }
}