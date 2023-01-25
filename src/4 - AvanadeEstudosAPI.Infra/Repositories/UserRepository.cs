using AvanadeEstudosAPI.Domain.Entities;
using AvanadeEstudosAPI.Infra.Context;
using AvanadeEstudosAPI.Domain.Interfaces;

namespace AvanadeEstudosAPI.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository{

        private readonly AvanadeEstudosAPIContext _context;

        public UserRepository(AvanadeEstudosAPIContext context) : base(context)
        {
            _context = context;
        }        
    }
}