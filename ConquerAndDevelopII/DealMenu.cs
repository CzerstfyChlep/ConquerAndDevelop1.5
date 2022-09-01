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
    public partial class DealMenu : Form
    {
        public DealMenu()
        {
            InitializeComponent();
            
            string[] Names = MainForm.SendDealNames.Split('|');
            foreach(string name in Names)
            {
                CheckBox Ch = new CheckBox();
                Ch.Name = name;
                Ch.Text = name;
                Ch.Checked = false;
                ToMenu.Items.Add(Ch);

            }
            

     
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string recivers = "";
            foreach(CheckBox chb in ToMenu.Items)
            {
                recivers += chb.Text + ".";
            }
            
            try
            {
                if (recivers.Length == 0)
                {
                    MessageBox.Show("You have to set recivers of this deal!", "No recivers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new Exception();
                }
                if(TitleBox.Text.Length < 5)
                {
                    MessageBox.Show("Title of this deal is too short!", "Too short title!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new Exception();
                }
                else
                {
                    string bo = Connection.WriteAndRead($"checkfreename {TitleBox.Text}");
                    if(bo != "free")
                    {
                        MessageBox.Show("This title is already in use!", "Title already in use!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        throw new Exception();
                    }
                }


                recivers.Remove(recivers.Length - 1, 1);
                string rec = Connection.WriteAndRead($"crtdeal {recivers} {OfficialBox.Checked} {ExpiringBox.Checked} {DurationMenu.Value} {SGold.Value} {SGoldPerTurn.Value} {RGold.Value} {RGoldPerTurn.Value} {AdditionalTextBox.Text}");
                if (rec == "dealcreated")
                    this.Close();
                else
                {
                    MessageBox.Show("Error during creation of a deal", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch
            {

            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
