using RegisterandLoginApp2.Models;

namespace RegisterandLoginApp2.Services
{
    public class SecurityService
    {
       
        UsersDAO usersDAO = new UsersDAO();

        public SecurityService()
        {
           

        }

        public bool IsValid (UserModel user)

        {
            return usersDAO.FindUserByNameAndPassword(user);
            //return ture if found in the list
            
        }
    }
}
