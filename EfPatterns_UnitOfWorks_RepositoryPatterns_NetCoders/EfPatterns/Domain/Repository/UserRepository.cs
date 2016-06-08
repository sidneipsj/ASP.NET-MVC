using EfPatterns.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfPatterns.Domain.Repository
{
    public class UserRepository : BaseContext<User>, IUnitofWork<User>
    {

        int IUnitofWork<User>.Save(User model)
        {
            throw new NotImplementedException();
        }

        int IUnitofWork<User>.Update(User model)
        {
            throw new NotImplementedException();
        }

        void IUnitofWork<User>.Delete(User model)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUnitofWork<User>.GetAll()
        {
            throw new NotImplementedException();
        }

        User IUnitofWork<User>.GetById(object id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUnitofWork<User>.Where(System.Linq.Expressions.Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUnitofWork<User>.OrderBy(System.Linq.Expressions.Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}