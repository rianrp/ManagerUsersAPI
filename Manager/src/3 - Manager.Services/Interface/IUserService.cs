using System.Threading.Tasks;
using System.Collections.Generic;
using Manager.Services.DTO;

namespace Manager.Services.Interfaces
{
    public interface IUserServices{
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task remove(long id);
        Task<UserDTO> Get(long id);
        Task<List<UserDTO>> GetAll();
        Task<List<UserDTO>> SearchByName(string name);
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<UserDTO> GetByEmail(string email);
    }
}