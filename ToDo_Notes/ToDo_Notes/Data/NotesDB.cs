using System.Collections.Generic;
using SQLite;
using ToDo_Notes.Models;
using System.Threading.Tasks;
namespace ToDo_Notes.Data
{
    public class NotesDB
    {
        readonly SQLiteAsyncConnection db;

        public NotesDB (string connectionString)
        {
            db = new SQLiteAsyncConnection (connectionString);

            db.CreateTableAsync<Note>().Wait();

            db.CreateTableAsync<Exercise>().Wait();
        }
        public Task<List<Note>> GetNodesAsync()
        {
            return db.Table<Note>().ToListAsync();
        }
        public Task<Note> GetNoteAsync(int id)
        {
            return db.Table<Note>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Note note)
        { 
            if(note.Id != 0)
            {
                return db.UpdateAsync(note);
            }
            else
            {
                return db.InsertAsync(note);
            }
        }
        public Task<int> DeleteNoteAsync(Note note)
        {
            return db.DeleteAsync(note);
        }
        public Task<List<Exercise>> GetExercisesAsync()
        {
            return db.Table<Exercise>().ToListAsync();
        }
        public Task<Exercise> GetExerciseAsync(int id)
        {
            return db.Table<Exercise>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveExerciseAsync(Exercise ex)
        {
            if (ex.Id != 0)
            {
                return db.UpdateAsync(ex);
            }
            else
            {
                return db.InsertAsync(ex);
            }
        }
        public Task<int> DeleteExerciseAsync(Exercise ex)
        {
            return db.DeleteAsync(ex);
        }
    }
}
