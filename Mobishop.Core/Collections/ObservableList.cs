using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Mobishop.Core.Collections
{
	/// <summary>
	/// Observable list.
	/// </summary>
	public class ObservableList<T> : ObservableCollection<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.Core.Collections.ObservableList`1"/> class.
		/// </summary>
		public ObservableList()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.Core.Collections.ObservableList`1"/> class.
		/// </summary>
		/// <param name="items">Items.</param>
		public ObservableList(IEnumerable<T> items) : base(items)
		{
		}

		/// <summary>
		/// Adds the range.
		/// </summary>
		/// <param name="items">Items.</param>
		public void AddRange(IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				Items.Add(item);
			}

			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items.ToList()));
		}
	}
}