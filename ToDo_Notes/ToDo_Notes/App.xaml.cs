using System;
using Xamarin.Forms;
using ToDo_Notes.Data;
using System.IO;
namespace ToDo_Notes
{
    public partial class App : Application
    {
        static NotesDB notesDB;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        public static NotesDB NotesDB
        {
            get
            {
                if (notesDB == null)
                {
                    notesDB = new NotesDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "NotesDatabase.db3"));
                }
                return notesDB;
            }
        }
        protected override void OnStart(){}
        protected override void OnSleep(){}
        protected override void OnResume(){}
    }
}
