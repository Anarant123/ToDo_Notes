using System;
using System.Linq;
using ToDo_Notes.Models;
using Xamarin.Forms;
namespace ToDo_Notes.Views
{
    public partial class ExercisesPage : ContentPage
    {
        public ExercisesPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            collExercise.ItemsSource = await App.NotesDB.GetExercisesAsync();
            base.OnAppearing();
        }
        private async void AddExercise_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ExerciseAddingPage));
        }
        private async void On_SelectionChangedExercise(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Exercise ex = (Exercise)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(ExerciseAddingPage)}?{nameof(ExerciseAddingPage.ExerciseId)}={ex.Id.ToString()}");
            }
        }
    }
}