using System;
using Mambo.Utils;
using Mobishop.Domain.Showcases;
using PropertyChanged;

namespace Mambo.PageModels
{
    [ImplementPropertyChanged]
    public class ProductDetailsPageModel : PageModelBase
    {
        public string Name
        {
            get
            {
                return m_showcaseProduct.Name;
            }
        }

        public string ImageUrl
        {
            get
            {
                return m_showcaseProduct.ImageUrl;
            }
        }
        public string Category
        {
            get
            {
                return "Category > Category";
            }
        }

        public string OriginalPrice
        {
            get
            {
                return m_showcaseProduct.PreviousPrice.ToString("C");
            }
        }

        public double CurrentPrice
        {
            get
            {
                return m_showcaseProduct.CurrentPrice;
            }
        }

        public string Description
        {
            get
            {
                return m_showcaseProduct.Description;
            }
        }

        ShowcaseProduct m_showcaseProduct;

        public ProductDetailsPageModel(IUserDialogsService userDialogService = null) : base(userDialogService)
        {

        }

        public override void Init(object initData)
        {
            m_showcaseProduct = (ShowcaseProduct)initData;

            base.Init(initData);
        }
    }
}

