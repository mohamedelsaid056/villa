using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using villa.Models;
using villa.Data;
using villa.DTO;
using AutoMapper;

namespace villa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class villaapiController : ControllerBase
    {

        private readonly ApiResponse _apiResponse;
        private readonly ILogger<villaapiController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper    _mapper;
        public villaapiController(ILogger<villaapiController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _apiResponse= new ApiResponse();
        }
        // private function using to mapping between villaDTO and villa
        private villaDTO MappingTovillaDTO(Models.villa villa)
        {
            return new villaDTO
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Rate = villa.Rate,
                Occupancy = villa.Occupancy,
                Sqft = villa.Sqft,
                ImageUrl = villa.ImageUrl,
                Amenity = villa.Amenity
            };
        }
        private Models.villa MappingTovilla(villaDTO villaDTO)
        {
            return new Models.villa
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Rate = villaDTO.Rate,
                Occupancy = villaDTO.Occupancy,
                Sqft = villaDTO.Sqft,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity
            };
        }

        



        

       

       

       
        // GET: api/villaapi
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetVillas()
        {
            var villas = await _context.Villas.ToListAsync();// if we have repository we will invoke it 

            _apiResponse.Result = villas.Select(v => MappingTovillaDTO(v));
            return Ok(_apiResponse);
        }

        // GET: api/villaapi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<villaDTO>> GetVilla(int id)
        {
            var villa = await _context.Villas.FindAsync(id);

            if (villa == null)
            {
                return NotFound();
            }

           // return MappingTovillaDTO(villa);
           //using mapping between villaDTO and villa
           return Ok(_mapper.Map<villaDTO>(villa));
        }

        // POST: api/villaapi
        [HttpPost]
        public async Task<ActionResult<villaDTO>> CreateVilla(villaDTO villaDTO)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if (villaDTO == null){
                return BadRequest(ModelState);
            }
           // var villa = MappingTovilla(villaDTO);
           //using automaper
           var villa = _mapper.Map<Models.villa>(villaDTO);
            _context.Villas.Add(villa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVilla), new { id = villa.Id }, MappingTovillaDTO(villa));
        }

        // PUT: api/villaapi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVilla(int id, villaDTO villaDTO)
        {
            if (id != villaDTO.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if(villaDTO == null){
                return BadRequest(ModelState);
            }

            var villa = await _context.Villas.FindAsync(id);
            if (villa == null)
            {
                return NotFound();
            }

            //villa = MappingTovilla(villaDTO);
            //using automaper
            var villaMap = _mapper.Map<Models.villa>(villaDTO);
            _context.Entry(villa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VillaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/villaapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            var villa = await _context.Villas.FindAsync(id);
            if (villa == null)
            {
                return NotFound();
            }

            _context.Villas.Remove(villa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VillaExists(int id)
        {
            return _context.Villas.Any(e => e.Id == id);
        }
         //patch method
        // [HttpPatch("{id}")]
        //  public async Task<IActionResult> Patchvilla(int id, [FromBody] JsonPatchDocument<villaDTO> patchDoc)
        //  {
        //    if (patchDoc == null)
        //    {
        //        return BadRequest();
        //    }

        //    var villa = await _context.villa.FindAsync(id);
        //    if (villa == null)
        //    {
        //        return NotFound();
        //    }

        //    patchDoc.ApplyTo(villa, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    await _context.SaveChangesAsync();
        //    return Ok(villa);
        //}
        //}

    }
}
