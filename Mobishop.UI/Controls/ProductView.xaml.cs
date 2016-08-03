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
		/// The source property.
		/// </summary>
		public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(ProductView), default(ImageSource));

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
		/// Gets or sets the source.
		/// </summary>
		/// <value>The source.</value>
		public ImageSource Source {
			get {
				return (ImageSource) GetValue(SourceProperty);
			}
			set {
				SetValue(SourceProperty, value);
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