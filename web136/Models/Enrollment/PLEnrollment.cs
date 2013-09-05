using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using web136.Models.Schedule;

namespace web136.Models.Enrollment
{
  public class PLEnrollment
  {
      [Required]
      [DisplayName("Schedule Course")]
      public PLScheduledCourse scheduledCourse { get; set; }

      [Required]
      [DisplayName("Grade")]
      public string grade { get; set; }
  }
}