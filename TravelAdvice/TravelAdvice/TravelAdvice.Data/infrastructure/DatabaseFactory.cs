
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvice.Data;
using TravelAdvice.Data.Models;

namespace TravelAdvice.Domaine.infrastructure
{

    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private traveladviceContext dataContext;
        public traveladviceContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new traveladviceContext();
        }
        protected override void DisposeCore()//libérer l'espace mémoire du contexte
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
