using Xamarin.Forms;

namespace Mobishop.UI.Controls
{
    /// <summary>
    /// Product thumb view.
    /// </summary>
    public partial class ProductThumbView : ContentView
    {
        /// <summary>
        /// The name property.
        /// </summary>
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(ProductThumbView), default(string), propertyChanged: NamePropertyChanged);

        /// <summary>
        /// The image source property.
        /// </summary>
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(ProductThumbView), default(ImageSource), propertyChanged: ImageSourcePropertyChanged);

        /// <summary>
        /// The amount property.
        /// </summary>
        public static readonly BindableProperty AmountProperty = BindableProperty.Create(nameof(Amount), typeof(double), typeof(ProductThumbView), default(double), propertyChanged: AmountPropertyChanged);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Mobishop.UI.Controls.ProductThumbView"/> class.
        /// </summary>
        public ProductThumbView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Names the property changed.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        static void NamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (ProductThumbView)bindable;
            var name = (string)newValue;

            view.NameLabel.Text = name;
        }

        /// <summary>
        /// Images the source property changed.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (ProductThumbView)bindable;
            var imageSource = (ImageSource)newValue;

            view.ImageView.Source = imageSource;
        }

        /// <summary>
        /// Amounts the property changed.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        static void AmountPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (ProductThumbView)bindable;
            var amount = (double)newValue;

            view.AmountLabel.Amount = amount;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return (string)GetValue(NameProperty);
            }
            set
            {
                SetValue(NameProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the image source.
        /// </summary>
        /// <value>The image source.</value>
        public ImageSource ImageSource
        {
            get
            {
                return (ImageSource)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double Amount
        {
            get
            {
                return (double)GetValue(AmountProperty);
            }
            set
            {
                SetValue(AmountProperty, value);
            }
        }
    }
}