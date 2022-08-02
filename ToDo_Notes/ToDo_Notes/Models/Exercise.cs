using SQLite;
namespace ToDo_Notes.Models
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string THeader { get; set; }
        public string Description { get; set; }
    }
}
