using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkTracker.Web.Models
{
    /// <summary>
    /// Project model object
    /// </summary>
    public class ProjectModel
    {
        /// <summary>
        /// Id of the project
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the project
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Assoicated tasks
        /// </summary>
        public List<TaskModel> Tasks { get; set; }
    }
}
