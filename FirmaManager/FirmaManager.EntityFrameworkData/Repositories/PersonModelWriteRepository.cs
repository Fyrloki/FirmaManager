using FirmaManager.EntityFrameworkData.Models;
using FirmaManager.EntityFrameworkData.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace FirmaManager.EntityFrameworkData.Repositories
{
    public class PersonModelWriteRepository : IPersonModelWriteRepository
    {
        public void CreatePerson(TbPerson person, DieFirmaContext context)
        {
            context.TbPeople.Add(person);
        }

        public void DeletePerson(Guid guid, DieFirmaContext context, out bool isPersonDeleted)
        {
            TbPerson person = context.TbPeople.Find(guid);

            if(person != null)
            {
                context.Remove(person);
                isPersonDeleted = true;

                return;
            }

            isPersonDeleted = false;
        }

        public void UpdatePerson(TbPerson person, DieFirmaContext context, out bool isPersonUpdated)
        {
            if (new PersonModelReadRepository().GetPerson(person.Uid, context) != null)
            {
                context.Update(person);
                isPersonUpdated = true;

                return;
            }

            isPersonUpdated = false;
        }
    }
}