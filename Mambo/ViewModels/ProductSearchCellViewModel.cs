using Mobishop.Domain.Showcases;
using PropertyChanged;

namespace Mambo.ViewModels
{
    [ImplementPropertyChanged]
    public class ProductSearchCellViewModel
    {
        public ShowcaseProduct FirstProduct { get; set; }
        public ShowcaseProduct SecondProduct { get; set; }
    }
}


