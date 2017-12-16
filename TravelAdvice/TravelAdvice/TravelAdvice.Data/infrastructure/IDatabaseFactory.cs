using TravelAdvice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvice.Data.Models;

namespace TravelAdvice.Domaine.infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        traveladviceContext DataContext { get; }
    }
}
