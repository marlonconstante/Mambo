using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobishop.UI.Tasks
{
	/// <summary>
	/// UI Task handler.
	/// </summary>
	public static class UITaskHandler
	{
		/// <summary>
		/// Execute the specified action.
		/// </summary>
		/// <param name="action">Action.</param>
		public static async Task Execute(Func<Task> action)
		{
			try
			{
				await action.Invoke();
			}
			catch (Exception exception)
			{
				await Application.Current.MainPage.DisplayAlert("Ops...", exception.Message, "OK");
			}
		}
	}
}