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
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(PriceLabelView), default(Color), propertyChanged: TextColorPropertyChanged);

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

			var format = CultureInfo.CurrentCulture.NumberFormat;
			var symbol = format.CurrencySymbol;
			var separator = format.NumberDecimalSeparator;

			var amount = (double) newValue;
			var values = amount.ToString("F2").Split(Convert.ToChar(separator));

			label.SymbolLabel.Text = symbol;
			label.IntegerLabel.Text = values.First();
			label.SeparatorLabel.Text = separator;
			label.DecimalLabel.Text = values.Last();
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
			var fontSize = (double) newValue;

			label.SymbolLabel.FontSize = GetRelativeFontSize(10d, fontSize);
			label.IntegerLabel.FontSize = GetRelativeFontSize(25d, fontSize);
			label.SeparatorLabel.FontSize = GetRelativeFontSize(25d, fontSize);
			label.DecimalLabel.FontSize = GetRelativeFontSize(14d, fontSize);

			if (Device.OS == TargetPlatform.Android)
			{
				label.SymbolLabel.Margin = GetRelativeMargin(new Thickness(0d, 0d, 3d, 5d), fontSize);
				label.SeparatorLabel.Margin = GetRelativeMargin(new Thickness(-1d, 0d, 0d, 0d), fontSize);
				label.DecimalLabel.Margin = GetRelativeMargin(new Thickness(0d, 3d, 0d, 0d), fontSize);
			}
			else
			{
				label.SymbolLabel.Margin = GetRelativeMargin(new Thickness(0d, 0d, 2d, 4d), fontSize);
				label.SeparatorLabel.Margin = GetRelativeMargin(new Thickness(-2d, 0d, 0d, 0d), fontSize);
				label.DecimalLabel.Margin = GetRelativeMargin(new Thickness(-1d, 3d, 0d, 0d), fontSize);
			}
		}

		/// <summary>
		/// Texts the color property changed.
		/// </summary>
		/// <param name="bindable">Bindable.</param>
		/// <param name="oldValue">Old value.</param>
		/// <param name="newValue">New value.</param>
		static void TextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var label = (PriceLabelView) bindable;
			var textColor = (Color) newValue;

			label.SymbolLabel.TextColor = textColor;
			label.IntegerLabel.TextColor = textColor;
			label.SeparatorLabel.TextColor = textColor;
			label.DecimalLabel.TextColor = textColor;
		}

		/// <summary>
		/// Gets the relative margin.
		/// </summary>
		/// <returns>The relative margin.</returns>
		/// <param name="margin">Margin.</param>
		/// <param name="fontSize">Font size.</param>
		static Thickness GetRelativeMargin(Thickness margin, double fontSize)
		{
			var left = GetRelativeFontSize(margin.Left, fontSize);
			var top = GetRelativeFontSize(margin.Top, fontSize);
			var right = GetRelativeFontSize(margin.Right, fontSize);
			var bottom = GetRelativeFontSize(margin.Bottom, fontSize);

			return new Thickness(left, top, right, bottom);
		}

		/// <summary>
		/// Gets the size of the relative font.
		/// </summary>
		/// <returns>The relative font size.</returns>
		/// <param name="value">Value.</param>
		/// <param name="fontSize">Font size.</param>
		static double GetRelativeFontSize(double value, double fontSize)
		{
			return value * (fontSize / 25d);
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