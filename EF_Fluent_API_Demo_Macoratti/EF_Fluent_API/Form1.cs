using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Fluent_API
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (VendasContexto contexto = new VendasContexto())
            {
                try
                {
                    var Macoratti = new Cliente()
                    {
                        Nome = "Macoratti",
                        Endereco = "Rua Peru, 100",
                        Telefone = "4555-6666",
                        Cidade = "Lins"
                    };

                    var Sidnei = new Cliente()
                    {
                        Nome = "Sidnei",
                        Endereco = "rua 1, 100",
                        Telefone = "3333-333",
                        Cidade = "SJC"
                    };

                    var Marcelly = new Cliente()
                    {
                        Nome = "Macelly",
                        Endereco = "teste",
                        Telefone = "4343-4343",
                        Cidade = "teste"
                    };
                    contexto.Clientes.Add(Sidnei);
                    contexto.Clientes.Add(Macoratti);
                    contexto.Clientes.Add(Marcelly);
                    contexto.SaveChanges();
                    MessageBox.Show("Cliente criado com sucesso.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
