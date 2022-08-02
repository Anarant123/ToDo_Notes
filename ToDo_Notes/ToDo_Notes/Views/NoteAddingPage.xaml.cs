using System;
using ToDo_Notes.Models;
using Xamarin.Forms;
using ToDo_Notes.Views;

namespace ToDo_Notes.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteAddingPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }
        public NoteAddingPage()
        {
            InitializeComponent();

            BindingContext = new Note();
        }
        private async void LoadNote(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);
                Note note = await App.NotesDB.GetNoteAsync(id);
                note.Date = DateTime.Now;
                BindingContext = note;
            }
            catch { }
        }
        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            note.Date = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(note.Text) || !string.IsNullOrWhiteSpace(note.Name))
            {
                await App.NotesDB.SaveNoteAsync(note);
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await DisplayAlert("Ошибка", "Вы забыли заполнить все поля", "OK");
            }
        }
        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            await App.NotesDB.DeleteNoteAsync(note);
            await Shell.Current.GoToAsync("..");
        }
    }
}