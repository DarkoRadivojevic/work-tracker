namespace WorkTracker.Business.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
