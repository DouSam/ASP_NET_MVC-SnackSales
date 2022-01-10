using LanchesC.Models;
using System.Collections.Generic;

namespace LanchesC.Repositories.Interfaces
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }
        IEnumerable<Snack> PreferredSnacks { get; }
        Snack GetSnackById(int snackId);

    }
}
