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
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Sockets;
using System.IO;


//To do:
//-Add tile upgrades
//-Add all the food mechanics
//-Add more deep armies

namespace ConquerAndDevelopII
{
    public partial class MainForm : Form
    {
        //next hex
        //x + 30
        //y + 17

        //hex below
        //y + 34

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += Closing;
            this.DoubleBuffered = true;
            this.MouseClick += FormClick;
            this.MouseDoubleClick += DoubleClick;
            this.MouseEnter += MouseReenter;
            LobbyThread = new Thread(LobbyUpdater);
            MainMenuThread = new Thread(MainMenuUpdater);
            PainterThread = new Thread(InvalidateThread);
            GameThread = new Thread(GameGetInfo);
            this.KeyUp += ButtonPressed;
            //Tile t = new Tile(0, 0, "XD");
            /*t.Battle = new Battle();
            for (int a = 0; a < 15; a++)
            {
                for(int b = 0; b < 15; b++)
                {
                    t.Battle.BattleMap[a, b] = new BattleTile(a,b);
                    t.Battle.BattleMap[a, b].OwnerID = 0;
                }
            }
            t.Battle.Participants[0] = PlayerID;
            BattleScreen bs = new BattleScreen(t);
            bs.Show();
            */
 
        }

       

        public bool[,] Map = new bool[15,15];
        public static Thread LobbyThread;
        public static Thread MainMenuThread;
        public static Thread GameThread;
        public static Thread PainterThread;
        public static bool DevMapmode = false;
       

        public int Gold = 0;


        public int RealIncome = 0;
      
        
        public static string IPAddres = "";
        public static int Port = 2055;
        public Soldier SoldierSelected = null;
        public Tile SoldierHome;
        public static Tile Clicked;
        public static List<Tile> Tiles = new List<Tile>();
        public string LoggedAs;
        public int PlayerID = 0;
        Thread TInv;
        Thread TurnMaker;
       
        public void GameGetInfo()
        {
//try
           // {
                while (true)
                {
                    Thread.Sleep(40);                    
                    string rec = Connection.WriteAndRead("getgameinfo");

                    string[] splittt = rec.Split('|');
                    string[] StatsSplit = splittt[0].Split(' ');
                    Gold = int.Parse(StatsSplit[0]);
                    RealIncome = int.Parse(StatsSplit[1]);
                                      


                    string[] split = splittt[1].Split(' ');
                    foreach (string s in split)
                    {
                        
                        if (s != " " && s != "")
                        {
                            
                            string[] args = s.Split('.');
                            int posx = int.Parse(args[0]);
                            int posy = int.Parse(args[1]);

                            foreach (Tile t in Tiles)
                            {
                                if (t.PosX == posx && t.PosY == posy)
                                {
                                    t.Owner = int.Parse(args[2]);
                                    t.Capital = int.Parse(args[3]);
                                    t.Development = int.Parse(args[4]);
                                    t.BuildingType = args[5];

                                if (args.Count() > 6)
                                    {

                                        Soldier sold = new Soldier();
                                        t.Soldier = sold;
                                        sold.HP = int.Parse(args[6]);
                                        sold.MaxHP = int.Parse(args[7]);
                                        sold.Moves = int.Parse(args[8]);
                                        sold.MaxMoves = int.Parse(args[9]);
                                        sold.Exp = int.Parse(args[10]);
                                        if (SoldierHome == t)
                                            SoldierSelected = sold;
                                    }
                                    else
                                        t.Soldier = null;
                                }
                            }
                        }                
                    }
                /*string recBT = Connection.WriteAndRead("chkbat");
                if (recBT != "")
                {
                    string[] BattSplit = recBT.Split(' ');
                    foreach (string s in BattSplit)
                    {
                        try
                        {
                            string[] BattleDoubleSplit = s.Split('|');
                            int posx = int.Parse(BattleDoubleSplit[0].Split('.')[0]);
                            int posy = int.Parse(BattleDoubleSplit[0].Split('.')[1]);

                            foreach (Tile t in Tiles)
                            {
                                if (t.PosX == posx && t.PosY == posy)
                                {
                                    if (t.Battle == null)
                                    {
                                        t.Battle = new Battle();
                                        string GetBattle = Connection.WriteAndRead($"getbat {posx}.{posy}");
                                        int idn = 0;
                                        foreach (string id in GetBattle.Split('|')[0].Split(':'))
                                        {
                                            t.Battle.Participants[idn] = int.Parse(id);
                                            idn++;
                                        }
                                        string[] BM = GetBattle.Split('|')[1].Split(' ');
                                        for (int x = 0; x < 15; x++)
                                        {
                                            for (int y = 0; y < 15; y++)
                                            {
                                                t.Battle.BattleMap[x, y].TerrainID = int.Parse(BM[x * 15 + y]);
                                            }
                                        }
                                        BattleScreen BT = new BattleScreen(t);
                                        BT.Show();

                                    }
                                    string[] BattleTripSplit = BattleDoubleSplit[1].Split(':');
                                    foreach (string omghowmuchsplits in BattleTripSplit)
                                    {
                                        string[] Args = omghowmuchsplits.Split('.');
                                        if (Args.Any())
                                        {

                                        }
                                    }
                                    break;

                                }
                            }


                        }
                        catch
                        {

                        }
                    }
                }
                */
                








               
                GoldLabel.Text = $"Gold: {Gold}";
                string rl = "";
                if(RealIncome > 0)
                {
                    rl += "+";
                }
                rl += RealIncome + "";
                IncomeLabel.Text =  "Inc.:" + rl;
                if (Clicked != null)
                {
                    DevelopmentLebel.Text = "Development: " + Clicked.Development;
                    switch (Clicked.BuildingType)
                    {
                        case "nothing":
                            BuildingSlot1.Image = Properties.Resources.Free;
                            break;
                        case "fort":
                            BuildingSlot1.Image = Properties.Resources.Fort;
                            break;
                        case "palace":
                            BuildingSlot1.Image = Properties.Resources.NobilityPop;
                            break;
                        case "university":
                            BuildingSlot1.Image = Properties.Resources.ResearchLab;
                            break;
                        case "market":
                            BuildingSlot1.Image = Properties.Resources.Market;
                            break;
                        case "training":
                            BuildingSlot1.Image = Properties.Resources.trainingfield;
                            break;
                        case "barracks":
                            BuildingSlot1.Image = Properties.Resources.barracks;
                            break;
                        case "mine":
                            BuildingSlot1.Image = Properties.Resources.mine;
                            break;
                        case "gold":
                            BuildingSlot1.Image = Properties.Resources.gold;
                            break;
                    }

                }
            }
           // }
            //catch (Exception e)
           // {
           //     ShowError("GameGetInfo: " + e.Message + "\n" + e.Source, "Error!");
           // }
           

        }
       
        public void Closing(object sender, EventArgs e)
        {
            try
            {
                if (Connection.Connected)
                {
                    TInv.Abort();
                    TurnMaker.Abort();
                    if (MainMenuThread.ThreadState == ThreadState.Running)
                        MainMenuThread.Abort();
                    if (LobbyThread.ThreadState == ThreadState.Running)
                        LobbyThread.Abort();
                    Connection.Disconnect();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch
            {
                Environment.Exit(0);
            }
    
        }
       
        public void InvalidateThread()
        {
            while (true)
            {
                this.Invalidate();
                Thread.Sleep(25);
            }
        }
        
       
        public Dictionary<Tile, int> Bordering(Tile T, int Distance)
        {
            Dictionary<Tile, int> Bordering = new Dictionary<Tile, int>();
            Bordering.Add(T, 0);
            int count = 1;
            try
            {
                for (int a = 0; a < Distance; a++)
                {
                    Dictionary<Tile, int> AddToBoredering = new Dictionary<Tile, int>();
                    foreach (Tile tile in Bordering.Keys)
                    {
                        if (tile.Owner == PlayerID)
                        {

                            foreach (Tile t in Tiles)
                            {
                                if (t.PosX % 2 == 1 && !AddToBoredering.Keys.Contains(t) && !Bordering.Keys.Contains(t))
                                {
                                    if (t.PosX + 1 == tile.PosX && t.PosY == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                    if (t.PosX == tile.PosX && t.PosY + 1 == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                    if (t.PosX - 1 == tile.PosX && t.PosY == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                    if (t.PosX - 1 == tile.PosX && t.PosY - 1 == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                    if (t.PosX + 1 == tile.PosX && t.PosY - 1 == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                    if (t.PosX == tile.PosX && t.PosY - 1 == tile.PosY)
                                        AddToBoredering.Add(t, a);
                                }
                                else if (!Bordering.Keys.Contains(t) && !AddToBoredering.Keys.Contains(t) && t.PosX % 2 == 0)
                                {
                                    if (t.PosX == tile.PosX && t.PosY + 1 == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                    if (t.PosX - 1 == tile.PosX && t.PosY == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                    if (t.PosX + 1 == tile.PosX && t.PosY == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                    if (t.PosX + 1 == tile.PosX && t.PosY + 1 == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                    if (t.PosX - 1 == tile.PosX && t.PosY + 1 == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                    if (t.PosX == tile.PosX && t.PosY - 1 == tile.PosY)
                                        AddToBoredering.Add(t, a);

                                }

                            }
                        }
                    }

                    

                    foreach (Tile t in AddToBoredering.Keys)
                    {
                        if (!Bordering.Keys.Contains(t))
                        {
                            Bordering.Add(t, count);
                        }
                    }
                    count++;
                }
                return Bordering;
            }
            catch
            {
                ShowError("There is a problem!", "Error");
                return null;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Brushes.Black, 2);
            Pen pgray = new Pen(Brushes.Gray, 3);
            if (SoldierSelected == null)
            {
                try
                {
                    foreach (Tile t in Tiles)
                    {

                        if (!DevMapmode)
                        {
                            switch (t.Owner)
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
                        }
                        else
                        {
                            switch (t.Development)
                            {
                                case 1:
                                    g.FillPolygon(Brushes.DarkRed, t.Shape);
                                    break;
                                case 2:
                                    g.FillPolygon(Brushes.Orange, t.Shape);
                                    break;
                                case 3:
                                    g.FillPolygon(Brushes.Yellow, t.Shape);
                                    break;
                                case 4:
                                    g.FillPolygon(Brushes.Green, t.Shape);
                                    break;
                                case 5:
                                    g.FillPolygon(Brushes.LightBlue, t.Shape);
                                    break;
                                default:
                                    g.FillPolygon(Brushes.Violet, t.Shape);
                                    break;
                            }
                        }
                        g.DrawPolygon(p, t.Shape);

                        if (t.BuildingType == "fort")
                            g.DrawPolygon(pgray, t.FortShape);

                        switch (t.BuildingType)
                        {
                            case "fort":
                                g.DrawPolygon(pgray, t.FortShape);
                                break;
                            case "gold":
                                g.DrawImage(Properties.Resources.goldProvince, new RectangleF(new PointF(t.Shape[4].X - 8, t.Shape[4].Y - 5), new Size(37, 37)));
                                break;
                            case "market":
                                g.DrawImage(Properties.Resources.marketProvince, new RectangleF(new PointF(t.Shape[4].X - 9, t.Shape[4].Y - 1), new Size(37, 37)));
                                break;
                            case "palace":
                                g.DrawImage(Properties.Resources.PalaceProvince, new RectangleF(new PointF(t.Shape[4].X - 5, t.Shape[4].Y + 3), new Size(30, 30)));
                                break;
                            case "university":
                                g.DrawImage(Properties.Resources.UniversityProvince, new RectangleF(new PointF(t.Shape[4].X - 5, t.Shape[4].Y + 3), new Size(30, 30)));
                                break;
                            case "training":
                                g.DrawImage(Properties.Resources.TrainingProvince, new RectangleF(new PointF(t.Shape[4].X - 5, t.Shape[4].Y + 3), new Size(30, 30)));
                                break;
                            case "mine":
                                g.DrawImage(Properties.Resources.mineProvince, new RectangleF(new PointF(t.Shape[4].X - 6, t.Shape[4].Y - 2), new Size(35, 35)));
                                break;
                            case "barracks":
                                g.DrawImage(Properties.Resources.barracksProvince, new RectangleF(new PointF(t.Shape[4].X - 8, t.Shape[4].Y - 2), new Size(35, 35)));
                                break;

                        }

                        if (t.Soldier != null)
                        {
                            g.DrawImage(Properties.Resources.soldier, new RectangleF(new PointF(t.Shape[4].X + 1, t.Shape[4].Y + 5), new Size(20, 20)));
                            string f = "";
                            if (t.Soldier.Exp >= 10)
                                f += "*";
                            if (t.Soldier.Exp >= 20)
                                f += "*";
                            if (t.Soldier.Exp == 30)
                                f += "*";
                            if (t.Soldier.Moves > 0 && t.Soldier != null)
                            {

                                g.DrawString(t.Soldier.Moves + " " + f, new Font("Consolas", 9), Brushes.Black, new PointF(t.Shape[4].X + 15, t.Shape[4].Y + 7));
                            }
                            else
                            {
                                g.DrawString(f, new Font("Consolas", 9), Brushes.Black, new PointF(t.Shape[4].X + 15, t.Shape[4].Y + 7));

                            }
                            g.FillRectangle(Brushes.Red, new RectangleF(new PointF(t.Shape[4].X, t.Shape[4].Y + 27), new Size(20, 4)));
                            g.FillRectangle(Brushes.Green, new RectangleF(new PointF(t.Shape[4].X, t.Shape[4].Y + 27), new Size(20 / t.Soldier.MaxHP * t.Soldier.HP, 4)));
                            g.DrawRectangle(Pens.Black, new Rectangle(new Point((int)t.Shape[4].X, (int)t.Shape[4].Y + 27), new Size(20, 4)));
                        }
                    }
                }
                catch
                {

                }
            
                if (Clicked != null)
                {
                    g.FillPolygon(Brushes.Wheat, Clicked.Shape);
                    g.DrawPolygon(p, Clicked.Shape);
                   
                    if (Clicked.BuildingType == "fort")
                        g.DrawPolygon(pgray, Clicked.FortShape);

                    switch (Clicked.BuildingType)
                    {
                        case "fort":
                            g.DrawPolygon(pgray, Clicked.FortShape);
                            break;
                        case "gold":
                            g.DrawImage(Properties.Resources.goldProvince, new RectangleF(new PointF(Clicked.Shape[4].X - 8, Clicked.Shape[4].Y - 5), new Size(37, 37)));
                            break;
                        case "market":
                            g.DrawImage(Properties.Resources.marketProvince, new RectangleF(new PointF(Clicked.Shape[4].X - 9, Clicked.Shape[4].Y - 1), new Size(37, 37)));
                            break;
                        case "palace":
                            g.DrawImage(Properties.Resources.PalaceProvince, new RectangleF(new PointF(Clicked.Shape[4].X - 5, Clicked.Shape[4].Y + 3), new Size(30, 30)));
                            break;
                        case "university":
                            g.DrawImage(Properties.Resources.UniversityProvince, new RectangleF(new PointF(Clicked.Shape[4].X - 5, Clicked.Shape[4].Y + 3), new Size(30, 30)));
                            break;
                        case "training":
                            g.DrawImage(Properties.Resources.TrainingProvince, new RectangleF(new PointF(Clicked.Shape[4].X - 5, Clicked.Shape[4].Y + 3), new Size(30, 30)));
                            break;
                        case "mine":
                            g.DrawImage(Properties.Resources.mineProvince, new RectangleF(new PointF(Clicked.Shape[4].X - 6, Clicked.Shape[4].Y - 2), new Size(35, 35)));
                            break;
                        case "barracks":
                            g.DrawImage(Properties.Resources.barracksProvince, new RectangleF(new PointF(Clicked.Shape[4].X - 8, Clicked.Shape[4].Y - 2), new Size(35, 35)));
                            break;

                    }
                    if (Clicked.Soldier != null)
                    {
                        g.DrawImage(Properties.Resources.soldier, new RectangleF(new PointF(Clicked.Shape[4].X + 1, Clicked.Shape[4].Y + 5), new Size(20, 20)));
                        string f = "";
                        if (Clicked.Soldier.Exp >= 10)
                            f += "*";
                        if (Clicked.Soldier.Exp >= 20)
                            f += "*";
                        if (Clicked.Soldier.Exp == 30)
                            f += "*";
                        if (Clicked.Soldier.Moves > 0 && Clicked.Soldier != null)
                        {

                            g.DrawString(Clicked.Soldier.Moves + " " + f, new Font("Consolas", 9), Brushes.Black, new PointF(Clicked.Shape[4].X + 15, Clicked.Shape[4].Y + 7));
                        }
                        else
                        {
                            g.DrawString(f, new Font("Consolas", 9), Brushes.Black, new PointF(Clicked.Shape[4].X + 15, Clicked.Shape[4].Y + 7));

                        }
                        g.FillRectangle(Brushes.Red, new RectangleF(new PointF(Clicked.Shape[4].X, Clicked.Shape[4].Y + 27), new Size(20, 4)));
                        g.FillRectangle(Brushes.Green, new RectangleF(new PointF(Clicked.Shape[4].X, Clicked.Shape[4].Y + 27), new Size(20 / Clicked.Soldier.MaxHP * Clicked.Soldier.HP, 4)));
                        g.DrawRectangle(Pens.Black, new Rectangle(new Point((int)Clicked.Shape[4].X, (int)Clicked.Shape[4].Y + 27), new Size(20, 4)));
                    }
                }
            }
            else
            {
                foreach (Tile t in Tiles)
                {
                    try
                    {
                        switch (t.Owner)
                        {
                            case 0:
                                g.FillPolygon(Brushes.DarkSlateGray, t.Shape);
                                break;
                            case 1:
                                g.FillPolygon(Brushes.DarkBlue, t.Shape);
                                break;
                            case 2:
                                g.FillPolygon(Brushes.DarkRed, t.Shape);
                                break;
                            case 3:
                                g.FillPolygon(Brushes.DarkOliveGreen, t.Shape);
                                break;
                            case 4:
                                g.FillPolygon(Brushes.DarkOrange, t.Shape);
                                break;

                        }
                        
                        g.DrawPolygon(p, t.Shape);

                        if (t.BuildingType == "fort")
                            g.DrawPolygon(pgray, t.FortShape);
                        switch (t.BuildingType)
                        {
                            case "fort":
                                g.DrawPolygon(pgray, t.FortShape);
                                break;
                            case "gold":
                                g.DrawImage(Properties.Resources.goldProvince, new RectangleF(new PointF(t.Shape[4].X - 8, t.Shape[4].Y - 5), new Size(37, 37)));
                                break;
                            case "market":
                                g.DrawImage(Properties.Resources.marketProvince, new RectangleF(new PointF(t.Shape[4].X - 9, t.Shape[4].Y - 1), new Size(37, 37)));
                                break;
                            case "palace":
                                g.DrawImage(Properties.Resources.PalaceProvince, new RectangleF(new PointF(t.Shape[4].X - 5, t.Shape[4].Y + 3), new Size(30, 30)));
                                break;
                            case "university":
                                g.DrawImage(Properties.Resources.UniversityProvince, new RectangleF(new PointF(t.Shape[4].X - 5, t.Shape[4].Y + 3), new Size(30, 30)));
                                break;
                            case "training":
                                g.DrawImage(Properties.Resources.TrainingProvince, new RectangleF(new PointF(t.Shape[4].X - 5, t.Shape[4].Y + 3), new Size(30, 30)));
                                break;
                            case "mine":
                                g.DrawImage(Properties.Resources.mineProvince, new RectangleF(new PointF(t.Shape[4].X - 6, t.Shape[4].Y - 2), new Size(35, 35)));
                                break;
                            case "barracks":
                                g.DrawImage(Properties.Resources.barracksProvince, new RectangleF(new PointF(t.Shape[4].X - 8, t.Shape[4].Y - 2), new Size(35, 35)));
                                break;

                        }
                        if (t.Soldier != null && t.Soldier != null)
                        {
                            g.DrawImage(Properties.Resources.soldier, new RectangleF(new PointF(t.Shape[4].X + 1, t.Shape[4].Y + 5), new Size(20, 20)));
                            string f = "";
                            if (t.Soldier.Exp >= 10)
                                f += "*";
                            if (t.Soldier.Exp >= 20)
                                f += "*";
                            if (t.Soldier.Exp == 30)
                                f += "*";
                            if (t.Soldier.Moves > 0 && t.Soldier != null)
                            {

                                g.DrawString(t.Soldier.Moves + " " + f, new Font("Consolas", 9), Brushes.Black, new PointF(t.Shape[4].X + 15, t.Shape[4].Y + 7));
                            }
                            else
                            {
                                g.DrawString(f, new Font("Consolas", 9), Brushes.Black, new PointF(t.Shape[4].X + 15, t.Shape[4].Y + 7));

                            }
                            g.FillRectangle(Brushes.Red, new RectangleF(new PointF(t.Shape[4].X, t.Shape[4].Y + 27), new Size(20, 4)));
                            g.FillRectangle(Brushes.Green, new RectangleF(new PointF(t.Shape[4].X, t.Shape[4].Y + 27), new Size(20 / t.Soldier.MaxHP * t.Soldier.HP, 4)));
                            g.DrawRectangle(Pens.Black, new Rectangle(new Point((int)t.Shape[4].X, (int)t.Shape[4].Y + 27), new Size(20, 4)));
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                foreach (Tile t in Bordering(SoldierHome, SoldierSelected.Moves).Keys)
                {
                    try {
                        if (t.Soldier == null || (t.Soldier != null && Bordering(SoldierHome, 1).Keys.Contains(t)))
                        {
                            if (!DevMapmode)
                            {
                                switch (t.Owner)
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
                                        g.FillPolygon(Brushes.DarkOrange, t.Shape);
                                        break;
                                }
                            }
                            else
                            {
                                switch (t.Development)
                                {
                                    case 1:
                                        g.FillPolygon(Brushes.DarkRed, t.Shape);
                                        break;
                                    case 2:
                                        g.FillPolygon(Brushes.Orange, t.Shape);
                                        break;
                                    case 3:
                                        g.FillPolygon(Brushes.Yellow, t.Shape);
                                        break;
                                    case 4:
                                        g.FillPolygon(Brushes.Green, t.Shape);
                                        break;
                                    case 5:
                                        g.FillPolygon(Brushes.LightBlue, t.Shape);
                                        break;
                                    default:
                                        g.FillPolygon(Brushes.Violet, t.Shape);
                                        break;
                                }
                            }

                            g.DrawPolygon(p, t.Shape);

                            if (t.BuildingType == "fort")
                                g.DrawPolygon(pgray, t.FortShape);

                            switch (t.BuildingType)
                            {
                                case "fort":
                                    g.DrawPolygon(pgray, t.FortShape);
                                    break;
                                case "gold":
                                    g.DrawImage(Properties.Resources.goldProvince, new RectangleF(new PointF(t.Shape[4].X - 8, t.Shape[4].Y - 5), new Size(37, 37)));
                                    break;
                                case "market":
                                    g.DrawImage(Properties.Resources.marketProvince, new RectangleF(new PointF(t.Shape[4].X - 9, t.Shape[4].Y - 1), new Size(37, 37)));
                                    break;
                                case "palace":
                                    g.DrawImage(Properties.Resources.PalaceProvince, new RectangleF(new PointF(t.Shape[4].X - 5, t.Shape[4].Y + 3), new Size(30, 30)));
                                    break;
                                case "university":
                                    g.DrawImage(Properties.Resources.UniversityProvince, new RectangleF(new PointF(t.Shape[4].X - 5, t.Shape[4].Y + 3), new Size(30, 30)));
                                    break;
                                case "training":
                                    g.DrawImage(Properties.Resources.TrainingProvince, new RectangleF(new PointF(t.Shape[4].X - 5, t.Shape[4].Y + 3), new Size(30, 30)));
                                    break;
                                case "mine":
                                    g.DrawImage(Properties.Resources.mineProvince, new RectangleF(new PointF(t.Shape[4].X - 6, t.Shape[4].Y - 2), new Size(35, 35)));
                                    break;
                                case "barracks":
                                    g.DrawImage(Properties.Resources.barracksProvince, new RectangleF(new PointF(t.Shape[4].X - 8, t.Shape[4].Y - 2), new Size(35, 35)));
                                    break;

                            }
                            if (t.Soldier != null && t.Soldier != null)
                            {
                                g.DrawImage(Properties.Resources.soldier, new RectangleF(new PointF(t.Shape[4].X + 1, t.Shape[4].Y + 5), new Size(20, 20)));
                                string f = "";
                                if (t.Soldier.Exp >= 10)
                                    f += "*";
                                if (t.Soldier.Exp >= 20)
                                    f += "*";
                                if (t.Soldier.Exp == 30)
                                    f += "*";
                                if (t.Soldier.Moves > 0 && t.Soldier != null)
                                {

                                    g.DrawString(t.Soldier.Moves + " " + f, new Font("Consolas", 9), Brushes.Black, new PointF(t.Shape[4].X + 15, t.Shape[4].Y + 7));
                                }
                                else
                                {
                                    g.DrawString(f, new Font("Consolas", 9), Brushes.Black, new PointF(t.Shape[4].X + 15, t.Shape[4].Y + 7));

                                }
                                g.FillRectangle(Brushes.Red, new RectangleF(new PointF(t.Shape[4].X, t.Shape[4].Y + 27), new Size(20, 4)));
                                g.FillRectangle(Brushes.Green, new RectangleF(new PointF(t.Shape[4].X, t.Shape[4].Y + 27), new Size(20 / t.Soldier.MaxHP * t.Soldier.HP, 4)));
                                g.DrawRectangle(Pens.Black, new Rectangle(new Point((int)t.Shape[4].X, (int)t.Shape[4].Y + 27), new Size(20, 4)));
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }    
               
            }
            foreach(Tile t in Tiles)
            {
                try
                {
                    if (t.Capital == 1)
                        g.DrawPolygon(new Pen(Brushes.Gold, 3), t.Shape);
                }
                catch
                {
                    continue;
                }
            }
            if(Clicked != null)
            {
               
            }
        
    }
        public void MouseReenter(object sender, EventArgs e)
        {
            if (SoldierSelected != null)
            {
                Cursor c = new Cursor(Properties.Resources.soldier1.Handle);
                this.Cursor = c;
            }
            
        }
        public void DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X < 300)
            {
                
            }
        }
        public void ButtonPressed(object sender, KeyEventArgs e)
        {
            if (GameThread.ThreadState == ThreadState.Running)
            {
                if (e.KeyCode == Keys.C || e.KeyCode == Keys.S)
                {
                    
                    if (Clicked != null)
                    {
                        if (Clicked.Soldier == null)
                        {
                            if (Gold >= 20 && Clicked.Owner == PlayerID)
                            {
                                Connection.Write("sold " + Clicked.PosX + "." + Clicked.PosY);
                            }
                        }
                        

                    }
                }
                else if(e.KeyCode == Keys.D)
                {
                    if (Clicked != null)
                    {
                        if (Clicked.Soldier != null && Clicked.Owner == PlayerID)
                        {
                            Connection.Write("sold " + Clicked.PosX + "." + Clicked.PosY);
                        }
                    }
                }
                if (e.KeyCode == Keys.M)
                {

                    DevMapmode = !DevMapmode;
                }

            }
        }
        public void FormClick(object sender, MouseEventArgs e)
        {
            if (SoldierSelected == null)
            {
                bool found = false;
                if (e.Button == MouseButtons.Left)
                {
                    if (e.Location.X < 450)
                    {
                        foreach (Tile t in Tiles)
                        {
                            if (IsInPolygon(e.Location, t.Shape))
                            {
                                if (Clicked != t)
                                {
                                    Clicked = t;
                                    found = true;
                                    ProvinceBox.Text = Clicked.Name;
                                    if (Clicked.Owner == PlayerID)
                                        HireDisbandSoldierButton.Enabled = true;
                                   

                                    if (t.Soldier != null)
                                    {
                                        MaxSlotsLabel.Text = t.Soldier.Moves + "";
                                    }
                                    
                                }
                                else
                                {
                                    Clicked = null;
                                    HireDisbandSoldierButton.Enabled = false;
                                    continue;

                                }

                            }

                           
                           

                        }
                        if (!found)
                            Clicked = null;
                    }
                    else
                    {
                        Clicked = null;
                    }

                        
                }
                else if(e.Button == MouseButtons.Right)
                {
                    Clicked = null;
                    DevMapmode = false;
                    foreach (Tile t in Tiles)
                    {
                        if (IsInPolygon(e.Location, t.Shape) && t.Soldier != null && (t.Owner == PlayerID))
                        {
                            if (t.Soldier.Moves > 0)
                            {
                                Cursor c = new Cursor(Properties.Resources.soldier1.Handle);
                                SoldierSelected = t.Soldier;
                                this.Cursor = c;
                                SoldierHome = t;
                            }

                        }

                    }
                }
            }
            else
            {
                if (e.Location.X < 450)
                {
                    foreach (Tile t in Tiles)
                    {
                        if (IsInPolygon(e.Location, t.Shape) && Bordering(SoldierHome, SoldierSelected.Moves).Keys.Contains(t) && t != SoldierHome)
                        {
                            if (t.Soldier == null || (t.Soldier != null && Bordering(SoldierHome, 1).Keys.Contains(t)))
                            {
                                Connection.Write($"mov {SoldierHome.PosX}.{SoldierHome.PosY} {t.PosX}.{t.PosY}");


                                this.Cursor = Cursors.Default;
                                SoldierSelected = null;
                                SoldierHome = null;
                                break;
                            }

                        }
                        else if(IsInPolygon(e.Location, t.Shape) && Bordering(SoldierHome, SoldierSelected.Moves).Keys.Contains(t) && t == SoldierHome)
                        {
                            this.Cursor = Cursors.Default;
                            SoldierSelected = null;
                            SoldierHome = null;
                            break;
                        }
                    }
                }
            }
        }
        public bool IsInPolygon(Point point, PointF[] polygon)
        {
            int polygonLength = polygon.Length, i = 0;
            bool inside = false;
            // x, y for tested point.
            float pointX = point.X, pointY = point.Y;
            // start / end point for the current polygon segment.
            float startX, startY, endX, endY;
            PointF endPoint = polygon[polygonLength - 1];
            endX = endPoint.X;
            endY = endPoint.Y;
            while (i < polygonLength)
            {
                startX = endX; startY = endY;
                endPoint = polygon[i++];
                endX = endPoint.X; endY = endPoint.Y;
                //
                inside ^= (endY > pointY ^ startY > pointY) /* ? pointY inside [startY;endY] segment ? */
                          && /* if so, test if it is under the segment */
                          ((pointX - endX) < (pointY - endY) * (startX - endX) / (startY - endY));
            }
            return inside;
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text.Length > 2 && PasswordBox.Text.Length > 2 && LoginBox.Text != "Login")
            {
                MySqlConnection connection = new MySqlConnection("SERVER=sql.dawidbanasze.nazwa.pl;DATABASE=dawidbanasze_chlep;UID=dawidbanasze_chlep;PASSWORD=Rup33EBjMzTtkRu;");
                connection.Open();
                string msg = $"SELECT Username FROM Users WHERE Username = '{LoginBox.Text}'";
                MySqlCommand cmd = new MySqlCommand(msg, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                List<string> list = new List<string>();
                while (dataReader.Read())
                {
                    list.Add(dataReader["Username"] + "");
                }
                dataReader.Close();
                if (!list.Any())
                {
                    msg = $"INSERT INTO Users (Username, Password, ID) VALUES ('{LoginBox.Text}','{PasswordBox.Text}',NULL)";
                    cmd = new MySqlCommand(msg, connection);
                    cmd.ExecuteNonQuery();
                    LoginBox.Text = "Login";
                    PasswordBox.Text = "Password";
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Ta nazwa jest już zajęta!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void ShowError(string Text, string Title)
        {
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public int LevelPoints = 0;
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text.Length > 2 && PasswordBox.Text.Length > 2)
            {
                MySqlConnection connection = new MySqlConnection("SERVER=sql.dawidbanasze.nazwa.pl;DATABASE=dawidbanasze_chlep;UID=dawidbanasze_chlep;PASSWORD=Rup33EBjMzTtkRu;");
                connection.Open();
                string msg = $"SELECT Password FROM Users WHERE Username = '{LoginBox.Text}'";
                
                MySqlCommand cmd = new MySqlCommand(msg, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<string> list = new List<string>();
                while (dataReader.Read())
                {
                    list.Add(dataReader["Password"] + "");
                }
                if(list.Any())
                {
                    if (list.First() == PasswordBox.Text)
                    {
                        LoggedAs = LoginBox.Text;
                        LoginPanel.Visible = false;
                        LoginPanel.Enabled = false;
                        this.AcceptButton = null;
                        IPAddress X = null;
                        if (IPAddress.TryParse(IPBox.Text, out X))
                        {
                            IPAddres = IPBox.Text;
                            Connection.Connect(LoggedAs);
                            this.Text += " - " + LoggedAs;
                            msg = $"SELECT LevelPoints FROM Users WHERE Username = '{LoginBox.Text}'";
                            cmd = new MySqlCommand(msg, connection);
                            dataReader.Close();
                            dataReader = cmd.ExecuteReader();
                            list.Clear();
                            while (dataReader.Read())
                            {
                                list.Add(dataReader["LevelPoints"] + "");
                            }
                            LevelPoints = int.Parse(list.First());
                            MainMenuInitiate();
                        }
                        ShowError("Wrong IP address!", "Log in failed");
                       
                    }
                }
                else
                {
                    ShowError("Wrong login or password!", "Log in failed");
                }
                
                connection.Close();
                
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if(GameNameBox.Text != "" && !GameNameBox.Text.Contains(' ') && !GamePasswordBox.Text.Contains(' '))
            {
                Connection.Write($"create game {MaxSlots.Value} {GameNameBox.Text} {GamePasswordBox.Text}");
                PlayerID = 1;
                MainMenuPanel.Visible = false;
                MainMenuPanel.Enabled = false;
                LobbyPanel.Visible = true;
                LobbyPanel.Enabled = true;
                LobbyInitiate();
            }
        }
        public void MainMenuInitiate()
        {
            LobbyPanel.Visible = false;
            LobbyPanel.Enabled = false;
            LoginPanel.Visible = false;
            LoginPanel.Enabled = false;

            MainMenuPanel.Visible = true;
            MainMenuPanel.Enabled = true;

            LoggedPanel.Visible = true;
            LoggedPanel.Enabled = true;
            LoggedAsLabel.Text = "Logged as: " + LoggedAs;
            int level = 0;
            int lv = 0;
            



            if (MainMenuThread.ThreadState == ThreadState.Suspended)
                MainMenuThread.Resume();
            else if (MainMenuThread.ThreadState == ThreadState.Unstarted)
                MainMenuThread.Start();
            if (LobbyThread.ThreadState == ThreadState.Running)
                LobbyThread.Suspend();
        }
        public static string password = "";
        public void JoinGame(object sender, EventArgs e, string Gamename)
        {
           
            Password ps = new Password();
            ps.ShowDialog();
            
            
            string ans = Connection.WriteAndRead("join lobby " + Gamename + " " + password);
            if (ans == "joined")
            {
                PlayerID = int.Parse(Connection.Read());
                LobbyInitiate();
                MainMenuPanel.Visible = false;
                MainMenuPanel.Enabled = false;
                LobbyPanel.Enabled = true;
                LobbyPanel.Visible = true;
            }
            else
            {
                ShowError("Wrong password!", "Error");
            }

        }
        public void UpdateGames(string input)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    LobbiesPanel.Controls.Clear();
                });
                foreach (string s in input.Split('#'))
                {
                    if (s != "")
                    {
                        Panel p = new Panel();
                       
                        p.Height = 20;
                        p.Width = LobbiesPanel.Width - 10;

                        Label l = new Label();
                        p.Controls.Add(l);
                        string[] splited = s.Split('|');

                        l.Text = $"{splited[0]}     {splited.Count() - 2}/{splited[1]} | {splited[2]}";
                        l.Location = new Point(5, 2);
                        l.Size = new Size(120, 14);
                        Button b = new Button();
                        p.Controls.Add(b);
                        b.Text = "Join";
                        b.Click += (sender, EventArgs) => { JoinGame(sender, EventArgs, splited[0]); };
                        b.Height = p.Height;
                        b.Width = 50;
                        b.Location = new Point(l.Width + 10, 0);
                        this.Invoke((MethodInvoker)delegate
                        {
                            LobbiesPanel.Controls.Add(p);
                        });


                    }
                }
            }
            catch (Exception e)
            {

                MainForm.ShowError("UpdateGames: " + e.Message, "Error!");
                Environment.Exit(0);
                throw;
            }
        }
        public void MainMenuUpdater()
        {
            try { 
                while (true)
                {
                    

                    string rec = Connection.WriteAndRead("get games");
                    if (rec == "fuckyou")
                        throw new Exception();
                    UpdateGames(rec);
                    Thread.Sleep(3000);
                }
            }
            catch (Exception e)
            {
                if (!Connection.Connected)
                    Environment.Exit(0);
            }

        }
        public void LobbyInitiate()
        {
            
            if (MainMenuThread.ThreadState == ThreadState.Running)
                MainMenuThread.Suspend();
            if (LobbyThread.ThreadState == ThreadState.Suspended)
                LobbyThread.Resume();
            else if (LobbyThread.ThreadState == ThreadState.Unstarted)
                LobbyThread.Start();

          
            string returnmessage = Connection.WriteAndRead("get lobby");

            if (returnmessage == "null")
            {                
                LobbyPanel.Visible = false;
                LobbyPanel.Enabled = false;
                MainMenuPanel.Enabled = true;
                MainMenuPanel.Visible = true;
            }
            else if(returnmessage == "start")
            {

            }
            else   
            {
                string[] splited = returnmessage.Split(' ');
                GameNameLabel.Text = splited[0];
                if (LoggedAs == splited[2])
                {
                    StartButton.Enabled = true;
                    StartButton.Visible = true;
                }
                LobbyLabel.Text = "";
                switch (splited.Count())
                {
                    case 4:
                        LobbyLabel.Text += splited[2] + " (HOST)";
                        break;
                    case 5:
                        LobbyLabel.Text += splited[2] + " (HOST)\n\n";
                        LobbyLabel.Text += splited[4];
                        break;
                    case 6:
                        LobbyLabel.Text += splited[2] + " (HOST)\n\n"; 
                        LobbyLabel.Text += splited[4] + "\n\n"; 
                        LobbyLabel.Text += splited[5];
                        break;
                    case 7:
                        LobbyLabel.Text += splited[2] + " (HOST)\n\n";
                        LobbyLabel.Text += splited[4] + "\n\n";
                        LobbyLabel.Text += splited[5] + "\n\n";
                        LobbyLabel.Text += splited[6];
                        break;
                }
            }
        }
       
        public void StartGame()
        {
                     
            LobbyPanel.Visible = false;
            LobbyPanel.Enabled = false;
            LoggedPanel.Visible = false;
            LoggedPanel.Enabled = false;

            this.Width = 635;
            this.Height = 512;
            



            string map = Connection.WriteAndRead("getmap");
            
            foreach (string s in map.Split(' '))
            {
                try
                {
                    string[] split = s.Split('.');
                    Tile t = new Tile(int.Parse(split[0]), int.Parse(split[1]), split[2]);
                    
                }
                catch
                {
                   
                }
            }
            this.Invalidate();
            GameThread.Start();
            PainterThread.Start();

        }
        public void LobbyUpdater()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(2500);
                  
                    string returnmessage = Connection.WriteAndRead("get lobby");
                    if (returnmessage == "null")
                    {
                       
                        throw new Exception();       
                    }
                    else if(returnmessage == "start")
                    {
                        throw new Exception("game started");
                    }
                    else
                    {
                        string[] splited = returnmessage.Split(' ');
                        GameNameLabel.Text = splited[0];
                        if(LoggedAs == splited[2])
                        {
                            StartButton.Enabled = true;
                            StartButton.Visible = true;
                        }
                        LobbyLabel.Text = "";
                        switch (splited.Count())
                        {
                            case 4:
                                LobbyLabel.Text += splited[2] + " (HOST)";
                                break;
                            case 5:
                                LobbyLabel.Text += splited[2] + " (HOST)\n\n";
                                LobbyLabel.Text += splited[4];
                                break;
                            case 6:
                                LobbyLabel.Text += splited[2] + " (HOST)\n\n";
                                LobbyLabel.Text += splited[4] + "\n\n";
                                LobbyLabel.Text += splited[5];
                                break;
                            case 7:
                                LobbyLabel.Text += splited[2] + " (HOST)\n\n";
                                LobbyLabel.Text += splited[4] + "\n\n";
                                LobbyLabel.Text += splited[5] + "\n\n";
                                LobbyLabel.Text += splited[6];
                                break;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                if (Connection.Connected)
                {
                    if(e.Message == "game started")
                    {
                        StartGame();
                    }
                    else
                        MainMenuInitiate();
                }
                    
                else
                    Environment.Exit(0);
            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Connection.Write("exit lobby");
            MainMenuInitiate();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Connection.Write("start game");
        }
        public static string SendDealNames = "";
        private void SendGoldButton_Click(object sender, EventArgs e)
        {
            SendDealNames = Connection.WriteAndRead("getotherplayers");
            DealMenu dm = new DealMenu();
            dm.ShowDialog();
        }

        private void HireDisbandSoldierButton_Click(object sender, EventArgs e)
        {
            if (Clicked != null)
            {
                if (Clicked.Soldier == null)
                {
                    if (Gold >= 20 && Clicked.Owner == PlayerID)
                    {
                        Connection.Write("sold " + Clicked.PosX + "." + Clicked.PosY);
                    }
                }
                else if( Clicked.Soldier != null && Clicked.Owner == PlayerID)
                    {                               
                        Connection.Write("sold " + Clicked.PosX + "." + Clicked.PosY);
                    }
                
            }
        }
        public static string whattodo = "";
        private void BuildingSlot1_Click(object sender, EventArgs e)
        {
            if (Clicked != null)
            {
                if (Clicked.Owner == PlayerID)
                {
                    BuildingMenu bm = new BuildingMenu();
                    bm.ShowDialog();
                    if (whattodo.StartsWith("build "))
                    {
                        Connection.Write("build " + Clicked.PosX+"."+Clicked.PosY + " " + whattodo.Split(' ')[1]);
                    }
                    else if (whattodo.StartsWith("dest"))
                    {
                        if(Clicked.Owner == PlayerID)
                        {
                            Connection.Write("build " + Clicked.PosX + "." + Clicked.PosY + " nothing");
                        }
                    }
                    else if (whattodo.StartsWith("cancel") || whattodo == "")
                    {

                    }
                    whattodo = "";
                }
            }


        }

        private void DevelopmentButton_Click(object sender, EventArgs e)
        {
            DevMapmode = !DevMapmode;
        }

        private void GuestLogin_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            LoggedAs = "Guest_" + r.Next(0,10)+ r.Next(0, 10)+ r.Next(0, 10)+ r.Next(0, 10)+ r.Next(0, 10)+ r.Next(0, 10)+ r.Next(0, 10);
            GuestLogin.Visible = false;
            GuestLogin.Enabled = false;
            LoginPanel.Visible = false;
            LoginPanel.Enabled = false;
            this.AcceptButton = null;
            IPAddres = IPBox.Text;
            Connection.Connect(LoggedAs);
            MainMenuInitiate();
        }
    }
    public class Soldier
    {
        public int Moves = 4;
        public int MaxMoves = 4;
        public int HP = 5;
        public int MaxHP = 5;
        public int Exp = 0;
        public Soldier()
        {

        }
    }
    //Upgrade slot types:
    //Native: Forest(+Food),
    //
   
    public class BattleTile
    {
        public int PosX;
        public int PosY;
        public string Type = "";
        public int OwnerID;
        public int TerrainID;
        public PointF[] Shape;
        public BattleTile(int x, int y)
        {
            PosX = x;
            PosY = y;

            int x2 = 24 * PosX + 30;
            int y2 = 0;
            if (PosX % 2 == 0)
                y2 = 26 * PosY + 37;
            else
                y2 = 26 * PosY + 24;

            var shape = new PointF[6];
            var shapefort = new PointF[6];
            var r = 16; //70 px radius 

            //Create 6 points
            for (int c = 0; c < 6; c++)
            {
                shape[c] = new PointF(
                   x2 + r * (float)Math.Cos(c * 60 * Math.PI / 180f),
                    y2 + r * (float)Math.Sin(c * 60 * Math.PI / 180f));
                shapefort[c] = new PointF(
                    x2 + (r - 4) * (float)Math.Cos(c * 60 * Math.PI / 180f),
                    y2 + (r - 4) * (float)Math.Sin(c * 60 * Math.PI / 180f));
            }

            Shape = shape;
        }
    }
    public class Battle
    {
        public BattleTile[,] BattleMap = new BattleTile[15, 15];
        public int[] Participants = new int[7];
    }

    public class Tile
    {
       
        public int x = 0;
        public int y = 0;
        public int PosX;
        public int PosY;
        public int Owner;
        public string Name;
        public string BuildingType = "nothing";

        public Battle Battle = null;

        public int Capital = 0;
       
       

       

        public PointF[] Shape;
        public PointF[] FortShape;
        public Soldier Soldier;
        public int Development = 1;
        public Tile(int x, int y, string name)
        {
            PosX = x;
            PosY = y;
            Name = name;
            MainForm.Tiles.Add(this);

            //next hex
            //x + 30
            //y + 17

            //hex below
            //y + 34

            x = 30 * PosX + 30;
            if (PosX % 2 == 0)
                y = 34 * PosY + 47;
            else
                y = 34 * PosY + 30;

            var shape = new PointF[6];
            var shapefort = new PointF[6];
            var r = 20; //70 px radius 

            //Create 6 points
            for (int c = 0; c < 6; c++)
            {
                shape[c] = new PointF(
                   x + r * (float)Math.Cos(c * 60 * Math.PI / 180f),
                    y + r * (float)Math.Sin(c * 60 * Math.PI / 180f));
                shapefort[c] = new PointF(
                    x + (r - 4) * (float)Math.Cos(c * 60 * Math.PI / 180f),
                    y + (r - 4) * (float)Math.Sin(c * 60 * Math.PI / 180f));
            }
            
            Shape = shape;
            FortShape = shapefort;
        }
    }

        
    public static class Connection
    {
        public static TcpClient Client = new TcpClient();
        public static bool Connected = false;
        public static void Connect(string username)
        {
            try
            {
                Client.Connect(MainForm.IPAddres, MainForm.Port);
                S = Client.GetStream();
                SR = new StreamReader(S);
                SW = new StreamWriter(S);
                SW.AutoFlush = true;
      
                SW.WriteLine("connect");
                SW.WriteLine(username);
                Connected = true;
            }

            catch
            {
                MainForm.ShowError("Couldn't make connection to the server!\nCheck your internet connection.", "Connection failed!");

            }
        }
        private static Stream S;
        private static StreamReader SR;
        private static StreamWriter SW;


        public static string WriteAndRead(string message)
        {
            string r = "";
            if (Connected)
            {
                try
                {                  
                    SW.WriteLine(message);
                    r = SR.ReadLine();
                }
                catch
                {
                    r = "error";
                }
            }
            return r;
        }

        public static void Write(string text)
        {
            if (Connected)
            {
                try
                {
                    SW.WriteLine(text);
                }
                catch
                {
                    Connected = false;
                    MessageBox.Show("Connection lost!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
        }
        public static string Read()
        {
            if (Connected)
            {
                try
                {
                    return SR.ReadLine();
                }
                catch (Exception e)
                {
                    Connected = false;
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    return "";
                }
            }
            else
                return "";
        }
        public static void Disconnect()
        {
            if(Connected)
                SW.WriteLine("disconnect");
        }

    }
}
