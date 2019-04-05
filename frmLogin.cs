using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop_loja0001
{
    public partial class frmLogin : Form
    {
        string vRetorno;

        public frmLogin()
        {
            InitializeComponent();
            frmSplashScreen frmSplashScreen = new frmSplashScreen();
            frmSplashScreen.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            try
            {
                DesabilitaCampos();
                if ((txtUsuario.Text.Trim().Length == 0) || (txtSenha.Text.Trim().Length == 0))
                {
                    if ((txtUsuario.Text.Trim().Length == 0) && (txtSenha.Text.Trim().Length == 0))
                    {
                        HabilitaCampos();
                        MessageBox.Show("Os campos Usuário e Senha são obrigatórios!");
                        txtUsuario.Focus();
                    }
                    else
                    if (txtUsuario.Text.Trim().Length == 0)
                    {
                        HabilitaCampos();
                        MessageBox.Show("O campo Usuário é obrigatório!");                        
                        txtUsuario.Focus();
                    }
                    else
                    if (txtSenha.Text.Trim().Length == 0)
                    {
                        HabilitaCampos();
                        MessageBox.Show("O campo Senha é obrigatório!");                        
                        txtSenha.Focus();
                    }
                }
                else
                {
                    ValidaLogin(txtUsuario.Text, txtSenha.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
                HabilitaCampos();
            }
        }

        private void HabilitaCampos()
        {
            imgCarregamentoLoginUsuario.Visible = false;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            btnAcessar.Enabled = true;
            btnSair.Enabled = true;
        }
        private void DesabilitaCampos()
        {
            imgCarregamentoLoginUsuario.Visible = true;
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
            btnAcessar.Enabled = false;
            btnSair.Enabled = false;
        }

        private async void ValidaLogin(string usuario, string senha)
        {
            try
            {
                string validaLoginURI =
                    frmPrincipal.URI
                    + "/api/usuario/?variavel=existeUsuarioSenha"
                    + "&usuario=" + usuario
                    + "&senha=" + senha;

                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(validaLoginURI);
                    if (response.IsSuccessStatusCode)
                    {
                        var UsuarioJsonString = await response.Content.ReadAsStringAsync();
                        var retorno = JsonConvert.DeserializeObject<string>(UsuarioJsonString).ToString();

                        vRetorno = retorno.ToString();
                        if (vRetorno == "verdadeiro")
                        {
                            frmPrincipal.UsuarioLogado = usuario;
                            this.Close();
                        }
                        if (vRetorno == "falso")
                        {
                            MessageBox.Show("Usuário e/ou senha inválidos!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falha de conexão : " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }

            imgCarregamentoLoginUsuario.Visible = false;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            btnAcessar.Enabled = true;
            btnSair.Enabled = true;
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAcessar_Click(sender, e);
            }
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            txtUsuario.Text = System.Text.RegularExpressions.Regex.Replace(txtUsuario.Text, @"\s+", "");
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            txtSenha.Text = System.Text.RegularExpressions.Regex.Replace(txtSenha.Text, @"\s+", "");
        }
    }
}
