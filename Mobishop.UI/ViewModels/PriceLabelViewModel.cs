using System;
using System.Globalization;
using System.Linq;
using PropertyChanged;
using Xamarin.Forms;

namespace Mobishop.UI.ViewModels
{
	/// <summary>
	/// Price label view model.
	/// </summary>
	[ImplementPropertyChanged]
	public class PriceLabelViewModel
	{
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
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the size of the font.
		/// </summary>
		/// <value>The size of the font.</value>
		public double FontSize {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the color of the text.
		/// </summary>
		/// <value>The color of the text.</value>
		public Color TextColor {
			get;
			set;
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
	}
}