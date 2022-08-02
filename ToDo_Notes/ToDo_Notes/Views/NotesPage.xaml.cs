using System;
using Xamarin.Forms;
using ToDo_Notes.Models;
using System.Linq;

namespace ToDo_Notes.Views
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            collViews.ItemsSource = await App.NotesDB.GetNodesAsync();

            base.OnAppearing();
        }
        private async void AddButton_Clicked(object sender, EventArgs e)
        { 
            await Shell.Current.GoToAsync(nameof(NoteAddingPage));
        }
        private async void On_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection != null)
            {
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(NoteAddingPage)}?{nameof(NoteAddingPage.ItemId)}={note.Id.ToString()}");
            }
        }
    }
}