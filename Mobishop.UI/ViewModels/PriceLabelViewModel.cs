using System;
using System.Globalization;
using System.Linq;
using PropertyChanged;

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
		/// Gets or sets the amount.
		/// </summary>
		/// <value>The amount.</value>
		public double Amount {
			get;
			set;
		}
	}
}