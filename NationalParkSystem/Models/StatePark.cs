using System.ComponentModel.DataAnnotations;

namespace NationalParkSystem.Models
{
  public class StatePark
  {
    int StateParkId { get; set; }
    
    [Required]
    string Name { get; set; }

    [Required]
    string Status { get; set; } // lists federal or state designation (e.g., national monument, state historic site, etc.)

    [Required]
    [StringLength(22, ErrorMessage = "GPS coordinates must be in this format: 45.516022, -122.609424")]
    string LatLong { get; set; } // specifies the coordinates of the park visitor center, if any; if more than one, the most centrally located is used, and if none, the main park access point will be used

    [Required]
    [StringLength(2, ErrorMessage = "State code must in this format: OR")]
    string State { get; set; } // state in which the park resides

    [Required]
    int Visits { get; set; } // specifies annual visitation where most recent data exists

    [Required]
    string BusySeason { get; set; }
    
    [Required]
    string Climate { get; set; } // specifies the USDA climate zone in which the park lies

    [Required]
    bool RvServices { get; set; } // for electrical/sewage services; also reflects general park vehicle accessibility

    blob Topo { get; set; }  // stretch goal: implement topographical map data in API calls
  }
}