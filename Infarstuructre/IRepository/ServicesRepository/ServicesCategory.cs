using Domin.Entity;
using Infarstuructre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.IRepository.ServicesRepository
{
    public class ServicesCategory : IServicesRepository<Category>
    {
        private readonly FreeCourseDbContext _context;

        public ServicesCategory(FreeCourseDbContext context)
        {
            _context = context;
        }
        public bool Delete(Guid Id)
        {
            try
            {
                var result = FindBy(Id);
                result.CurrentStaut = (int)Helper.eCurrentState.Delete;
                _context.Categories.Update(result);
                _context.SaveChanges(); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category FindBy(Guid Id)
        {
            try
            {
                return _context.Categories.FirstOrDefault(x => x.Id.Equals(Id) && x.CurrentStaut > 0);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Category FindBy(string Name)
        {
            try
            {
                return _context.Categories.FirstOrDefault(x => x.Name.Equals(Name.Trim()) && x.CurrentStaut > 0);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Category> GetAll()
        {
            try
            {
                return _context.Categories.OrderBy(x => x.Name).Where(x => x.CurrentStaut > 0).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Save(Category model)
        {
            try
            {
                var result = FindBy(model.Id);
                if (result == null)
                {
                    
                    model.Id = Guid.NewGuid();
                    model.CurrentStaut = (int)Helper.eCurrentState.Active;
                    _context.Categories.Add(model);
                }
                else
                {
                    result.Name = model.Name;
                    result.Description = model.Description;
                    result.CurrentStaut = (int)Helper.eCurrentState.Active;
                    _context.Categories.Update(result);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
