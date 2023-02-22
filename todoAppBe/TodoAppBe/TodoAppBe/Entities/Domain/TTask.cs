using System;
using System.ComponentModel.DataAnnotations;
using TodoAppBe.DTO;

namespace TodoAppBe.Domain
{
    public class TTask
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid? PublicId { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string Priority { get; set; }

        public TTaskDto ToDto()
        {
            return new TTaskDto
            {
                Title = Title,
                Description = Description,
                Priority = Priority
            };
        }
    }
}