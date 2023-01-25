namespace AvanadeEstudosAPI.Services.DTO
{
    public class UserDTO
    {
         //Propriedades
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        

        public UserDTO(){}
       
        public UserDTO(long id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
           
        }

        public UserDTO(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}

