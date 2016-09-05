using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Mobishop.UI.Controls
{
    public partial class QuantitySelectorView : ContentView
    {
        /// <summary>
        /// The minimum property.
        /// </summary>
        public static readonly BindableProperty MinimumProperty = BindableProperty.Create(nameof(Minimum), typeof(int), typeof(QuantitySelectorView), 0, propertyChanged: MinimumPropertyChanged);

        /// <summary>
        /// The maximum property.
        /// </summary>
        public static readonly BindableProperty MaximumProperty = BindableProperty.Create(nameof(Maximum), typeof(int), typeof(QuantitySelectorView), 99, propertyChanged: MaximumPropertyChanged);

        /// <summary>
        /// The value property.
        /// </summary>
        public static readonly BindableProperty QuantityProperty = BindableProperty.Create(nameof(Quantity), typeof(int), typeof(QuantitySelectorView), 0, propertyChanged: QuantityPropertyChanged);

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return (int)GetValue(MinimumProperty);
            }
            set
            {
                SetValue(MinimumProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return (int)GetValue(MaximumProperty);
            }
            set
            {
                SetValue(MaximumProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Quantity
        {
            get
            {
                return (int)GetValue(QuantityProperty);
            }
            set
            {
                SetValue(QuantityProperty, value);
            }
        }


        public QuantitySelectorView()
        {
            InitializeComponent();
        }

        static void MinimumPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var qsv = (QuantitySelectorView)bindable;

            if (qsv.Quantity < (int)newValue)
            {
                qsv.Quantity = (int)newValue;
            }
            else
            {
                qsv.UpdateStateButtons(qsv);
            }
        }

        static void MaximumPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var qsv = (QuantitySelectorView)bindable;

            if (qsv.Quantity > (int)newValue)
            {
                qsv.Quantity = (int)newValue;
            }
            else
            {
                qsv.UpdateStateButtons(qsv);
            }
        }

        static void QuantityPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var qsv = (QuantitySelectorView)bindable;

            qsv.QuantityLabel.Text = newValue.ToString();
            qsv.UpdateStateButtons(qsv);
        }

        void UpdateStateButtons(QuantitySelectorView quantitySelectorView)
        {
            quantitySelectorView.MinusButton.IsEnabled = Quantity > Minimum;
            quantitySelectorView.PlusButton.IsEnabled = Quantity < Maximum;
        }
    }
}

