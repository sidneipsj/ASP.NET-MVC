using DAL;
using PlantaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlantaoAPI.Controllers
{
    public class CartaoController : ApiController
    {
        public Cartao Get()
        {
            
            //Instancia objeto do tipo Cartao
            Cartao cartao = new Cartao();
            DataTable dt;
            //Obtem retorno do método BuscarCartaoTitular e preenche datatable dt
            dt = DAL.DALCartao.BuscarCartaoTitular(174244);

            cartao.Nome = dt.Rows[0]["nome"].ToString();
            cartao.Id = 174244;
            cartao.CodCartao = dt.Rows[0]["codcartimp"].ToString();
            cartao.Senha = "1111";
            return cartao;
 
        }
    }
}
