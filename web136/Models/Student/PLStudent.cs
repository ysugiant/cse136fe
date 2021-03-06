﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using web136.Models.Schedule;

namespace web136.Models.Student
{
  public class PLStudent
  {
    [Required] // others like [StringLength] [RegularExpression] [Range] can also available.
    [DisplayName("Student ID")] // display the label when using <%: Html.DisplayForModel() %>
    public string ID { get; set; }

    [Required]
    [StringLength(9)]
    [DisplayName("Social Security #")]
    public string SSN { get; set; }

    [Required]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [Required]
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [Required]
    [DisplayName("Email")] // you could use [RegularExpression]
    // [RegularExpression("regex pattern goes here...")]
    public string EmailAddress { get; set; }

    [Required]
    [DisplayName("Password")]
    [ScaffoldColumn(false)] // don't show this in <%: Html.DisplayForModel() %>
    public string Password { get; set; }

    [Required]
    [DisplayName("Shoe Size")]
    [ScaffoldColumn(false)] // don't show this in <%: Html.DisplayForModel() %>
    public float ShoeSize { get; set; }

    [Required]
    [DisplayName("Weight")]
    [ScaffoldColumn(false)] // don't show this in <%: Html.DisplayForModel() %>
    public int Weight { get; set; }

    [Required]
    [DisplayName("Student Level")]
    [ScaffoldColumn(false)] // don't show this in <%: Html.DisplayForModel() %>
    public string StudentLevel { get; set; }

    [Required]
    [DisplayName("Status")]
    [ScaffoldColumn(false)] // don't show this in <%: Html.DisplayForModel() %>
    public int Status { get; set; }

    [Required]
    [DisplayName("Major")]
    [ScaffoldColumn(false)] // don't show this in <%: Html.DisplayForModel() %>
    public int Major { get; set; }

    [DisplayName("Enrollment")]
    public List<PLScheduledCourse> Enrollments { get; set; }
  }
}