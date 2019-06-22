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

           propertyName: "TapCommand",

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

        public ICommand PinchCommand
        {
            get { return (ICommand)GetValue(PinchCommandProperty); }
            set { SetValue(PinchCommandProperty, value); }
        }

        public static readonly BindableProperty PinchCommandProperty = BindableProperty.Create(

           propertyName: "PinchCommand",

           returnType: typeof(ICommand),

           declaringType: typeof(WImage),

           defaultValue: null,

           defaultBindingMode: BindingMode.OneWay,

           propertyChanged: OnPinChanged

           );

        private static void OnPinChanged(BindableObject bindable, object oldValue, object newValue)

        {
            if (oldValue != newValue)
            {
                WImage customImage = (WImage)bindable;
                ICommand tapCommand = (ICommand)newValue;

                AddPintGesture(customImage, tapCommand);
            }
        }

        private static void AddPintGesture(View view, ICommand tapCommand)
        {
            if (tapCommand != null && view != null)
            {
                PinchGestureRecognizer tapGestureRecognizer = new PinchGestureRecognizer();
                tapGestureRecognizer.PinchUpdated += PinchUpdate;
                view.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }

        private static void PinchUpdate(object sender, PinchGestureUpdatedEventArgs e)
        {
            Console.WriteLine("Scale: {0}, ScaleOrigin: {1}", e.Scale, e.ScaleOrigin);
        }

        public ICommand PanCommand
        {
            get { return (ICommand)GetValue(PanCommandProperty); }
            set { SetValue(PanCommandProperty, value); }
        }

        public static readonly BindableProperty PanCommandProperty = BindableProperty.Create(

           propertyName: "PanCommand",

           returnType: typeof(ICommand),

           declaringType: typeof(WImage),

           defaultValue: null,

           defaultBindingMode: BindingMode.OneWay,

           propertyChanged: OnPanChanged

           );

        private static void OnPanChanged(BindableObject bindable, object oldValue, object newValue)

        {
            if (oldValue != newValue)
            {
                WImage customImage = (WImage)bindable;
                ICommand panCommand = (ICommand)newValue;

                AddPantGesture(customImage, panCommand);
            }
        }

        private static void AddPantGesture(View view, ICommand tapCommand)
        {
            if (tapCommand != null && view != null)
            {
                PanGestureRecognizer tapGestureRecognizer = new PanGestureRecognizer();
                tapGestureRecognizer.PanUpdated += PanUpdate;
                view.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }

        private static void PanUpdate(object sender, PanUpdatedEventArgs e)
        {
            Console.WriteLine("PAN ======= X: {0}, Y: {1}",e.TotalX, e.TotalY);            
        }
    }
}
