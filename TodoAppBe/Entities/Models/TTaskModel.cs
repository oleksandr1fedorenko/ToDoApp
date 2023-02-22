using System.ComponentModel.DataAnnotations;
using TodoAppBe.Domain;

namespace TodoAppBe.Entities;

public class TTaskModel
{
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Priority { get; set; }

        public TTask ToDomain()
        {
            return new TTask
            {
                Title = Title,
                Description = Description,
                Priority = Priority
            };
        }
    }