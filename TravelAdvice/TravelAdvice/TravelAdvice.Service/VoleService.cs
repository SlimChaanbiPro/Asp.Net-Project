using System.Collections.Generic;

using TravelAdvice.Domaine.infrastructure;
using System;
using System.Linq;
using TravelAdvice.Domaine;
using TravelAdvice.Domaine.Entity;

namespace TravelAdvice.Service
{
    public class VoleService : IVoleService
    {
        IDatabaseFactory dbfactory = null;
        IUnitOfWork uow = null;
        public VoleService()
        {
            dbfactory = new DatabaseFactory();
            uow = new UnitOfWork(dbfactory);

        }
        public void AddVole(vole vole)
        {
            uow.VoleRepository.Add(vole);
        }

        public void DeleteVole(int id)
        {
           vole p = uow.getRepository<vole>().GetById(id);
            uow.getRepository<vole>().Delete(p);
            uow.Commit();
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public IEnumerable<vole> GetAllVole()
        {
            return uow.getRepository<vole>().GetAll();
        }

        public IEnumerable<vole> GetAllVolsFromNow()
        {
            DateTime current = DateTime.Now;
            return uow.getRepository<vole>().GetMany(v=>v.date_depart>current);
        }

      

        public vole GetVoleById(int id)
        {
            return uow.getRepository<vole>().GetById(id);
        }

        public int NbreVole()
       
            {

                return uow.getRepository<vole>().GetAll().Count();
            }

        public void SaveChange()
        {
            uow.Commit();
        }

      /*  public Dictionary<string, int> StatVole()
        {
            {

                var ss = from vole u in uow.getRepository<vole>().GetAll()
                         group u by u.type into g
                         select new { g.Key, Count = g.Count() };
                Dictionary<string, int> typeHouse = new Dictionary<string, int>();
                foreach (var t in ss)
                {
                    typeHouse.Add(t.Key, t.Count);
                    Console.WriteLine(t.Key + "" + t.Count);
                }
                return typeHouse;
            }
        }*/

        public void Update(vole h)
        {
            uow.getRepository<vole>().Update(h);
            uow.Commit();

        }

       // public IEnumerable<House> getAllServBySwapper(Swapper swapper)
      //  {

          //  return uow.getRepository<House>().GetMany(c => c.swapper.idSwapper == swapper.idSwapper);
           


   // }
      //  public Swapper getSwapperByName(string name)
      //  {
       //     return uow.getRepository<Swapper>().Get(x => x.name == name);
       // }
    }
}
