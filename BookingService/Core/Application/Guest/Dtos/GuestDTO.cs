using Domain.Entities;
using Entities = Domain.Entities;
using Domain.Enums;

namespace Application.Guest.Dtos
{
    public class GuestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public int IdTypeCode { get; set; }

        public static Entities.Guest MapToEntity(GuestDTO guestDTO)
        {
            return new Entities.Guest
            {
                Id = guestDTO.Id,
                Name = guestDTO.Name,
                SurName = guestDTO.Surname,
                Email = guestDTO.Email,
                DocumentId = new Domain.ValueObjets.PersonId
                {
                    IdNumber = guestDTO.IdNumber,
                    DocumentType = (DocumentType)guestDTO.IdTypeCode
                }
            };
        }

    }
}
