using LanchesC.Models;
using System.Collections.Generic;

namespace LanchesC.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
