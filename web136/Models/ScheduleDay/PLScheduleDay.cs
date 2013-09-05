using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web136.Models.ScheduleDay
{
  public class PLScheduleDay
  {
    [Required] // others like [StringLength] [RegularExpression] [Range] can also available.
    [DisplayName("Schedule Day ID")] // display the label when using <%: Html.DisplayForModel() %>
    public string ID { get; set; }

    [Required]
    [DisplayName("Schedule Day")]
    public string scheduleDay { get; set; }
  }
}