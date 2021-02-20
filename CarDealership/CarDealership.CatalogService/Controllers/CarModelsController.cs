using AutoMapper;
using CarDealership.CatalogService.Data;
using CarDealership.CatalogService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private CatalogContext _catalogContext;
        private IMapper _mapper;
        public CarModelsController(CatalogContext catalogContext, IMapper mapper)
        {
            _catalogContext = catalogContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CarModelDto>> Get()
        {
            var carModels = await _catalogContext.CarModels
                .Include(x => x.CarManufacturer)
                .ToListAsync();
            return _mapper.Map<List<CarModelDto>>(carModels);
        }

        [HttpGet("{id}")]
        public async Task<CarModelFullDto> GetById(int id)
        {
            var carModel = await _catalogContext.CarModels
                .Include(x => x.CarManufacturer)
                .Include(x => x.CarOptionGroups)
                .Include("CarOptionGroups.CarOptions")
                .FirstOrDefaultAsync(c => c.Id == id);

            if (carModel == null)
                throw new ArgumentException($"No car model found with id {id}", "id");

            return _mapper.Map<CarModelFullDto>(carModel);
        }
    }
}