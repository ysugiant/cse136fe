using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using web136.Models.Schedule;
using web136.Models.Department;

namespace web136.Models.Staff
{
  public class PLStaff
  {
    [Required] // others like [StringLength] [RegularExpression] [Range] can also available.
    [DisplayName("Staff ID")] // display the label when using <%: Html.DisplayForModel() %>
    public int ID { get; set; }

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
    [DisplayName("Department")]
    [ScaffoldColumn(false)] // don't show this in <%: Html.DisplayForModel() %>
    public PLDepartment Department { get; set; }
    //public int Department { get; set; }

    [Required]
    [DisplayName("Instructor Status")]
    [ScaffoldColumn(false)] // don't show this in <%: Html.DisplayForModel() %>
    public bool isInstructor { get; set; }
  }
}