using Acr.UserDialogs;

namespace Mambo.Utils
{
    public class UserDialogsService : IUserDialogsService
    {
        public void ShowError(string message = "")
        {
            UserDialogs.Instance.ShowError(message);
        }

        public void ShowSucces(string message = "")
        {
            UserDialogs.Instance.ShowSuccess(message);
        }

        public void ShowLoading(string title)
        {
            UserDialogs.Instance.ShowLoading(title);
        }
    }
}