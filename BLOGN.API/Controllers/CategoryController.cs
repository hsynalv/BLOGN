using AutoMapper;
using BLOGN.API.Services.IService;
using BLOGN.Models;
using BLOGN.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLOGN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var category = await _categoryService.Get(Id);
            var categoriesDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoriesDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var newCategory = await _categoryService.Add(category);
            return Created(String.Empty,null);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int Id, CategoryDto categoryDto)
        {
            if (Id == 0) return BadRequest();

            var category = _mapper.Map<Category>(categoryDto);
            _categoryService.Update(category);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            _categoryService.Delete(Id);
            return NoContent();
        }

    }
}
