using Domain.Exceptions;
using Domain.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Helpers;
using Domain.Ports;

namespace Domain.Entities
{
    public class Guest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public PersonId DocumentId { get; set; }


        private void ValidateState()
        {
            if(DocumentId == null || DocumentId.IdNumber.Length <= 3 || DocumentId.DocumentType == 0 )
            {
                throw new InvalidPersonDocumentIdException();
            }

            if(Name == null || SurName == null || Email == null)
            {
                throw new MissingRequiredInformationException();
            }

            if (UtilsHelper.ValidateEmail(this.Email) == false)
            {
                throw new InvalidEmailException();
            }
        }

        public async Task Save(IGuestRepository guestRepository)
        {
            this.ValidateState();
            if (this.Id == Guid.Empty)
            {
                this.Id = await guestRepository.Create(this);
            }
            else
            {
                //await guestRepository.Update(this);
            }
        }
    }
}
