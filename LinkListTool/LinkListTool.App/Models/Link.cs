using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LinkTool.Models
{
    public class Link
    {
        public Guid Id { get; set; }

        [Display(Name = "Link Url")]
        [Required(ErrorMessage = "Required")]
        public string? LinkUrl { get; set; }

        [Display(Name = "Link Text")]
        [Required(ErrorMessage = "Required")]
        public string? LinkText { get; set; }

        [Display(Name = "Link Category")]
        public string? LinkCategory { get; set; }

        [Display(Name = "Learning Path")]
        [Required(ErrorMessage = "Required")]
        public List<SelectListItem> LinkLearningPath { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Learning Path 01" },
            new SelectListItem { Value = "2", Text = "Learning Path 02" },
            new SelectListItem { Value = "3", Text = "Learning Path 03" },
            new SelectListItem { Value = "4", Text = "Learning Path 04" },
            new SelectListItem { Value = "5", Text = "Learning Path 05" },
            new SelectListItem { Value = "6", Text = "Learning Path 06" },
            new SelectListItem { Value = "7", Text = "Learning Path 07" },
            new SelectListItem { Value = "8", Text = "Learning Path 08" },
            new SelectListItem { Value = "9", Text = "Learning Path 09" },
            new SelectListItem { Value = "10", Text = "Learning Path 10" },
            new SelectListItem { Value = "11", Text = "Learning Path 11" },
            new SelectListItem { Value = "12", Text = "Learning Path 12" },
        };

        public int LinkLearningPathInt { get; set; }

    }

    public class LinkExport
    {
        public string? LinkUrl { get; set; }
        public string? LinkText { get; set; }
        public string? LinkCategory { get; set; }
        public int LinkLearningPathInt { get; set; }
    }
}