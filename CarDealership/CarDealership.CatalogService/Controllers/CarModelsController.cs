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
        public List<CarModelDto> Get()
        {
            var carModels = _catalogContext.CarModels
                .Include(x => x.CarManufacturer)
                .ToList();
            return _mapper.Map<List<CarModelDto>>(carModels);
        }

        [HttpGet("{id}")]
        public CarModelFullDto GetById(int id)
        {
            var carModel = _catalogContext.CarModels
                .Include(x => x.CarManufacturer)
                .Include(x => x.CarOptionGroups)
                .Include("CarOptionGroups.CarOptions")
                .FirstOrDefault(c => c.Id == id);

            if (carModel == null)
                throw new ArgumentException($"No car model found with id {id}", "id");

            return _mapper.Map<CarModelFullDto>(carModel);
        }
    }
}