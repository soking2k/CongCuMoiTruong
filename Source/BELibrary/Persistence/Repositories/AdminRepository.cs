using System.Linq;
using BELibrary.Core.Entity.Repositories;
using BELibrary.Core.Utils;
using BELibrary.DbContext;
using BELibrary.Entity;
using BELibrary.Utils;

namespace BELibrary.Persistence.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(CinemaOnlineDbContext context)
            : base(context)
        {
        }

        public Admin ValidBEAccount(string username)
        {
            var db = CinemaOnlineDbContext;

            var role = db.Roles.FirstOrDefault(x => x.Name == "Admin");

            var account =
                  db.Admins.FirstOrDefault(x =>
                  x.RoleId == role.Id
                  && x.UserName.ToLower() == username.ToLower()
                  && !x.IsDelete);

            return account;
        }

        public Admin GetAccountByUsername(string username)
        {
            //need implement ,bad
            var db = CinemaOnlineDbContext;

            var role = db.Roles.FirstOrDefault(x => x.Name == "Admin");

            var account =
                  db.Admins.FirstOrDefault(x =>
                  x.RoleId == role.Id
                  && x.UserName.ToLower() == username.ToLower()
                  && !x.IsDelete);

            return account;
        }

        public CinemaOnlineDbContext CinemaOnlineDbContext => Context;
    }
}