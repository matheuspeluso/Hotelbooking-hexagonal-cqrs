using Data.Contexts;
using Domain.Ports;
using Entities = Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Guest.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DataContext _context;

        public GuestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Entities.Guest guest)
        {
            _context.Add(guest);
            await _context.SaveChangesAsync();
            return guest.Id;
        }

        public async Task<Entities.Guest> Get(Guid id)
        {
            return await _context.Guests.FirstOrDefaultAsync(g => g.Id == id)
                ?? throw new ApplicationException("Guest not found.");
        }
    }
}
