using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web136.Models.ScheduleTime
{
  public class PLScheduleTime
  {
    [Required] // others like [StringLength] [RegularExpression] [Range] can also available.
    [DisplayName("Schedule Time ID")] // display the label when using <%: Html.DisplayForModel() %>
    public string ID { get; set; }

    [Required]
    [DisplayName("Schedule Time")]
    public string scheduleTime { get; set; }

    
  }
}