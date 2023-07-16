using MagicVilla.Models.Dto;

namespace MagicVilla.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO {Id=1,Name="Pool View Villa",Occupancy=11,Sqft=500},
            new VillaDTO {Id=2,Name="Beach View Villa",Occupancy=4,Sqft=100}
        };
    }
}
