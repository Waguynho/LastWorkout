using LastWorkout.CustomControls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LastWorkout.Views
{
    public class RegisterWorkOutView : ContentPage
    {
        Label labelPresentation = new Label();

        public RegisterWorkOutView()
        {
            labelPresentation.Text = "VIEW CODE";
            labelPresentation.TextColor = Color.White;
            labelPresentation.BackgroundColor = Color.Orange;

            Button buttonHome = new Button();
            buttonHome.Text = "Home";
            buttonHome.TextColor = Color.White;
            buttonHome.BorderColor = Color.Orange;
            buttonHome.SetBinding(Button.CommandProperty, "HomeCommand", BindingMode.OneWay);

            WImage leg = new WImage();
            leg.Source = "legpress.png";
            leg.SetBinding(WImage.TapCommandProperty, "HomeCommand");

            StackLayout stack = new StackLayout();
            stack.Orientation = StackOrientation.Vertical;
            stack.VerticalOptions = LayoutOptions.FillAndExpand;

            stack.Children.Add(labelPresentation);
            stack.Children.Add(buttonHome);
            stack.Children.Add(leg);

            Content = stack;           
        }
    }
}
