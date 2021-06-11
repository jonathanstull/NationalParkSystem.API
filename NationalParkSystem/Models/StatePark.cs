using System.ComponentModel.DataAnnotations;

namespace NationalParkSystem.Models
{
  public class StatePark
  {
    public int StateParkId { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    public string Status { get; set; } // lists federal or state designation (e.g., national monument, state historic site, etc.)

    [Required]
    [StringLength(22, ErrorMessage = "GPS coordinates must be in this format: 45.516022, -122.609424")]
    public string LatLong { get; set; } // specifies the coordinates of the park visitor center, if any; if more than one, the most centrally located is used, and if none, the main park access point will be used

    [Required]
    [StringLength(2, ErrorMessage = "State code must in this format: OR")]
    public string State { get; set; } // state in which the park resides

    [Required]
    public int Visits { get; set; } // specifies annual visitation where most recent data exists

    [Required]
    public string BusySeason { get; set; }
    
    [Required]
    public string Climate { get; set; } // specifies the USDA climate zone in which the park lies

    [Required]
    public bool RvServices { get; set; } // for electrical/sewage services; also reflects general park vehicle accessibility

    public byte[] Topo { get; set; }  // stretch goal: implement topographical map data in API calls
  }
}