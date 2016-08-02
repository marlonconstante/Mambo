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
		/// Gets or sets the image source.
		/// </summary>
		/// <value>The image source.</value>
		public string ImageSource {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the amount.
		/// </summary>
		/// <value>The amount.</value>
		public double Amount {
			get;
			set;
		}
	}
}