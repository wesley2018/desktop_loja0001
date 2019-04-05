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
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void timerSplashScreen_Tick(object sender, EventArgs e)
        {
            if (pbCarrega.Value < 100)
            {
                pbCarrega.Value = pbCarrega.Value + 1;
            }
            else
            {
                timerSplashScreen.Stop();
                this.Close();
            }
        }
    }
}
