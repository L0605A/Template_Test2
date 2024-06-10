using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("Order_Pastry")]
[PrimaryKey(nameof(OrderId), nameof(PastryId))]
public class SampleAssociativeModel
{
    public int OrderId { get; set; }
    public int PastryId { get; set; }
    public int Amount { get; set; }
    [MaxLength(300)]
    public string? Comment { get; set; }

    [ForeignKey(nameof(OrderId))]
    public SampleModelJoint Order { get; set; } = null!;
    [ForeignKey(nameof(PastryId))]
    public SampleModel3 Pastry { get; set; } = null!;
    
}