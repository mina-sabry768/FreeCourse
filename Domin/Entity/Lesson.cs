using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Lesson
    {
        public Guid Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resoures.ResourceData), ErrorMessageResourceName = "LessonName")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resoures.ResourceData), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resoures.ResourceData), ErrorMessageResourceName = "MinLength")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resoures.ResourceData), ErrorMessageResourceName = "TeacherName")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resoures.ResourceData), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resoures.ResourceData), ErrorMessageResourceName = "MinLength")]
        public string Teacher { get; set; }
        public string ImageName { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public bool Publish { get; set; }


        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public Guid SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }


        public int CurrentStaut { get; set; }
    }
}
