using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LastWorkout.CustomControls
{
    public class WImage : Image
    {
        public ICommand TapCommand
        {
            get { return (ICommand)GetValue(TapCommandProperty); }
            set { SetValue(TapCommandProperty, value); }
        }

        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(

           propertyName: "TapCommandProperty",

           returnType: typeof(ICommand),

           declaringType: typeof(WImage),

           defaultValue: null,

           defaultBindingMode: BindingMode.OneWay,

           propertyChanged: OnTapChanged

           );

        private static void OnTapChanged(BindableObject bindable, object oldValue, object newValue)

        {
            if (oldValue != newValue)
            {
                WImage customImage = (WImage)bindable;
                ICommand tapCommand = (ICommand)newValue;

                AddTapGesture(customImage, tapCommand);
            }
        }

        private static void AddTapGesture(View view, ICommand tapCommand)
        {
            if (tapCommand != null && view != null)
            {
                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Command = tapCommand;
                view.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }
    }
}
