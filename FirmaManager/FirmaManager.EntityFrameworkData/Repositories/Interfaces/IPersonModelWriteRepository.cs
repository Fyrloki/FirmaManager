using FirmaManager.EntityFrameworkData.Models;
using System;

namespace FirmaManager.EntityFrameworkData.Repositories.Interfaces
{
    public interface IPersonModelWriteRepository
    {
        void DeletePerson(Guid guid, DieFirmaContext context, out bool isPersonDeleted);

        void CreatePerson(TbPerson person, DieFirmaContext context);

        void UpdatePerson(TbPerson person, DieFirmaContext context, out bool isPersonUpdated);
    }
}
