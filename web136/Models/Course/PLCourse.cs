using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web136.Models.Course
{
  public class PLCourse
  {
      [Required]
      [DisplayName("Course ID")]
      public int id { get; set; }

      [Required]
      [DisplayName("Course Title")]
      public string title { get; set; }

      [Required]
      [DisplayName("Course Level")]
      public int courseLevel { get; set; }

      [Required]
      [DisplayName("Description")]
      public string description { get; set; }

      [Required]
      [DisplayName("Units")]
      public int units { get; set; }

      [Required]
      [DisplayName("Prerequisites")]
      public List<PLCourse> prerequisiteList { get; set; }
  }
}