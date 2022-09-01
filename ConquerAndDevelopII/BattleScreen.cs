using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ConquerAndDevelopII
{
    public partial class BattleScreen : Form
    {
        public BattleScreen(Tile t)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Text = "Battle in " + t.Name;
            tile = t;
           
            Thread th = new Thread(InvalidateThread);
            th.Start();
        }
        public void InvalidateThread()
        {
            while (true)
            {
                this.Invalidate();
                Thread.Sleep(25);
            }
        }
        public Tile tile = null;
        public BattleTile TileSelected = null;
        
        protected override void OnPaint(PaintEventArgs e)
        {            
            Graphics g = e.Graphics;
            Pen p = new Pen(Brushes.Black, 2);
            Pen pgray = new Pen(Brushes.Gray, 3);          
                foreach (BattleTile t in tile.Battle.BattleMap)
                {
                    try
                    {                     
                            switch (t.OwnerID)
                            {
                                case 0:
                                    g.FillPolygon(Brushes.LightGray, t.Shape);
                                    break;
                                case 1:
                                    g.FillPolygon(Brushes.Blue, t.Shape);
                                    break;
                                case 2:
                                    g.FillPolygon(Brushes.Red, t.Shape);
                                    break;
                                case 3:
                                    g.FillPolygon(Brushes.DarkGreen, t.Shape);
                                    break;
                                case 4:
                                    g.FillPolygon(Brushes.Orange, t.Shape);
                                    break;
                            }
                        
                        g.DrawPolygon(p, t.Shape);                                              
                       
                    }
                    catch
                    {
                  
                        continue;

                    }
                }
                if (TileSelected != null)
                {
                    g.FillPolygon(Brushes.Wheat, TileSelected.Shape);
                    g.DrawPolygon(p, TileSelected.Shape);                                                        
                }
            }
           
    }
}
