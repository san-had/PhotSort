using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExifReader.Extensibility;
using ExifTool.Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using PhotSortComponent.Domain;
using PhotSortComponent.Extensibility;

namespace PhotSortComponentTest.Domain
{
    [TestClass]
    public class ImageDataCollectorTest
    {
        private static IKernel kernel;

        [ClassInitialize]
        public static void OneTimeSetup(TestContext testContext)
        {
            kernel = new StandardKernel();
            kernel.Bind<IExifReader>().To<ExifTool.ExifReader>();
            kernel.Bind<IImageDataCollector>().To<ImageDataCollector>();
        }

        [TestMethod]
        public async void ReadExifDataOfFilesTest()
        {
            string folderName = @"..\..\Resources\2018_10_31\";
            string fullPath = Path.GetFullPath(folderName);

            var exifReader = kernel.Get<IExifReader>();
            var imageDataCollector = kernel.Get<IImageDataCollector>();
            IList<IExifDataDto> imageDataList = await imageDataCollector.ReadExifDataOfFiles(fullPath);

            var expectedNumberOfImages = 9;
            var actualNumberOfImages = imageDataList.Count();

            var expectedFileNameOfImage5 = "IMG_1780.CR2";
            var actualFileNameOfImage5 = imageDataList[4].FileName;

            Assert.AreEqual(expectedNumberOfImages, actualNumberOfImages);
            Assert.AreEqual(expectedFileNameOfImage5, actualFileNameOfImage5);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            kernel.Dispose();
        }
    }
}