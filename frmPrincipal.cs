using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop_loja0001
{
    public partial class frmPrincipal : Form
    {
        int pesquisa;
        public static string atualizaGridUsuario = "nao";
        public static string atualizaGridCliente = "nao";
        public static int indexGridUsuario, valorCampoCodigoUsuario,
                          indexGridCliente, valorCampoCodigoCliente;
        public static string CursorOnde;

        public static string UsuarioLogado = "Usuário Padrão";
        public const string URI = "http://okaysistemas.net.br/loja0001";
        //public const string URI = "http://localhost:50453";


        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja encerrar a aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //System.Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                BotaoSelecionado(sender, e); 
                //Registro do combobox
                cbbPesquisarUsuarios.SelectedIndex = 1;
                cbbCondicaoUsuarios.SelectedIndex = 0;
                txtValorUsuarios.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {

        }

        private void btnCompras_Click(object sender, EventArgs e)
        {

        }

        

        public frmPrincipal()
        {
            InitializeComponent();
            //frmLogin frmLogin = new frmLogin();
            //frmLogin.ShowDialog();
        }

        private void BotaoSelecionado(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                TabPage tab = new TabPage();

                switch (btn.Name)
                {
                    case "btnUsuarios":
                        if (tbcMenu.Contains(tbpUsuarios))
                        {
                            tbcMenu.SelectTab(tbpUsuarios);
                        }
                        else if (!tbcMenu.Contains(tbpUsuarios))
                        {
                            tbcMenu.Controls.Add(tbpUsuarios);
                            tbcMenu.SelectTab(tbpUsuarios);
                            TodosUsuarios1();
                        }
                        break;

                    case "btnClientes":
                        if (tbcMenu.Contains(tbpClientes))
                        {
                            tbcMenu.SelectTab(tbpClientes);
                        }
                        else if (!tbcMenu.Contains(tbpClientes))
                        {
                            tbcMenu.Controls.Add(tbpClientes);
                            tbcMenu.SelectTab(tbpClientes);
                            TodosClientes();

                        }
                        break;

                    case "btnProdutos":
                        if (tbcMenu.Contains(tbpProdutos))
                        {
                            tbcMenu.SelectTab(tbpProdutos);
                        }
                        else if (!tbcMenu.Contains(tbpProdutos))
                        {
                            tbcMenu.Controls.Add(tbpProdutos);
                            tbcMenu.SelectTab(tbpProdutos);
                            //TodosProdutos();

                        }
                        break;

                    case "btnCompras":
                        if (tbcMenu.Contains(tbpCompras))
                        {
                            tbcMenu.SelectTab(tbpCompras);
                        }
                        else if (!tbcMenu.Contains(tbpCompras))
                        {
                            tbcMenu.Controls.Add(tbpCompras);
                            tbcMenu.SelectTab(tbpCompras);
                        }
                        break;

                    case "btnVendas":
                        if (tbcMenu.Contains(tbpVendas))
                        {
                            tbcMenu.SelectTab(tbpVendas);
                        }
                        else if (!tbcMenu.Contains(tbpVendas))
                        {
                            tbcMenu.Controls.Add(tbpVendas);
                            tbcMenu.SelectTab(tbpVendas);
                        }
                        break;

                    case "btnFinanceiro":
                        if (tbcMenu.Contains(tbpFinanceiro))
                        {
                            tbcMenu.SelectTab(tbpFinanceiro);
                        }
                        else if (!tbcMenu.Contains(tbpFinanceiro))
                        {
                            tbcMenu.Controls.Add(tbpFinanceiro);
                            tbcMenu.SelectTab(tbpFinanceiro);
                        }
                        break;

                    case "btnLembretes":
                        if (tbcMenu.Contains(tbpLembretes))
                        {
                            tbcMenu.SelectTab(tbpLembretes);
                        }
                        else if (!tbcMenu.Contains(tbpLembretes))
                        {
                            tbcMenu.Controls.Add(tbpLembretes);
                            tbcMenu.SelectTab(tbpLembretes);
                        }
                        break;


                    default:
                        MessageBox.Show("Default");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }
}
