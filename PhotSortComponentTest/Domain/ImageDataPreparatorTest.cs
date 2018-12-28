using ExifTool.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using PhotSortComponent.Domain;
using PhotSortComponent.Extensibility;
using PhotSortComponentTest.Mocked;

namespace PhotSortComponentTest
{
    [TestClass]
    public class ImageDataPreparatorTest
    {
        private static IKernel kernel;

        [ClassInitialize]
        public static void OneTimeSetup(TestContext testContext)
        {
            kernel = new StandardKernel();
            kernel.Bind<IImageDataSorter>().To<MockedImageDataSorter>();
            kernel.Bind<IImageDataSortPreparator>().To<ImageDataSortPreparator>();
        }

        [TestMethod]
        public void CheckSettingContainerNamesForNullSequence()
        {
            string[] sequence = null;
            string expectedFirstContainerName = "var1";
            RunCheckContainerNameTests(sequence, expectedFirstContainerName);
        }

        [TestMethod]
        public void CheckSettingContainerNamesForEmptySequence()
        {
            var sequence = new string[] { };
            string expectedFirstContainerName = "var1";
            RunCheckContainerNameTests(sequence, expectedFirstContainerName);
        }

        [TestMethod]
        public void CheckSettingContainerNamesForMoreSequence()
        {
            var sequence = new string[] { "T_Cep", "V_Boo", "Chi_Cyg", "UU_Aur", "W_Cyg" };
            string expectedFirstContainerName = "T_Cep";
            RunCheckContainerNameTests(sequence, expectedFirstContainerName);
        }

        [TestMethod]
        public void CheckSettingContainerNamesForLessSequence()
        {
            var sequence = new string[] { "T_Cep", "V_Boo" };
            string expectedFirstContainerName = "T_Cep";
            RunCheckContainerNameTests(sequence, expectedFirstContainerName);
        }

        [TestMethod]
        public void CheckSettingContainerNamesForEqualSequence()
        {
            var sequence = new string[] { "T_Cep", "V_Boo", "Chi_Cyg" };
            string expectedFirstContainerName = "T_Cep";
            RunCheckContainerNameTests(sequence, expectedFirstContainerName);
        }

        [TestMethod]
        public void CheckSettingFullPathForImage()
        {
            string containerName = "var1";
            var image = new ExifDataDto
            {
                FileName = "IMG1780.CR2",
                Directory = @"D:\Pictures\2018\2018_10_31",
                FullPath = @"D:\Pictures\2018\2018_10_31\IMG1780.CR2"
            };
            var imageDataSortPreparator = kernel.Get<IImageDataSortPreparator>();
            imageDataSortPreparator.SetNewFullPathForImage(containerName, image);

            string expectedDirectoryNew = @"D:\Pictures\2018\2018_10_31\var1";
            string actualDirectoryNew = image.DirectoryNew;
            Assert.AreEqual(expectedDirectoryNew, actualDirectoryNew);

            string expectedFullPathNew = @"D:\Pictures\2018\2018_10_31\var1\IMG1780.CR2";
            string actualFullPathNew = image.FullPathNew;
            Assert.AreEqual(expectedFullPathNew, actualFullPathNew);
        }

        [TestMethod]
        public void CheckSettingFullPathForImageCollection()
        {
            var mockedImageDataSorter = kernel.Get<IImageDataSorter>();
            var mockedImageDataSortedList = mockedImageDataSorter.GetSortedImages(null);
            var imageDataSortPreparator = kernel.Get<IImageDataSortPreparator>();

            imageDataSortPreparator.SetNewFullPathForImages(mockedImageDataSortedList);

            var expectedFullPathNewForSecondContainerThirdImage = @"D:\Pictures\2018\2018_10_31\var2\IMG1702.CR2";
            var actualFullPathNewForSecondContainerThirdImage = mockedImageDataSortedList[1].ImageList[2].FullPathNew;
            Assert.AreEqual(expectedFullPathNewForSecondContainerThirdImage, actualFullPathNewForSecondContainerThirdImage);

            var expectedDirectoryNewForSecondContainerThirdImage = @"D:\Pictures\2018\2018_10_31\var2";
            var actualDirectoryhNewForSecondContainerThirdImage = mockedImageDataSortedList[1].ImageList[2].DirectoryNew;
            Assert.AreEqual(expectedDirectoryNewForSecondContainerThirdImage, actualDirectoryhNewForSecondContainerThirdImage);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            kernel.Dispose();
        }

        private void RunCheckContainerNameTests(string[] sequence, string expectedFirstContainerName)
        {
            var mockedImageDataSorter = kernel.Get<IImageDataSorter>();
            var mockedImageDataSortedList = mockedImageDataSorter.GetSortedImages(null);
            var imageDataSortPreparator = kernel.Get<IImageDataSortPreparator>();

            imageDataSortPreparator.SetContainerNames(mockedImageDataSortedList, sequence);

            string actualFirstContainerName = mockedImageDataSortedList[0].ContainerName;
            Assert.AreEqual(expectedFirstContainerName, actualFirstContainerName);

            string expectedDarkContainerName = "dark800";
            string actualDarkContainerName = mockedImageDataSortedList[3].ContainerName;
            Assert.AreEqual(expectedDarkContainerName, actualDarkContainerName);
        }
    }
}