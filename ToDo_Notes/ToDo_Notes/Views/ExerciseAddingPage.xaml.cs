using System;
using ToDo_Notes.Models;
using Xamarin.Forms;
namespace ToDo_Notes.Views
{
    [QueryProperty(nameof(ExerciseId), nameof(ExerciseId))]
    public partial class ExerciseAddingPage : ContentPage
    {
        public string ExerciseId
        {
            set
            {
                LoadExercise(value);
            }
        }
        public ExerciseAddingPage()
        {
            InitializeComponent();

            BindingContext = new Exercise();
        }
        private async void LoadExercise(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);
                Exercise ex = await App.NotesDB.GetExerciseAsync(id);
                BindingContext = ex;
            }
            catch { }
        }
        private async void OnSaveExercise_Clicked(object sender, EventArgs e)
        {
            Exercise ex = (Exercise)BindingContext;
            if (!string.IsNullOrWhiteSpace(ex.THeader))
            {
                await App.NotesDB.SaveExerciseAsync(ex);
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await DisplayAlert("Ошибка","Вы забыли заполнить поле с названием задачи!","OK");
            }
        }
        private async void OnDeleteExercise_Clicked(object sender, EventArgs e)
        {
            Exercise ex = (Exercise)BindingContext;
            await App.NotesDB.DeleteExerciseAsync(ex);
            await Shell.Current.GoToAsync("..");
        }
    }
}