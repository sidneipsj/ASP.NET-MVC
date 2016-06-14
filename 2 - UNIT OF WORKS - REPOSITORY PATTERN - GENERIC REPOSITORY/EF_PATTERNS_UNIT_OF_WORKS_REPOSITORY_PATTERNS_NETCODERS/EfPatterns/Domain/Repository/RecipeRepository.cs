using EfPatterns.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfPatterns.Domain.Repository
{
    public class RecipeRepository : BaseContext<Recipe>, IUnitofWork<Recipe>
    {

        int IUnitofWork<Recipe>.Save(Recipe model)
        {
            throw new NotImplementedException();
        }

        int IUnitofWork<Recipe>.Update(Recipe model)
        {
            throw new NotImplementedException();
        }

        void IUnitofWork<Recipe>.Delete(Recipe model)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Recipe> IUnitofWork<Recipe>.GetAll()
        {
            throw new NotImplementedException();
        }

        Recipe IUnitofWork<Recipe>.GetById(object id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Recipe> IUnitofWork<Recipe>.Where(System.Linq.Expressions.Expression<Func<Recipe, bool>> expression)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Recipe> IUnitofWork<Recipe>.OrderBy(System.Linq.Expressions.Expression<Func<Recipe, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}