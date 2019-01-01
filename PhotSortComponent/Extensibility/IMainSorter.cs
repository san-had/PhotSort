using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotSortComponent.Extensibility
{
    public interface IMainSorter
    {
        Task<IList<string>> SortProcessing(string folderName, string[] sequences);
    }
}