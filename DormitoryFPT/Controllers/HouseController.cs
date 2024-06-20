using AutoMapper;
using DormitoryFPT.Data;
using DormitoryFPT.Models.Domain;
using DormitoryFPT.Models.Dto.HouseDataTransferObject;
using DormitoryFPT.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryFPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly DormDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IHouseRepository houseRepository;
        public HouseController(DormDbContext dbContext, IMapper mapper, IHouseRepository houseRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.houseRepository = houseRepository;
        }

        //GET ALL HOUSES
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from database
            var houses = await houseRepository.GetAllAsync();

            //Return data to client
            return Ok(mapper.Map<List<HouseDto>>(houses));
        }
        //GET HOUSE BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //get data from database
            var house = await houseRepository.GetByIdAsync(id);

            if(house == null)
            {
                return NotFound();
            }

            //Return data to client
            return Ok(mapper.Map<HouseDto>(house));
        }
        //CREATE HOUSE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddHouseRequestDto addHouseRequestDto)
        {
            //Map data from DTO to Domain
            var house = mapper.Map<House>(addHouseRequestDto);

            //Create house
            house = await houseRepository.CreateAsync(house);

            return CreatedAtAction(nameof(GetById), new { id = house.Id }, house);
        }

        //UPDATE HOUSE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateHouseRequestDto updateHouseRequestDto)
        {
            //Map data from DTO to Domain
            var house = mapper.Map<House>(updateHouseRequestDto);

            //Update house
            house = await houseRepository.UpdateAsync(id, house);

            if(house == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<HouseDto>(house));
        }

        //DELETE HOUSE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            //Delete house
            var house = await houseRepository.DeleteAsync(id);

            if(house == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<HouseDto>(house));
        }
    }
}
