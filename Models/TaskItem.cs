namespace TaskManagement.API.Models
{
    public class TaskItem
    {
        public int Id { get; set; } 

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool isCompleted { get; set; } = false;

        public int Priority { get; set; } //1 = low , 2= medieum ,3 = high

        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        //foreign Key

        public int UserId { get; set; }

        //Navigation Property 

        public User User { get; set; } = null!;
    }
}
