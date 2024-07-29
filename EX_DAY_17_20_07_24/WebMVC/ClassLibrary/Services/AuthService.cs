using ClassLibrary.Interfaces;
using System.Data.SqlClient;
using ClassLibrary.Data;
using ClassLibrary.Interfaces;

namespace YourNamespace.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ValidateUser(string username, string password)
        {
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_AuthenticateUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", username));
                command.Parameters.Add(new SqlParameter("@Password", password));

                _context.Database.Connection.Open();
                var result = command.ExecuteScalar();
                _context.Database.Connection.Close();

                return result != null;
            }
        }
    }
}
