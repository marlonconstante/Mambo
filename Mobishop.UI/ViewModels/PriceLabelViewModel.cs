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
		/// Gets the integer amount.
		/// </summary>
		/// <value>The integer amount.</value>
		public string IntegerAmount {
			get {
				return Amount.ToString("F2").Split(Convert.ToChar(Separator)).First();
			}
		}

		/// <summary>
		/// Gets the decimal amount.
		/// </summary>
		/// <value>The decimal amount.</value>
		public string DecimalAmount {
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
				return 10d * (FontSize / 25d);
			}
		}

		/// <summary>
		/// Gets the size of the integer font.
		/// </summary>
		/// <value>The size of the integer font.</value>
		public double IntegerFontSize {
			get {
				return 25d * (FontSize / 25d);
			}
		}

		/// <summary>
		/// Gets the size of the decimal font.
		/// </summary>
		/// <value>The size of the decimal font.</value>
		public double DecimalFontSize {
			get {
				return 14d * (FontSize / 25d);
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
	}
}