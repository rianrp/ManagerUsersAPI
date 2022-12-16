namespace Manager.Services.DTO
{
    public class UserDTO{
        public long Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public UserDTO()
        {
            
        }

        public UserDTO(long id, string name, string email, string password)
        {
            Id = id;
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }
}