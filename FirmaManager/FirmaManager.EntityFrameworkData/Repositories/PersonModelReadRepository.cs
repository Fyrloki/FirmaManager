using FirmaManager.Common;
using FirmaManager.EntityFrameworkData.Models;
using FirmaManager.EntityFrameworkData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirmaManager.EntityFrameworkData.Repositories
{
    public class PersonModelReadRepository : IPersonModelReadRepository
    {
        public List<TbPerson> GetPersons(string firstName, string lastName, DieFirmaContext context)
        {
            IQueryable<TbPerson> tbPersonQuery = (from c in context.TbPeople
                            where EF.Functions.Like(c.Name, lastName)
                            where EF.Functions.Like(c.Vorname, firstName)
                            select c).AsNoTracking();

            return tbPersonQuery.ToList();
        }

        public Person GetPerson(Guid guid, DieFirmaContext context)
        {
            IQueryable<TbPerson> tbPersonQuery = (from c in context.TbPeople
                            where c.Uid == guid
                            select c).AsNoTracking();

            return tbPersonQuery.FirstOrDefault();
        }
    }
}