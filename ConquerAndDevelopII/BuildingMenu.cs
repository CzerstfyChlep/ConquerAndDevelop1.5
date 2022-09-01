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
    public partial class BuildingMenu : Form
    {
        public BuildingMenu()
        {
            InitializeComponent();
            if(MainForm.Clicked != null)
            {
                switch (MainForm.Clicked.BuildingType)
                {
                    case "nothing":
                        CurrentlyBuiltPicture.Image = Properties.Resources.Free;
                        CurrentlyBuiltLabel.Text = "Nothing";
                        BonusesLabel.Text = "Bonuses: \n-Nothing";
                        DestroyButton.Enabled = false;
                        break;
                    case "gold":
                        CurrentlyBuiltPicture.Image = Properties.Resources.gold;
                        CurrentlyBuiltLabel.Text = "Gold";
                        BonusesLabel.Text = "Bonuses: \n-Can build mine on this";
                        DestroyButton.Enabled = false;
                        break;
                    case "fort":
                        CurrentlyBuiltPicture.Image = Properties.Resources.Fort;
                        CurrentlyBuiltLabel.Text = "Fort";
                        BonusesLabel.Text = "Bonuses: \n-Protects nerby provinces\n-Costs 6 gold to maintain";

                        break;
                    case "palace":
                        CurrentlyBuiltPicture.Image = Properties.Resources.NobilityPop;
                        CurrentlyBuiltLabel.Text = "Palace";
                        BonusesLabel.Text = "Bonuses: \n-Every five turns raises development of random province by 1\n-Can be built only once";

                        break;
                    case "university":
                        CurrentlyBuiltPicture.Image = Properties.Resources.ResearchLab;
                        CurrentlyBuiltLabel.Text = "University";
                        BonusesLabel.Text = "Bonuses: \nGives 1 science point per turn\n-Costs 5 gold to maintain";

                        break;
                    case "market":
                        CurrentlyBuiltPicture.Image = Properties.Resources.Market;
                        CurrentlyBuiltLabel.Text = "Market";
                        BonusesLabel.Text = "Bonuses: \n+2 or 3 Gold per turn";

                        break;
                    case "training":
                        CurrentlyBuiltPicture.Image = Properties.Resources.trainingfield;
                        CurrentlyBuiltLabel.Text = "Training Field";
                        BonusesLabel.Text = "Bonuses: \nGives 1 attack in surrounding provinces\n-Costs 4 gold to maintain";
                        break;
                    case "barracks":
                        CurrentlyBuiltPicture.Image = Properties.Resources.barracks;
                        CurrentlyBuiltLabel.Text = "Barracks";
                        BonusesLabel.Text = "Bonuses: \n+1 Soldier Limit\nCosts 6 gold to maintain";

                        break;
                    case "mine":
                        CurrentlyBuiltPicture.Image = Properties.Resources.mine;
                        CurrentlyBuiltLabel.Text = "Mine";
                        BonusesLabel.Text = "Bonuses: \n+3 or 4 gold per turn\nMust be built on gold";

                        break;
                       
                }
                FortToolTip.SetToolTip(FortPicture, "Fort\nCost: 50 gold\nBonuses: \n-Protects nerby provinces\n-Costs 6 gold to maintain");
                MarketToolTip.SetToolTip(MarketPicture, "Market\nCost: 30 gold\nBonuses: \n+2 or 3 Gold per turn");
                PalaceToolTip.SetToolTip(PalacePicture, "Palace\nCost: 50 gold\nBonuses: \n-Every five turns raises development of random province by 1\n-Can be built only once");
                UniversityToolTip.SetToolTip(UniversityPicture, "University\nCost: 40 gold\nBonuses: \nGives 1 science point per turn\n-Costs 5 gold to maintain");
                TrainingToolTip.SetToolTip(TrainingPicture, "Training Field\nCost 45 gold\nBonuses: \nGives 1 attack in surrounding provinces\n-Costs 4 gold to maintain");
                MineToolTip.SetToolTip(MinePicture, "Mine\nCost: 45 gold\nBonuses: \n+3 or 4 gold per turn\nMust be built on gold");
                BarracksToolTip.SetToolTip(BarracksPicture, "Barracks\nCost: 30 gold\nBonuses: \n+1 Soldier Limit\nCosts 6 gold to maintain");
            }
        }
      









        private void CancelButton_Click(object sender, EventArgs e)
        {
            MainForm.whattodo = "cancel";
            this.Close();
        }

        private void DestroyButton_Click(object sender, EventArgs e)
        {
            MainForm.whattodo = "dest";
            this.Close();
        }

        private void FortPicture_Click(object sender, EventArgs e)
        {
            if (MainForm.Clicked.BuildingType == "nothing" || MainForm.Clicked.BuildingType == "gold")
            {
                MainForm.whattodo = "build fort";
                this.Close();
            }
            
        }

        private void MarketPicture_Click(object sender, EventArgs e)
        {
            if (MainForm.Clicked.BuildingType == "nothing" || MainForm.Clicked.BuildingType == "gold")
            {
                MainForm.whattodo = "build market";
                this.Close();
            }
        }

        private void PalacePicture_Click(object sender, EventArgs e)
        {
            if (MainForm.Clicked.BuildingType == "nothing" || MainForm.Clicked.BuildingType == "gold")
            {
                MainForm.whattodo = "build palace";
                this.Close();
            }
        }

        private void UniversityPicture_Click(object sender, EventArgs e)
        {
            if (MainForm.Clicked.BuildingType == "nothing" || MainForm.Clicked.BuildingType == "gold")
            {
                MainForm.whattodo = "build university";
                this.Close();
            }
        }

        private void TrainingPicture_Click(object sender, EventArgs e)
        {
            if (MainForm.Clicked.BuildingType == "nothing" || MainForm.Clicked.BuildingType == "gold")
            {
                MainForm.whattodo = "build training";
                this.Close();
            }
        }

        private void BarracksPicture_Click(object sender, EventArgs e)
        {
            if (MainForm.Clicked.BuildingType == "nothing" || MainForm.Clicked.BuildingType == "gold")
            {
                MainForm.whattodo = "build barracks";
                this.Close();
            }
        }

        private void MinePicture_Click(object sender, EventArgs e)
        {
            if (MainForm.Clicked.BuildingType == "gold")
            {
                MainForm.whattodo = "build mine";
                this.Close();
            }
        }
    }
}
