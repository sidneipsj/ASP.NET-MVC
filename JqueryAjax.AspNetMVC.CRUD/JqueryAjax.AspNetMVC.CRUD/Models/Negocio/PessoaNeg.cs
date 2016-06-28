using JqueryAjax.AspNetMVC.CRUD.Models.Model;
using JqueryAjax.AspNetMVC.CRUD.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JqueryAjax.AspNetMVC.CRUD.Models.Negocio
{
    public class PessoaNeg
    {
        public void Cadastrar(PessoaModel pessoa)
        {
            new PessoaRep().Cadastrar(pessoa);
        }

        public void Atualizar(PessoaModel pessoa)
        {
            new PessoaRep().Atualizar(pessoa);
        }

        public void Deletar(int idPessoa)
        {
            new PessoaRep().Deletar(idPessoa);
        }

        public PessoaModel GetById(int id)
        {
            return new PessoaRep().GetById(id);
        }
        public IEnumerable<PessoaModel> Listar()
        {
            return new PessoaRep().Listar();
        }
    }
}