using Application.Guest.Dtos;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.Exceptions;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GuestManager : IGuestManager
    {
        private readonly IGuestRepository _guestRepository;

        public GuestManager(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<GuestResponse> CreateGuest(CreateGuestRequest request)
        {
            try
            {
                var guest = GuestDTO.MapToEntity(request.Data);
                await guest.Save(_guestRepository);

                request.Data.Id = guest.Id;

                return new GuestResponse
                {
                    Data = request.Data,
                    Success = true,
                    Message = "Guest created successfully."
                };
            }catch(InvalidPersonDocumentIdException ex)
            {
                return new GuestResponse
                {
                    Data = null,
                    Success = false,
                    ErrorCoders = ErrorCoders.INVALID_PERSON_ID,
                    Message = "The ID passed is not valid."
                };
            }

            catch(MissingRequiredInformationException ex)
            {
                return new GuestResponse
                {
                    Data = null,
                    Success = false,
                    ErrorCoders = ErrorCoders.MISSING_REQUIRED_INFORMATION,
                    Message = "Some required information is missing."
                };
            }

            catch(InvalidEmailException ex)
            {
                return new GuestResponse
                {
                    Data = null,
                    Success = false,
                    ErrorCoders = ErrorCoders.INVALID_EMAIL,
                    Message = "The email passed is not valid."
                };
            }
            
            catch(Exception)
            {
                return new GuestResponse
                {
                    Data = null,
                    Success = false,
                    Message = "There was an error while saving to Db.",
                    ErrorCoders = ErrorCoders.COULD_NOT_STORE_DATA
                };
            }
        }
    }
}
