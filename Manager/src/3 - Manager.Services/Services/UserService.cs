using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Manager.Core.Exeptions;
using AutoMapper;
using Manager.Infra.Interfaces;
using Manager.Domain.Entities;

namespace Manger.Services.Services
{
    public class UserService : IUserServices
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExist = await _userRepository.GetByEmail(userDTO.email);
            var user = _mapper.Map<User>(userDTO);

            if(userExist != null){
                throw new DomainException("Já exite um usuario cadastrado com o email informado.");
            }

            user.Validate();

            var userCreated = await _userRepository.CreateAsync(user);
            
            return _mapper.Map<UserDTO>(userCreated);
        }
        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExist = await _userRepository.GetByEmail(userDTO.email);
            
            if(userExist != null){
                throw new DomainException("Já exite um usuario cadastrado com o email informado. ");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdate = await _userRepository.UpdateAsync(user);
            
            return _mapper.Map<UserDTO>(userUpdate);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var allUsers = await _userRepository.GetAllAsync();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }
        
        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.GetAsync(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var user = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(user);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var user = await _userRepository.SearchByEmail(name);

            return _mapper.Map<List<UserDTO>>(user);
        }

        public async Task remove(long id)
        {
            await _userRepository.RemoveAsync(id);
        }
    }
}