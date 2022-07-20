using System.Collections.Generic;

namespace Exam1.ViewModels
#nullable disable

{
    public class UpdateViewModel
    {
        public string Ma { get; set; } 

        public List<CellChangedViewModel> CellsChanged { get; set; }
    }
}
