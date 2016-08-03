using Xamarin.Forms;

namespace Mobishop.UI.Controls
{
	/// <summary>
	/// Price label view.
	/// </summary>
	public partial class PriceLabelView : ContentView
	{
		/// <summary>
		/// The amount property.
		/// </summary>
		public static readonly BindableProperty AmountProperty = BindableProperty.Create(nameof(Amount), typeof(double), typeof(PriceLabelView), default(double));

		/// <summary>
		/// The font size property.
		/// </summary>
		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(PriceLabelView), default(double));

		/// <summary>
		/// The text color property.
		/// </summary>
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(PriceLabelView), default(Color));

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
				return (double) GetValue(AmountProperty);
			}
			set {
				SetValue(AmountProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the size of the font.
		/// </summary>
		/// <value>The size of the font.</value>
		[TypeConverter(typeof(FontSizeConverter))]
		public double FontSize {
			get {
				return (double) GetValue(FontSizeProperty);
			}
			set {
				SetValue(FontSizeProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the color of the text.
		/// </summary>
		/// <value>The color of the text.</value>
		public Color TextColor {
			get {
				return (Color) GetValue(TextColorProperty);
			}
			set {
				SetValue(TextColorProperty, value);
			}
		}
	}
}