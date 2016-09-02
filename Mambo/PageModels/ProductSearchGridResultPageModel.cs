using System;
using System.Linq;
using System.Threading.Tasks;
using Mambo.Utils;
using Mambo.ViewModels;
using Mobishop.Domain.Showcases;
using Mobishop.Infrastructure.Framework.Collections;
using Mobishop.Infrastructure.Framework.Repositories;
using PropertyChanged;

namespace Mambo.PageModels
{
    [ImplementPropertyChanged]
    public class ProductSearchGridResultPageModel : PageModelBase
    {
        ShowcaseService m_showcaseService;
        string m_searchQuery;

        public ObservableList<ProductSearchCellViewModel> ProductList
        {
            get;
            set;
        }

        public ProductSearchGridResultPageModel(IUserDialogsService userDialogService = null) : base(userDialogService)
        {
            m_showcaseService = new ShowcaseService();
            ProductList = new ObservableList<ProductSearchCellViewModel>();
        }

        public override async void Init(object initData)
        {
            base.Init(initData);

            m_searchQuery = initData.ToString();

            var products = (await m_showcaseService.GetShowcaseProductsByNameAsync(m_searchQuery, Priorities.UserInitiated)).ToList();

            for (int i = 0; i < products.Count; i = i + 2)
            {
                ProductList.Add(new ProductSearchCellViewModel
                {
                    FirstProduct = products[i],
                    SecondProduct = (i + 1 < products.Count) ? products[i + 1] : null
                });
            }
        }
    }
}

