using ModelsUsers.Users;

namespace RepositoriesIAuthenticate.IAuthenticate
{
    public interface IAuthenticate
    {

       public string GenerateToken(int id, int userProfilesId, string username);

        public (User user, int userProfilesId) ValidateUser(string user, string password);
    }

}