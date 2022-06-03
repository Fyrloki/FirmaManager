using FirmaManager.Common;
using FirmaManager.EntityFrameworkData.Models;
using System;
using System.Collections.Generic;

namespace FirmaManager.EntityFrameworkData.Repositories.Interfaces
{
    public interface IPersonModelReadRepository
    {
        List<TbPerson> GetPersons(string firstName, string lastName, DieFirmaContext context);

        Person GetPerson(Guid guid, DieFirmaContext context);
    }
}