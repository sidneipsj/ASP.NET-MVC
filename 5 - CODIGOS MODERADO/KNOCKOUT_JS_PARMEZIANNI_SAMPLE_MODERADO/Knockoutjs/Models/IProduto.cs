using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knockoutjs.Models
{
    interface IProduto
    {

        IEnumerable<Produto> GetAll();
        Produto Get(int id);
        Produto Add(Produto item);
        bool Update(Produto item);
        bool Delete(int id);


    }
}
