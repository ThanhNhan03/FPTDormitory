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
    public class DormController : ControllerBase
    {
        private readonly DormDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IDormRepository dormRepository;
        public DormController(DormDbContext dbContext, IMapper mapper, IDormRepository dormRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.dormRepository = dormRepository;
        }

        //GET ALL DORMS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from database
            var dorms = await dormRepository.GetAllAsync();

            //Return data to client
            return Ok(mapper.Map<List<DormDto>>(dorms));
        }
        //GET DORM BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //get data from database
            var dorm = await dormRepository.GetByIdAsync(id);

            if (dorm == null)
            {
                return NotFound();
            }

            //Return data to client
            return Ok(mapper.Map<DormDto>(dorm));
        }
    }
}
