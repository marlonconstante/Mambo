using Xamarin.Forms;

namespace Mobishop.UI.Controls
{
	/// <summary>
	/// Product view.
	/// </summary>
	public partial class ProductView : ContentView
	{
		/// <summary>
		/// The name property.
		/// </summary>
		public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(ProductView), default(string));

		/// <summary>
		/// The image source property.
		/// </summary>
		public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(ProductView), default(ImageSource));

		/// <summary>
		/// The amount property.
		/// </summary>
		public static readonly BindableProperty AmountProperty = BindableProperty.Create(nameof(Amount), typeof(double), typeof(ProductView), default(double));

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
				return (string) GetValue(NameProperty);
			}
			set {
				SetValue(NameProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the image source.
		/// </summary>
		/// <value>The image source.</value>
		public ImageSource ImageSource {
			get {
				return (ImageSource) GetValue(ImageSourceProperty);
			}
			set {
				SetValue(ImageSourceProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the amount.
		/// </summary>
		/// <value>The amount.</value>
		public double Amount {
			get {
				return (double) GetValue(AmountProperty);
			}
			set {
				SetValue(AmountProperty, value);
			}
		}
	}
}