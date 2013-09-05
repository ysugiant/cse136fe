using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web136.Models.Department
{
  public class PLDepartment
  {
    [Required]
    [DisplayName("Department ID")]
    public int ID { get; set; }

    [Required]
    [DisplayName("Department Name")]
    public string deptName { get; set; }

    [Required]
    [DisplayName("Department Chair")]
    public int chair_id { get; set; }
  }
}