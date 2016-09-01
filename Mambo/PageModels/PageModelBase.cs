using System;
using System.Reactive.Disposables;
using FreshMvvm;
using Mambo.Utils;
using Splat;

namespace Mambo.PageModels
{
    public class PageModelBase : FreshBasePageModel
    {
        protected IUserDialogsService Dialogs
        {
            get;
            set;
        }

        protected readonly CompositeDisposable subscriptionDisposables = new CompositeDisposable();

        public PageModelBase(IUserDialogsService userDialogService = null)
        {
            Dialogs = userDialogService ?? Locator.Current.GetService<IUserDialogsService>();
        }
    }
}

