using AutoMapper;
using DormitoryFPT.Data;
using DormitoryFPT.Models.Domain;
using DormitoryFPT.Models.Dto.RoomDataTransferObject;
using DormitoryFPT.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryFPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly DormDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IRoomRepository roomRepository;
        public RoomController(DormDbContext dbContext, IMapper mapper, IRoomRepository roomRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.roomRepository = roomRepository;
        }

        //GET ALL ROOMS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from database
            var rooms = await roomRepository.GetAllAsync();

            //Return data to client
            return Ok(mapper.Map<List<RoomDto>>(rooms));
        }
        //GET ROOM BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //get data from database
            var room = await roomRepository.GetByIdAsync(id);

            if(room == null)
            {
                return NotFound();
            }

            //Return data to client
            return Ok(mapper.Map<RoomDto>(room));
        }

        //CREATE ROOM
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddRoomRequestDto addRoomRequestDto)
        {
            //Map data from DTO to Domain
            var room = mapper.Map<Room>(addRoomRequestDto);

            //Create room
            room = await roomRepository.CreateAsync(room);

            var roomDto = mapper.Map<RoomDto>(room);

            //Return data to client
            return CreatedAtAction(nameof(GetById), new { id = roomDto.Id }, roomDto);
        }
        //UPDATE ROOM
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateRoomRequestDto updateRoomRequestDto)
        {
            //Map data from DTO to Domain
            var room = mapper.Map<Room>(updateRoomRequestDto);

            //Update room
            room = await roomRepository.UpdateAsync(id, room);

            if (room == null)
            {
                return NotFound();
            }

            var roomDto = mapper.Map<RoomDto>(room);

            //Return data to client
            return Ok(roomDto);
        }
        //DELETE ROOM
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var room = await roomRepository.DeleteAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RoomDto>(room));
        }
    }
}
