using Mobishop.UI.ViewModels;
using Xamarin.Forms;

namespace Mobishop.UI.Controls
{
	/// <summary>
	/// Price label view.
	/// </summary>
	public partial class PriceLabelView : ContentView
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.UI.Controls.PriceLabelView"/> class.
		/// </summary>
		public PriceLabelView()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the amount.
		/// </summary>
		/// <value>The amount.</value>
		public double Amount {
			get {
				return (BindingContext as PriceLabelViewModel).Amount;
			}
			set {
				(BindingContext as PriceLabelViewModel).Amount = value;
			}
		}
	}
}