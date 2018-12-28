using System.Collections.Generic;
using PhotSortComponent.Extensibility;

namespace PhotSortComponent
{
    public class PhotSortMainComponent : IMainSorter
    {
        private readonly IImageDataCollector imageDataCollector;
        private readonly IImageDataSorter imageDataSorter;
        private readonly IImageDataSortPreparator imageDataPreparator;
        private readonly IImageDataSortExecutor imageDataSortExecutor;

        public PhotSortMainComponent(
            IImageDataCollector imageDataCollector,
            IImageDataSorter imageDataSorter,
            IImageDataSortPreparator imageDataPreparator,
            IImageDataSortExecutor imageDataSortExecutor)
        {
            this.imageDataCollector = imageDataCollector;
            this.imageDataSorter = imageDataSorter;
            this.imageDataPreparator = imageDataPreparator;
            this.imageDataSortExecutor = imageDataSortExecutor;
        }

        public IList<string> SortProcessing(string folderName, string[] sequences)
        {
            var images = imageDataCollector.ReadExifDataOfFiles(folderName);

            var sortedImages = imageDataSorter.GetSortedImages(images);

            imageDataPreparator.PrepareImages(sortedImages, sequences);

            var sortResults = imageDataSortExecutor.SortImages(sortedImages);

            return sortResults;
        }
    }
}