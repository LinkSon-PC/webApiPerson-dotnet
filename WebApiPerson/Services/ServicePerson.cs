using Microsoft.EntityFrameworkCore;
using WebApiPerson.Context;
using WebApiPerson.Models;

namespace WebApiPerson.Services
{
    public interface IServicePerson { 
        public Task<IEnumerable<Person>> Get();
        public Task Insert(Person person);
        public Task<Person> GetById(int Id);
        public Task Update (Person person);
        public Task Delete(int Id);
    }
    public class ServicePerson : IServicePerson
    {
        private readonly AppDbContext _context;

        public ServicePerson(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task Delete(int Id)
        {
            var person = _context.Persons.Find(Id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Person>> Get()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetById(int Id)
        {
            return await _context.Persons.FindAsync(Id);
        }

        public async Task Insert(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Person person)
        {
            _context.Update(person);
            await _context.SaveChangesAsync();
        }
    }
}
