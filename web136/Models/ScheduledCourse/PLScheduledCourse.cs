using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using web136.Models.Course;

namespace web136.Models.Schedule
{
  public class PLScheduledCourse
  {
    [Required]
    [DisplayName("Schedule ID")]
    public int schedule_id { get; set; }

    [Required]
    [DisplayName("Year")]
    public int year { get; set; }

    [Required]
    [DisplayName("Quarter")]
    public string quarter { get; set; }

    [Required]
    [DisplayName("Session")]
    public string session { get; set; }

    [Required]
    [DisplayName("Course")]
    public PLCourse course { get; set; }

    [Required]
    [DisplayName("Time ID")]
    public int timeID { get; set; }

    [Required]
    [DisplayName("Day ID")]
    public int dayID { get; set; }

    [Required]
    [DisplayName("Time")]
    public string time { get; set; }

    [Required]
    [DisplayName("Day")]
    public string day { get; set; }

    [Required]
    [DisplayName("Instructor ID")]
    public int instructorID { get; set; }

    [Required]
    [DisplayName("Instructor First Name")]
    public string firstName { get; set; }

    [Required]
    [DisplayName("Instructor Last Name")]
    public string lastName { get; set; }
  }
}