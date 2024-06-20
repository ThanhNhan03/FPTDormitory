using AutoMapper;
using DormitoryFPT.Data;
using DormitoryFPT.Models.Dto;
using DormitoryFPT.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryFPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly DormDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IFloorRepository floorRepository;
        public FloorController(DormDbContext dbContext, IMapper mapper, IFloorRepository floorRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.floorRepository = floorRepository;
        }

        //GET ALL FLOORS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from database
            var floors = await floorRepository.GetAllFloors();

            //Return data to client
            return Ok(mapper.Map<List<FloorDto>>(floors));
        }

        //GET FLOOR BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //get data from database
            var floor = await floorRepository.GetFloorById(id);

            if (floor == null)
            {
                return NotFound();
            }

            //Return data to client
            return Ok(mapper.Map<FloorDto>(floor));
        }
    }
}
