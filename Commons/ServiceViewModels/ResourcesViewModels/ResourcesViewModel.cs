using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Wiz.Common.ServiceViewModels.ResourcesViewModels;
public class ResourcesViewModel
{
    public string? Title { get; set; }
    public string? Type { get; set; }
    public string? Path { get; set; }
    public string? Icon { get; set; }
    public int? CategoryId { get; set; }
}
