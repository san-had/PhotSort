using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using PhotSortComponent.Domain;
using PhotSortComponent.Extensibility;
using PhotSortComponentTest.Mocked;

namespace PhotSortComponentTest
{
    [TestClass]
    public class ImageDataSorterMockedTest
    {
        private static IKernel kernel;

        [ClassInitialize]
        public static void OneTimeSetup(TestContext testContext)
        {
            kernel = new StandardKernel();
            kernel.Bind<IImageDataCollector>().To<MockedImageDataCollector>();
            kernel.Bind<IImageDataSorter>().To<ImageDataSorter>();
        }

        [TestMethod]
        public async Task GetSortedWithMockedImagesTest()
        {
            var mockedImageDataCollector = kernel.Get<IImageDataCollector>();

            var mockedImageDataList = await mockedImageDataCollector.ReadExifDataOfFiles(string.Empty);
            var imageSorter = kernel.Get<IImageDataSorter>();
            var sortedImageList = imageSorter.GetSortedImages(mockedImageDataList);

            var expectedNumberOfContainers = 3;
            var actualNumberOfContainers = sortedImageList.Count();
            Assert.AreEqual(expectedNumberOfContainers, actualNumberOfContainers);

            var expectedNumberOfImagesInSecondContainer = 20;
            var actualNumberOfImagesInSecondContainer = sortedImageList[1].ImageList.Count();
            Assert.AreEqual(expectedNumberOfImagesInSecondContainer, actualNumberOfImagesInSecondContainer);

            var expectedNameOfSecondContainer = "var2";
            var actualNameOfSecondContainer = sortedImageList[1].ContainerName;
            Assert.AreEqual(expectedNameOfSecondContainer, actualNameOfSecondContainer);

            var expectedNumberOfImagesInThirdContainer = 10;
            var actualNumberOfImagesInThirdContainer = sortedImageList[2].ImageList.Count();
            Assert.AreEqual(expectedNumberOfImagesInThirdContainer, actualNumberOfImagesInThirdContainer);

            var expectedNameOfThirdContainer = "var3";
            var actualNameOfThirdContainer = sortedImageList[2].ContainerName;
            Assert.AreEqual(expectedNameOfThirdContainer, actualNameOfThirdContainer);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            kernel.Dispose();
        }
    }
}