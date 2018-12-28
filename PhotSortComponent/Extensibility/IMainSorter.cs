using System.Collections.Generic;

namespace PhotSortComponent.Extensibility
{
    public interface IMainSorter
    {
        IList<string> SortProcessing(string folderName, string[] sequences);
    }
}