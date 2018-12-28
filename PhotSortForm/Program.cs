using System;
using System.Windows.Forms;
using Ninject;
using PhotSortComponent.Extensibility;

namespace ExifLibInAction
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainSorter = GetMainSorter();

            Application.Run(new Form1(mainSorter));
        }

        private static IMainSorter GetMainSorter()
        {
            var kernel = new StandardKernel();
            kernel.Load(AppDomain.CurrentDomain.GetAssemblies());
            return kernel.Get<IMainSorter>();
        }
    }
}