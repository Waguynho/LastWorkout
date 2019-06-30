using LastWorkout.CustomControls;
using LastWorkout.Interfaces;
using LastWorkout.Localization;
using LastWorkout.Statics;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LastWorkout.Views
{
    public class RegisterWorkOutView : ContentPage
    {
        public RegisterWorkOutView()
        {
            SetTitlePage();

            Label dateWorkoutLabel = new Label();
            dateWorkoutLabel.Text = "WorkOut Date";
            dateWorkoutLabel.TextColor = Color.White;

            DatePicker datePicker = new DatePicker();
            datePicker.Date = DateTime.Now;
            datePicker.BackgroundColor = Color.Orange;
            datePicker.TextColor = Color.White;
            datePicker.Format = GlobalVariables.DateFormat;
            datePicker.SetBinding(DatePicker.DateProperty, "WorkOutDate");

            WPicker<ISelectorItem> pickerLevel = new WPicker<ISelectorItem>();
            pickerLevel.Title = "Workout Level";
            pickerLevel.TextColor = Color.White;
            pickerLevel.BackgroundColor = Color.Orange;
            pickerLevel.SetBinding(WPicker<ISelectorItem>.ItemsObjectProperty, "Levels");
            pickerLevel.SetBinding(WPicker<ISelectorItem>.SelectedObjectProperty, "SelectedLevel");

            WPicker<ISelectorItem> pickerWorkout = new WPicker<ISelectorItem>();
            pickerWorkout.Title = "Workout";
            pickerWorkout.TextColor = Color.White;
            pickerWorkout.BackgroundColor = Color.Orange;
            pickerWorkout.SetBinding(WPicker<ISelectorItem>.ItemsObjectProperty, "WorkOuts");
            pickerWorkout.SetBinding(WPicker<ISelectorItem>.SelectedObjectProperty, "SelectedWorkOut");

            Editor editor = new Editor();
            editor.Keyboard = Keyboard.Text;
            editor.Placeholder = "Observações";
            editor.MinimumHeightRequest = 10;
            editor.TextColor = Color.Orange;
            editor.BackgroundColor = Color.White;
            editor.VerticalOptions = LayoutOptions.FillAndExpand;
            editor.SetBinding(Editor.TextProperty, "Observation");

            Button buttonSave = new Button();
            buttonSave.TextColor = Color.Black;
            buttonSave.Text = Lang.save;
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
            stack.Children.Add(pickerLevel);
            stack.Children.Add(pickerWorkout);
            stack.Children.Add(editor);
            stack.Children.Add(buttonSave);

            Content = stack;
        }

        private void SetTitlePage()
        {
            Title = Lang.register_workout;
        }
    }
}
