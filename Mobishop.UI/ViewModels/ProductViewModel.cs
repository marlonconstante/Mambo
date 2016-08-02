using PropertyChanged;

namespace Mobishop.UI.ViewModels
{
	/// <summary>
	/// Product view model.
	/// </summary>
	[ImplementPropertyChanged]
	public class ProductViewModel
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get;
			set;
		}
	}
}