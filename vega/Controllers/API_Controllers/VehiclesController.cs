using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega.Models;
using vega.Models.ViewModels;

namespace vega.Controllers.API_Controllers
{
    public class VehicleDisplay
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Contact { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VegaContext _context;

        public VehiclesController(VegaContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDisplay>>> GetVehicle()
        {


            var vehicles = await _context.Vehicle.ToListAsync();
            vehicles.ForEach(v => v.VehicleFeatures = _context.VehicleFeatures.Where(vf => vf.VehicleId == v.Id).ToList());
            vehicles.ForEach(v => v.Model = _context.Models.Where(m => m.Id == v.ModelId).FirstOrDefault());
            vehicles.ForEach(v => v.Model.Make = _context.Makes.Where(m => m.Id == v.Model.MakeId).FirstOrDefault());


            var result = vehicles.Select(v => new VehicleDisplay
            {
                Id = v.Id,
                Make = v.Model.Make.Name,
                Model = v.Model.Name,
                Contact = v.ContactName
            }).ToList<VehicleDisplay>();

            return result;
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);


            if (vehicle == null)
            {
                return NotFound();
            }

            vehicle.VehicleFeatures = _context.VehicleFeatures.Where(vf => vf.VehicleId == vehicle.Id).ToList();
            vehicle.Model = _context.Models.Where(m => m.Id == vehicle.ModelId).FirstOrDefault();
            vehicle.Model.Make = _context.Makes.Where(m => m.Id == vehicle.Model.MakeId).FirstOrDefault();
            return vehicle;
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, VehicleVM vehicleVM)
        {
            if (id != vehicleVM.Id)
            {
                return BadRequest();
            }
            var vehicle = new Vehicle()
            {
                Id = vehicleVM.Id,
                ModelId = vehicleVM.ModelId,
                Model = _context.Models.FirstOrDefault(m => m.Id == vehicleVM.ModelId),
                IsRegistered = vehicleVM.IsRegistered,
                ContactName = vehicleVM.ContactName,
                ContactPhone = vehicleVM.ContactPhone,
                ContactEmail = vehicleVM.ContactEmail,
                LastUpdated = DateTime.UtcNow,
                MoreInfo = vehicleVM.MoreInfo,
                VehicleFeatures = vehicleVM.VehicleFeatures.Select(f => new VehicleFeature { FeatureId = f, VehicleId = vehicleVM.Id }).ToList()
            };

            var features = _context.VehicleFeatures.Where(v => v.VehicleId == vehicle.Id);
            _context.VehicleFeatures.RemoveRange(features);
            _context.VehicleFeatures.AddRange(vehicle.VehicleFeatures);

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(vehicle);
        }

        // POST: api/Vehicles
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(VehicleVM vehicle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newvehicle = new Vehicle
            {
                ModelId = vehicle.ModelId,
                Model = _context.Models.FirstOrDefault(m => m.Id == vehicle.ModelId),
                IsRegistered = vehicle.IsRegistered,
                ContactName = vehicle.ContactName,
                ContactPhone = vehicle.ContactPhone,
                ContactEmail = vehicle.ContactEmail,
                MoreInfo = vehicle.MoreInfo,
                LastUpdated = DateTime.UtcNow
            };

            newvehicle.VehicleFeatures = vehicle.VehicleFeatures.Select(f => new VehicleFeature { FeatureId = f, VehicleId = newvehicle.Id }).ToList();
            _context.Vehicle.Add(newvehicle);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetVehicle", new { id = newvehicle.Id }, newvehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
