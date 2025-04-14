using ModelsUsers.Users;

namespace RepositoriesIAuthenticate.IAuthenticate
{
    public interface IAuthenticate
    {

        public string GenerateToken(int id, string username);
        public User ValidateUser(string user, string password);
    }

}