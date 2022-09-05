using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models.Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task< CategoryDto > Create(CategoryDto objDto)
        {
            var obj = _mapper.Map<CategoryDto, Category>(objDto);
            obj.CreatedDate = DateTime.Now; 

            var addedObj = _context.Categories.Add(obj);
            await _context.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDto>(addedObj.Entity);
        }

        public async Task< int > Delete(int id)
        {
            var obj = await _context.Categories.FirstOrDefaultAsync(l => l.Id == id);
            if (obj != null)
            {
                _context.Categories.Remove(obj);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_context.Categories);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var obj= await _context.Categories.FirstOrDefaultAsync(l => l.Id == id);
            if (obj!=null)
            {
                return _mapper.Map<Category, CategoryDto>(obj);
            }
            return new CategoryDto();
        }

        public async Task<CategoryDto> Update(CategoryDto objDto)
        {
            var obj = await _context.Categories.FirstOrDefaultAsync(u => u.Id == objDto.Id);
            if (obj!=null)
            {
                obj.Name = objDto.Name;
                _context.Categories.Update(obj);
                _context.SaveChanges();
                return _mapper.Map<Category, CategoryDto>(obj);
            }
            return objDto;
        }
    }
}
