using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using PhotSortComponent.Domain;
using PhotSortComponent.Extensibility;
using PhotSortComponentTest.Mocked;

namespace PhotSortComponentTest.Domain
{
    [TestClass]
    public class ImageDataExecutorTest
    {
        private static IKernel kernel;

        [ClassInitialize]
        public static void OneTimeSetup(TestContext testContext)
        {
            kernel = new StandardKernel();
            kernel.Bind<IImageDataSorter>().To<MockedImageDataSorter>();
            kernel.Bind<IImageDataSortExecutor>().To<ImageDataSortExecutor>();
        }

        [TestMethod]
        public void CheckCreatingSortedResultList()
        {
            var mockedImageDataSorter = kernel.Get<IImageDataSorter>();
            var mockedImageDataSortedList = mockedImageDataSorter.GetSortedImages(null);
            var imageDataSortExecutor = kernel.Get<IImageDataSortExecutor>();

            var sortResultList = imageDataSortExecutor.CreateSortedResultList(mockedImageDataSortedList);

            int expectedRecordCount = 4;
            int actualRecordCount = sortResultList.Count;
            Assert.AreEqual(expectedRecordCount, actualRecordCount);

            string expectedResultRecord = "var2 - 20 x 800";
            string actualResultRecord = sortResultList[1];
            Assert.AreEqual(expectedResultRecord, actualResultRecord);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            kernel.Dispose();
        }
    }
}