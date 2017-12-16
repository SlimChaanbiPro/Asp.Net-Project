
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvice.Domaine;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Service
{
  public  interface IVoleService : IDisposable
    {
        void AddVole(vole vole);
        void DeleteVole(int id);
        IEnumerable<vole> GetAllVole();
        IEnumerable<vole> GetAllVolsFromNow();
        vole GetVoleById(int id);
        void Update(vole h);

        void SaveChange();
      //  Dictionary<string, int> StatHouse();
        int NbreVole();
     //   IEnumerable<vole> GetHouseBySwapper(string nom);
       // IEnumerable<vole> getAllServBySwapper(Swapper swapper);
    //    Swapper getSwapperByName(string name);
    }
}
