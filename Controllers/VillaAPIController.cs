using MagicVilla.Data;
using Newtonsoft.Json;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
//using System.Web.Http;
using MagicVilla.Logging;
using MagicVilla.Models;
using MagicVilla.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;




namespace MagicVilla.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        //private readonly ILogging _logger;

        //public VillaAPIController(ILogging logger) 
        //{
        //    _logger = logger;
        //}


        private readonly ApplicationDbContext _db;
        public VillaAPIController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //get all villas
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            string selectAllQuery = "SELECT * FROM Magical_Villas";

            List<Villa> villas = _db.Magical_Villas.FromSqlRaw(selectAllQuery).ToList();
            List<VillaDTO> villaDTOs = villas.Select(v => new VillaDTO
            {
                // Map the properties from Villa to VillaDTO
                Amenity = v.Amenity,
                Name = v.Name,
                Details = v.Details,
                Id = v.Id,
                ImageUrl = v.ImageUrl,
                SqFt = v.SqFt,
                Rate = v.Rate,
                Occupancy = v.Occupancy,
            }).ToList();
            //_logger.Log("GEtting Villas" , "");
            return Ok(villaDTOs);
        }


        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //get 1 villa by id
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                //_logger.Log("Cannot Get Villas"+id,"error");
                return BadRequest();
            }

            string selectVillaQuery = "SELECT * FROM Magical_Villas WHERE Id = @id";
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@id", id)
    };

            Villa villa = _db.Magical_Villas.FromSqlRaw(selectVillaQuery, parameters.ToArray()).FirstOrDefault();

            if (villa == null)
            {
                return NotFound();
            }

            VillaDTO villaDTO = new VillaDTO
            {
                // Map the properties from Villa to VillaDTO
                Amenity = villa.Amenity,
                Name = villa.Name,
                Details = villa.Details,
                Id = villa.Id,
                ImageUrl = villa.ImageUrl,
                SqFt = villa.SqFt,
                Rate = villa.Rate,
                Occupancy = villa.Occupancy,
            };

            return Ok(villaDTO);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //create villa
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if (_db.Magical_Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa with the same name already Exists");
                return BadRequest(ModelState);
            }

            if (villaDTO == null)
            {
                return BadRequest();
            }

            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            // Construct the SQL query for inserting the values
            string insertSql = @"
        INSERT INTO Magical_Villas ( Amenity, Name, Details, ImageUrl, SqFt, Rate, Occupancy)
        VALUES ( @Amenity, @Name, @Details, @ImageUrl, @SqFt, @Rate, @Occupancy);
        SELECT SCOPE_IDENTITY();";

            // Create the parameters for the SQL query
            var parameters = new List<SqlParameter>
    {

        new SqlParameter("@Amenity", villaDTO.Amenity),
        new SqlParameter("@Name", villaDTO.Name),
        new SqlParameter("@Details", villaDTO.Details),
        new SqlParameter("@ImageUrl", villaDTO.ImageUrl),
        new SqlParameter("@SqFt", villaDTO.SqFt),
        new SqlParameter("@Rate", villaDTO.Rate),
        new SqlParameter("@Occupancy", villaDTO.Occupancy)
    };

            // Execute the SQL query and get the inserted ID
            int newVillaId = _db.Database.ExecuteSqlRaw(insertSql, parameters.ToArray());

            // If the insertion was successful, create the response and return
            if (newVillaId > 0)
            {
                villaDTO.Id = newVillaId;
                return CreatedAtRoute("GetVilla", new { id = newVillaId }, villaDTO);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //delete villa by id
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            string deleteVillaQuery = "DELETE FROM Magical_Villas WHERE Id = @id";
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@id", id)
    };

            int rowsAffected = _db.Database.ExecuteSqlRaw(deleteVillaQuery, parameters.ToArray());

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //put update villa by id
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                return NotFound();
            }

            string updateVillaQuery = @"
        UPDATE Magical_Villas
        SET Amenity = @Amenity,
            Name = @Name,
            Details = @Details,
            ImageUrl = @ImageUrl,
            SqFt = @SqFt,
            Rate = @Rate,
            Occupancy = @Occupancy
        WHERE Id = @Id;";

            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@Amenity", villaDTO.Amenity),
        new SqlParameter("@Name", villaDTO.Name),
        new SqlParameter("@Details", villaDTO.Details),
        new SqlParameter("@ImageUrl", villaDTO.ImageUrl),
        new SqlParameter("@SqFt", villaDTO.SqFt),
        new SqlParameter("@Rate", villaDTO.Rate),
        new SqlParameter("@Occupancy", villaDTO.Occupancy),
        new SqlParameter("@Id", id)
    };

            int rowsAffected = _db.Database.ExecuteSqlRaw(updateVillaQuery, parameters.ToArray());

            if (rowsAffected == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }


        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //patch update villa by id
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }

            // Retrieve the existing Villa entity from the database
            var villa = _db.Magical_Villas.AsNoTracking().FirstOrDefault(u => u.Id == id); // to not track when retrieving records
            if (villa == null)
            {
                return NotFound();
            }

            // Convert the Villa entity to a new VillaDTO object
            var villaDTO = new VillaDTO
            {
                Amenity = villa.Amenity,
                Name = villa.Name,
                Details = villa.Details,
                Id = villa.Id,
                ImageUrl = villa.ImageUrl,
                SqFt = villa.SqFt,
                Rate = villa.Rate,
                Occupancy = villa.Occupancy
            };

            // Apply the partial updates from patchDTO to the VillaDTO
            patchDTO.ApplyTo(villaDTO, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update the Villa entity with the changes from the VillaDTO
            villa.Amenity = villaDTO.Amenity;
            villa.Name = villaDTO.Name;
            villa.Details = villaDTO.Details;
            villa.ImageUrl = villaDTO.ImageUrl;
            villa.SqFt = villaDTO.SqFt;
            villa.Rate = villaDTO.Rate;
            villa.Occupancy = villaDTO.Occupancy;

            _db.Magical_Villas.Update(villa);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
