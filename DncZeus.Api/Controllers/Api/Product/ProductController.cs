using DncZeus.Api.Entities;
using DncZeus.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using DncZeus.Api.RequestPayload;
using System.Linq;
using AutoMapper;
using DncZeus.Api.ViewModels;
using System.Collections.Generic;

namespace DncZeus.Api.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductController(ProductDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult List(ProductRequsetPayload payload)
        {
            using (_dbContext)
            {
                var query = _dbContext.Product.AsQueryable();
                if (!string.IsNullOrEmpty(payload.ItemNo))
                {
                    query = query.Where(x => x.ItemNo.Contains(payload.ItemNo.Trim()));
                }
                if (!string.IsNullOrEmpty(payload.Type))
                {
                    query = query.Where(x => x.Type.Contains(payload.Type.Trim()));
                }
                if (!string.IsNullOrEmpty(payload.Country))
                {
                    query = query.Where(x => x.Country.Contains(payload.Country.Trim()));
                }
                if (!string.IsNullOrEmpty(payload.Brand))
                {
                    query = query.Where(x => x.Brand.Contains(payload.Brand.Trim()));
                }
                if (!string.IsNullOrEmpty(payload.TexNo))
                {
                    query = query.Where(x => x.TexNo.Contains(payload.TexNo.Trim()));
                }
                if (!string.IsNullOrEmpty(payload.Name_en))
                {
                    query = query.Where(x => x.Name_en.Contains(payload.Name_en.Trim()));
                }
                if (!string.IsNullOrEmpty(payload.Name_zh))
                {
                    query = query.Where(x => x.Name_zh.Contains(payload.Name_zh.Trim()));
                }
                if (!string.IsNullOrEmpty(payload.Element))
                {
                    query = query.Where(x => x.Element.Contains(payload.Element.Trim()));
                }
                var list = query.Paged(payload.CurrentPage, payload.PageSize).ToList();
                var totalCount = query.Count();
                var data = list.Select(_mapper.Map<Product, ProductJsonModel>);
                var response = ResponseModelFactory.CreateResultInstance;
                response.SetData(data, totalCount);
                return Ok(response);
            }
        }
        [HttpPost]
        public IActionResult Import([FromBody]List<ProductJsonModel> payload)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            using (_dbContext)
            {
                foreach (ProductJsonModel item in payload)
                {
                    var entity = _mapper.Map<ProductJsonModel, Product>(item);
                    _dbContext.Product.Add(entity);
                }
                _dbContext.SaveChanges();
            }
                response.SetSuccess();
            return Ok(response);
        }
    }
}
