using Xamarin.Forms;

namespace Mobishop.UI.Controls
{
	/// <summary>
	/// Group header view.
	/// </summary>
	public partial class GroupHeaderView : ContentView
	{
		/// <summary>
		/// The title property.
		/// </summary>
		public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(GroupHeaderView), default(string), propertyChanged: TitlePropertyChanged);

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.UI.Controls.GroupHeaderView"/> class.
		/// </summary>
		public GroupHeaderView()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Titles the property changed.
		/// </summary>
		/// <param name="bindable">Bindable.</param>
		/// <param name="oldValue">Old value.</param>
		/// <param name="newValue">New value.</param>
		static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var view = (GroupHeaderView) bindable;
			var title = (string) newValue;

			view.TitleLabel.Text = title;
		}

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title {
			get {
				return (string) GetValue(TitleProperty);
			}
			set {
				SetValue(TitleProperty, value);
			}
		}
	}
}