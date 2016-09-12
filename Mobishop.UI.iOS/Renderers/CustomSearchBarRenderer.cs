using System.ComponentModel;
using Foundation;
using Mobishop.UI.Controls;
using Mobishop.UI.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace Mobishop.UI.iOS.Renderers
{
	/// <summary>
	/// Custom search bar renderer.
	/// </summary>
	public class CustomSearchBarRenderer : SearchBarRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mobishop.UI.iOS.Renderers.CustomSearchBarRenderer"/> class.
		/// </summary>
		public CustomSearchBarRenderer()
		{
		}

		/// <summary>
		/// Ons the element changed.
		/// </summary>
		/// <param name="args">Arguments.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> args)
		{
			base.OnElementChanged(args);

			if (Element != null)
			{
				SetControlStyle();
			}
		}

		/// <summary>
		/// Ons the element property changed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(sender, args);

			if (args.PropertyName == nameof(Element.PlaceholderColor))
			{
				SetControlStyle();
			}
		}

		/// <summary>
		/// Sets the control style.
		/// </summary>
		void SetControlStyle()
		{
			var statusBarBackgroundColor = ((Color) Application.Current.Resources["statusBarBackgroundColor"]).ToUIColor();
			var highlightedColor = ((Color) Application.Current.Resources["highlightedColor"]).ToUIColor();
			var iconColor = Element.PlaceholderColor.ToUIColor();

			Control.BackgroundImage = new UIImage();
			Control.TintColor = highlightedColor;

			var searchField = GetSearchField();
			searchField.BackgroundColor = statusBarBackgroundColor;

			var clearButton = GetClearButton(searchField);
			clearButton.TintColor = iconColor;
			clearButton.SetImage(GetTemplateImage(clearButton.ImageView), UIControlState.Normal);

			var leftImageView = GetLeftImageView(searchField);
			leftImageView.TintColor = iconColor;
			leftImageView.Image = GetTemplateImage(leftImageView);
		}

		/// <summary>
		/// Gets the search field.
		/// </summary>
		/// <returns>The search field.</returns>
		UITextField GetSearchField()
		{
			return (UITextField) Control.ValueForKey(new NSString("_searchField"));
		}

		/// <summary>
		/// Gets the clear button.
		/// </summary>
		/// <returns>The clear button.</returns>
		/// <param name="searchField">Search field.</param>
		UIButton GetClearButton(UITextField searchField)
		{
			return (UIButton) searchField.ValueForKey(new NSString("_clearButton"));
		}

		/// <summary>
		/// Gets the left image view.
		/// </summary>
		/// <returns>The left image view.</returns>
		/// <param name="searchField">Search field.</param>
		UIImageView GetLeftImageView(UITextField searchField)
		{
			return (UIImageView) searchField.LeftView;
		}

		/// <summary>
		/// Gets the template image.
		/// </summary>
		/// <returns>The template image.</returns>
		/// <param name="imageView">Image view.</param>
		UIImage GetTemplateImage(UIImageView imageView)
		{
			return imageView.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
		}
	}
}