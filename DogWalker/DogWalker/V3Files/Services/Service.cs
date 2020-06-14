using DogWalker.V3Files.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker.V3Files.Services
{
    public class Service
    {
        DWEntities context = new DWEntities();

        public List<OWNER> GetOwners()
        {
            var query = from OWNER in context.OWNERS
                        select OWNER;
            return query.ToList<OWNER>();
        }

        public List<DOG> GetDogs(OWNER owner)
        {
            var query = from DOGS in context.DOGS
                        where DOGS.OwnerID == owner.OwnerID
                        select DOGS;
            return query.ToList<DOG>();
        }

        public List<DOG> GetDogs()
        {
            var query = from DOGS in context.DOGS
                        select DOGS;
            return query.ToList<DOG>();
        }

        public List<WALK> GetWalks()
        {
            var query = from WALKS in context.WALKS
                        select WALKS;
            return query.ToList<WALK>();
        }

        public List<SCHEDULE> GetSchedules()
        {
            var query = from SCHEDULEs in context.SCHEDULEs
                        select SCHEDULEs;
            return query.ToList<SCHEDULE>();
        }
    }
}
