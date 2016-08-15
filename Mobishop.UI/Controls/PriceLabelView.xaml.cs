using System;
using System.Globalization;
using System.Linq;
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
		public static readonly BindableProperty AmountProperty = BindableProperty.Create(nameof(Amount), typeof(double), typeof(PriceLabelView), default(double), propertyChanged: AmountPropertyChanged);

		/// <summary>
		/// The font size property.
		/// </summary>
		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(PriceLabelView), default(double), propertyChanged: FontSizePropertyChanged);

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
		/// Amounts the property changed.
		/// </summary>
		/// <param name="bindable">Bindable.</param>
		/// <param name="oldValue">Old value.</param>
		/// <param name="newValue">New value.</param>
		static void AmountPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var label = (PriceLabelView) bindable;

			label.OnPropertyChanged(nameof(IntegerAmountText));
			label.OnPropertyChanged(nameof(DecimalAmountText));
		}

		/// <summary>
		/// Fonts the size property changed.
		/// </summary>
		/// <param name="bindable">Bindable.</param>
		/// <param name="oldValue">Old value.</param>
		/// <param name="newValue">New value.</param>
		static void FontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var label = (PriceLabelView) bindable;

			label.OnPropertyChanged(nameof(SymbolFontSize));
			label.OnPropertyChanged(nameof(IntegerFontSize));
			label.OnPropertyChanged(nameof(DecimalFontSize));
			label.OnPropertyChanged(nameof(SymbolMargin));
			label.OnPropertyChanged(nameof(SeparatorMargin));
			label.OnPropertyChanged(nameof(DecimalMargin));
		}

		/// <summary>
		/// Gets the relative margin.
		/// </summary>
		/// <returns>The relative margin.</returns>
		/// <param name="margin">Margin.</param>
		Thickness GetRelativeMargin(Thickness margin)
		{
			var left = GetRelativeFontSize(margin.Left);
			var top = GetRelativeFontSize(margin.Top);
			var right = GetRelativeFontSize(margin.Right);
			var bottom = GetRelativeFontSize(margin.Bottom);

			return new Thickness(left, top, right, bottom);
		}

		/// <summary>
		/// Gets the size of the relative font.
		/// </summary>
		/// <returns>The relative font size.</returns>
		/// <param name="value">Value.</param>
		double GetRelativeFontSize(double value)
		{
			return value * (FontSize / 25d);
		}

		/// <summary>
		/// Gets the symbol.
		/// </summary>
		/// <value>The symbol.</value>
		public string Symbol {
			get {
				return CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
			}
		}

		/// <summary>
		/// Gets the separator.
		/// </summary>
		/// <value>The separator.</value>
		public string Separator {
			get {
				return CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			}
		}

		/// <summary>
		/// Gets the integer amount text.
		/// </summary>
		/// <value>The integer amount text.</value>
		public string IntegerAmountText {
			get {
				return Amount.ToString("F2").Split(Convert.ToChar(Separator)).First();
			}
		}

		/// <summary>
		/// Gets the decimal amount text.
		/// </summary>
		/// <value>The decimal amount text.</value>
		public string DecimalAmountText {
			get {
				return Amount.ToString("F2").Split(Convert.ToChar(Separator)).Last();
			}
		}

		/// <summary>
		/// Gets the size of the symbol font.
		/// </summary>
		/// <value>The size of the symbol font.</value>
		public double SymbolFontSize {
			get {
				return GetRelativeFontSize(10d);
			}
		}

		/// <summary>
		/// Gets the size of the integer font.
		/// </summary>
		/// <value>The size of the integer font.</value>
		public double IntegerFontSize {
			get {
				return GetRelativeFontSize(25d);
			}
		}

		/// <summary>
		/// Gets the size of the decimal font.
		/// </summary>
		/// <value>The size of the decimal font.</value>
		public double DecimalFontSize {
			get {
				return GetRelativeFontSize(14d);
			}
		}

		/// <summary>
		/// Gets the symbol margin.
		/// </summary>
		/// <value>The symbol margin.</value>
		public Thickness SymbolMargin {
			get {
				if (Device.OS == TargetPlatform.Android)
				{
					return GetRelativeMargin(new Thickness(0d, 0d, 3d, 5d));
				}

				return GetRelativeMargin(new Thickness(0d, 0d, 2d, 4d));
			}
		}

		/// <summary>
		/// Gets the separator margin.
		/// </summary>
		/// <value>The separator margin.</value>
		public Thickness SeparatorMargin {
			get {
				if (Device.OS == TargetPlatform.Android)
				{
					return GetRelativeMargin(new Thickness(-1d, 0d, 0d, 0d));
				}

				return GetRelativeMargin(new Thickness(-2d, 0d, 0d, 0d));
			}
		}

		/// <summary>
		/// Gets the decimal margin.
		/// </summary>
		/// <value>The decimal margin.</value>
		public Thickness DecimalMargin {
			get {
				if (Device.OS == TargetPlatform.Android)
				{
					return GetRelativeMargin(new Thickness(0d, 3d, 0d, 0d));
				}

				return GetRelativeMargin(new Thickness(-1d, 3d, 0d, 0d));
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