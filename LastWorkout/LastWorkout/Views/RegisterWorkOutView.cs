using LastWorkout.CustomControls;
using LastWorkout.Interfaces;
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
            Title = "Register Workout";

            Label dateWorkoutLabel = new Label();
            dateWorkoutLabel.Text = "WorkOut Date";


            DatePicker datePicker = new DatePicker();
            datePicker.Date = DateTime.Now;
            datePicker.BackgroundColor = Color.Orange;
            datePicker.TextColor = Color.White;
            datePicker.SetBinding(DatePicker.DateProperty, "WorkOutDate");

            WPicker<ISelectorItem> picker = new WPicker<ISelectorItem>();
            picker.Title = "Workout Level";
            picker.TextColor = Color.White;
            picker.BackgroundColor = Color.Orange;
            picker.SetBinding(WPicker<ISelectorItem>.ItemsObjectProperty, "Levels");
            picker.SetBinding(WPicker<ISelectorItem>.SelectedObjectProperty, "SelectedLevel");


            Editor editor = new Editor();
            editor.Keyboard = Keyboard.Text;
            editor.Placeholder = "Observações";
            editor.MinimumHeightRequest = 10;
            editor.TextColor = Color.White;
            editor.BackgroundColor = Color.Orange;
            editor.SetBinding(Editor.TextProperty, "Observation");

            Button buttonSave = new Button();
            buttonSave.Text = "Save";
            buttonSave.TextColor = Color.Black;
            buttonSave.BackgroundColor = Color.White;
            buttonSave.BorderColor = Color.Orange;
            buttonSave.SetBinding(Button.CommandProperty, "SaveCommand");



            StackLayout stack = new StackLayout();
            stack.BackgroundColor = Color.Black;
            stack.Orientation = StackOrientation.Vertical;
            stack.VerticalOptions = LayoutOptions.FillAndExpand;
            stack.Padding = new Thickness(5, 3);

            stack.Children.Add(dateWorkoutLabel);
            stack.Children.Add(datePicker);
            stack.Children.Add(picker);
            stack.Children.Add(editor);
            stack.Children.Add(buttonSave);

            Content = stack;           
        }


    }
}
