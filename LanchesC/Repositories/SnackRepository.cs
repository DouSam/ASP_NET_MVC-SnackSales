using LanchesC.Data;
using LanchesC.Models;
using LanchesC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LanchesC.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly AppDbContext _context;
        public SnackRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Snack> Snacks => _context.Snacks.Include(c => c.Category);

        public IEnumerable<Snack> PreferredSnacks => _context.Snacks.
                                   Where(l => l.IsPreferredSnack)
                                  .Include(c => c.Category);

        public Snack GetSnackById(int snackId)
        {
            return _context.Snacks.FirstOrDefault(l => l.SnackId == snackId);
        }
    }
}
