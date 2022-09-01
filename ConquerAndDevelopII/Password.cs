using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConquerAndDevelopII
{
    public partial class Password : Form
    {
        public  Password()
        {
            InitializeComponent();
           
        }
        public static string password = "";
        private void JoinButton_Click(object sender, EventArgs e)
        {
            MainForm.password = PasswordBox.Text;
            this.Close();

        }
    }
}
