using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExifReader.Extensibility;
using ExifTool.Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using PhotSortComponent.Domain;
using PhotSortComponent.Extensibility;

namespace PhotSortComponentTest
{
    [TestClass]
    public class ImageDataSorterTest
    {
        private static IKernel kernel;

        [ClassInitialize]
        public static void OneTimeSetup(TestContext testContext)
        {
            kernel = new StandardKernel();
            kernel.Bind<IExifReader>().To<ExifTool.ExifReader>();
            kernel.Bind<IImageDataCollector>().To<ImageDataCollector>();
            kernel.Bind<IImageDataSorter>().To<ImageDataSorter>();
        }

        [TestMethod]
        public void GetSortedRealImagesTest()
        {
            string folderName = @"..\..\Resources\2018_10_31\";
            string fullPath = Path.GetFullPath(folderName);

            var imageDataCollector = kernel.Get<IImageDataCollector>();
            IList<IExifDataDto> imageDataList = imageDataCollector.ReadExifDataOfFiles(fullPath);
            var imageSorter = kernel.Get<IImageDataSorter>();
            var sortedImageList = imageSorter.GetSortedImages(imageDataList);

            var expectedNumberOfContainers = 3;
            var actualNumberOfContainers = sortedImageList.Count();

            var expectedNumberOfImagesInSecondContainer = 3;
            var actualNumberOfImagesInSecondContainer = sortedImageList[1].ImageList.Count();

            var expectedNameOfSecondContainer = "var2";
            var actualNameOfSecondContainer = sortedImageList[1].ContainerName;

            Assert.AreEqual(expectedNumberOfContainers, actualNumberOfContainers);
            Assert.AreEqual(expectedNumberOfImagesInSecondContainer, actualNumberOfImagesInSecondContainer);
            Assert.AreEqual(expectedNameOfSecondContainer, actualNameOfSecondContainer);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            kernel.Dispose();
        }
    }
}