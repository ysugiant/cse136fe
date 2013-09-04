using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web136.Models.Major
{
  public class PLMajor
  {
    [Required]
    [DisplayName("Major ID")]
    public int major_id { get; set; }

    [Required]
    [DisplayName("Major Name")]
    public string major_name { get; set; }

    [Required]
    [DisplayName("Department ID")]
    public int dept_id { get; set; }
  }
}