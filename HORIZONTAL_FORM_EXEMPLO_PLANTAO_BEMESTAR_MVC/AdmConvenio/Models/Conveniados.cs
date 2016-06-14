using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmConvenio.Models
{
    public class Conveniados
    {
        public enum Estados
        {
            AC, AL, AP, AM,
            BA, CE, DF, ES,
            GO, MA, MT, MS,
            MG, PR, PB, PA,
            PE, PI, RJ, RN,
            RS, RO, RR, SC,
            SE, SP, TO
        }

        public enum Dependentes
        {
            Filho,Conjuge
        }

        public string Complemento { get; private set; }

        public string Email { get; private set; }

        public int ConvId
        {
            get { return ConvId; }
            set { ConvId = value; }
        }

        public char CartaoBemEstar
        {
            get { return CartaoBemEstar; }
            set { CartaoBemEstar = value; }
        }

        public int EmpresId
        {
            get { return EmpresId; }
            set { EmpresId = value; }
        }

        public int GrupoConvEmp
        {
            get { return grupo_conv_emp; }
            set { grupo_conv_emp = value; }
        }

        public float Chapa
        {
            get { return chapa; }
            set { chapa = value; }
        }

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public string Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        public int Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }

        public double LimiteMes
        {
            get { return limite_mes; }
            set { limite_mes = value; }
        }

        public char Liberado
        {
            get { return liberado; }
            set { liberado = value; }
        }

        public char Fidelidade
        {
            get { return fidelidade; }
            set { fidelidade = value; }
        }

        public char Apagado
        {
            get { return apagado; }
            set { apagado = value; }
        }

        public DateTime DtNascimento
        {
            get { return dt_nascimento; }
            set { dt_nascimento = value; }
        }

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public string Setor
        {
            get { return setor; }
            set { setor = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        public double LimiteTotal
        {
            get { return limite_total; }
            set { limite_total = value; }
        }

        public double LimiteProxFechamento
        {
            get { return limite_prox_fechamento; }
            set { limite_prox_fechamento = value; }
        }

        public string Agencia
        {
            get { return agencia; }
            set { agencia = value; }
        }

        public string Contacorrente
        {
            get { return contacorrente; }
            set { contacorrente = value; }
        }

        public string DigitoConta
        {
            get { return digito_conta; }
            set { digito_conta = value; }
        }

        public string Tipopagamento
        {
            get { return tipopagamento; }
            set { tipopagamento = value; }
        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public string Obs
        {
            get { return obs; }
            set { obs = value; }
        }

        private int convId;
        private char cartaoBemEstar;
        private int empresId;
        private int grupo_conv_emp;
        private float chapa;
        private string senha;
        private string titular;
        private int contrato;
        double limite_mes;
        private char liberado;
        private char fidelidade;
        private char apagado;
        private DateTime dt_nascimento;
        private string cargo;
        private string setor;
        private string cpf;
        private string rg;
        private double limite_total;
        private double limite_prox_fechamento;
        private string agencia;
        private string contacorrente;
        private string digito_conta;
        private string tipopagamento;
        private string endereco;
        private int numero;
        private string bairro;
        private string cidade;
        private string estado;
        private string cep;
        private string telefone;
        private string celular;
        private string obs;


    }
}