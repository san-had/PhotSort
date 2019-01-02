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
            kernel.Bind<IImageDataSortPreparator>().To<ImageDataSortPreparator>();
            kernel.Bind<IImageDataSortExecutor>().To<ImageDataSortExecutor>();
        }

        [TestMethod]
        public void CheckCreatingSortedResultList()
        {
            var mockedImageDataSorter = kernel.Get<IImageDataSorter>();
            var mockedImageDataSortedList = mockedImageDataSorter.GetSortedImages(null);
            var imageDataSortPreparator = kernel.Get<IImageDataSortPreparator>();
            var imageDataSortExecutor = kernel.Get<IImageDataSortExecutor>();

            imageDataSortPreparator.PrepareImages(mockedImageDataSortedList, null);
            var sortResultList = imageDataSortExecutor.CreateSortedResultList(mockedImageDataSortedList);

            int expectedRecordCount = 6;
            int actualRecordCount = sortResultList.Count;
            Assert.AreEqual(expectedRecordCount, actualRecordCount);

            string expectedResultRecord = "var2 - 20 x 800";
            string actualResultRecord = sortResultList[1];
            Assert.AreEqual(expectedResultRecord, actualResultRecord);

            string expectedResultRecordAfterDark = "var4 - 20 x 800";
            string actualResultRecordAfterDark = sortResultList[4];
            Assert.AreEqual(expectedResultRecordAfterDark, actualResultRecordAfterDark);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            kernel.Dispose();
        }
    }
}