using Mobishop.UI.ViewModels;
using Xamarin.Forms;

namespace Mobishop.UI.Controls
{
	/// <summary>
	/// Product view.
	/// </summary>
	public partial class ProductView : ContentView
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.UI.Controls.ProductView"/> class.
		/// </summary>
		public ProductView()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get {
				return (BindingContext as ProductViewModel).Name;
			}
			set {
				(BindingContext as ProductViewModel).Name = value;
			}
		}
	}
}