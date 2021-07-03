using System.ComponentModel.DataAnnotations;

namespace WorkTracker.Web.Models
{
    /// <summary>
    /// Task model object
    /// </summary>
    public class TaskModel
    {
        /// <summary>
        /// Id of the tasks
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the task
        /// </summary>
        [Required]
        public string TaskName { get; set; }

        /// <summary>
        /// Description of the task
        /// </summary>
        public string TaskDescription { get; set; }

        /// <summary>
        /// Id of the assoicated project
        /// </summary>
        [Required]
        public int ProjectId { get; set; }

        /// <summary>
        /// Associated project
        /// </summary>
        public ProjectModel Project { get; set; }
    }
}
