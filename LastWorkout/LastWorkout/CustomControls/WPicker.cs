using LastWorkout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LastWorkout.CustomControls
{
    public class WPicker<T> : Picker where T : ISelectorItem
    {
        public IList<T> ItemsObject
        {
            get { return (IList<T>)GetValue(ItemsObjectProperty); }
            set {
                SetValue(ItemsObjectProperty, value);
            }
        }

        public static readonly BindableProperty ItemsObjectProperty = BindableProperty.Create(

           propertyName: nameof(ItemsObject),

           returnType: typeof(IList<T>),

           declaringType: typeof(WPicker<T>),

           defaultValue: default(IList<T>),

           defaultBindingMode: BindingMode.OneWay,

           propertyChanged: OnItemsObjectChanged

           );

        private static void OnItemsObjectChanged(BindableObject bindable, object oldValue, object newValue)

        {
            if (oldValue != newValue)
            {
                WPicker<T> wPicker = (WPicker<T>)bindable;
                IList<T>itemsObject = (IList<T>)newValue;           

                foreach (var valor in itemsObject)
                {
                    wPicker.Items.Add(valor.Description);
                }
            }

        }

        public T SelectedObject
        {
            get { return (T)GetValue(SelectedObjectProperty); }
            set
            {
                SetValue(SelectedObjectProperty, value);
            }
        }

        /// <summary>
        /// Use this property for binding complex object
        /// </summary>
        public static readonly BindableProperty SelectedObjectProperty = BindableProperty.Create(

          propertyName: nameof(SelectedObject),

          returnType: typeof(T),

          declaringType: typeof(WPicker<T>),

          defaultValue: default(T),

          defaultBindingMode: BindingMode.TwoWay

          );

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(this.SelectedIndex))
            {
                this.SelectedObject = this.ItemsObject.ElementAt(this.SelectedIndex);               
            }
        }

    }
}
