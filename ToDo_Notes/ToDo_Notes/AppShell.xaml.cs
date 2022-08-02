using ToDo_Notes.Views;
using Xamarin.Forms;
namespace ToDo_Notes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NoteAddingPage), typeof(NoteAddingPage));
            Routing.RegisterRoute(nameof(ExerciseAddingPage), typeof(ExerciseAddingPage));
        }
    }
}