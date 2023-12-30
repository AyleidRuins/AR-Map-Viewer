using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AR_Map_Viewer.Class;

namespace AR_Map_Viewer
{
    public partial class Main : Form
    {
        byte[] mapfile = new byte[4096];
        byte[,] map = new byte[64, 64];
        int ox = 6; int oy = 6; // offset in pixels to render the map

        Player player;
        CityMap citymap;

        readonly SolidBrush innBrush = new SolidBrush(Color.FromArgb(0, 90, 240));
        readonly SolidBrush bankBrush = new SolidBrush(Color.FromArgb(0, 210, 0));
        readonly SolidBrush guildBrush = new SolidBrush(Color.FromArgb(240, 0, 240));
        readonly SolidBrush healerBrush = new SolidBrush(Color.FromArgb(0, 210, 240));
        readonly SolidBrush shopBrush = new SolidBrush(Color.FromArgb(240, 240, 0));
        readonly SolidBrush scenarioBrush = new SolidBrush(Color.FromArgb(150, 150, 150));
        readonly SolidBrush tavernBrush = new SolidBrush(Color.FromArgb(240, 120, 0));
        readonly SolidBrush smithyBrush = new SolidBrush(Color.FromArgb(240, 0, 0));


        #region player info
        //int playerE = 2; // Player East (X)     X=0 is the first column  X=63 is the rightmost column
        //int playerN = 4; // Player North (Y)    Y=0 is the bottom row    Y=63 is the top most row
        #endregion

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Read 4K file 'citymapwalls.xfd'
            // Parse each of the 64x64 squares (4096 squares in total)
            // and work out what bits represent walls and what represent exits (for left, down, right and up)

            // Navigate using arrow keys.

            player = new Player();
            player.X = 35; player.Y = 26; // one square South of Floating Gate
            //player.X = 31; player.Y = 15; // South Walkway

            citymap = new CityMap();

            pictureBox1.BackColor = Color.FromArgb(90, 58, 16);

            string location = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string file = Path.Combine(location, "citymapwalls.xfd");

            using (BinaryReader reader = new BinaryReader(new FileStream(file, FileMode.Open)))
            {
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                reader.Read(mapfile, 0, 4096);
            }

            int x = 0;
            int y = 0;
            foreach (var item in mapfile)
            {
                map[x, y] = item;
                if (x < 63)
                {
                    x = x + 1;
                }
                else
                {
                    x = 0;
                    y = y + 1;
                }
            }

            UpdateStats();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int y = 0; y <= 63; y++)
            {
                for (int x = 0; x <= 63; x++)
                {
                    RenderCell(x, y, e);
                }
            }

            RenderPlayer(e);
            int locId = citymap.location[player.X, player.Y];
            if (locId != 255)
            {
                int rx = ox + player.X * 16 + 1;
                int ry = oy + (1024 - 16) - (player.Y * 16) + 1;
                e.Graphics.FillRectangle(Brushes.White, new Rectangle(rx, ry, 14, 14));
                using (Font myFont = new Font("Arial", 6.5f))
                {
                    e.Graphics.DrawString(citymap.location[player.X, player.Y].ToString(), myFont, Brushes.Black, new Point(rx + 1, ry + 2));
                    e.Graphics.DrawString($"Name {citymap.mapDescription[locId].LocationDescription} Type: {citymap.mapDescription[locId].LocationType}", myFont, Brushes.White, new Point(ox + 50, oy + 1024 - 1));
                }
            }
        }

        private void RenderCell(int x, int y, PaintEventArgs e)
        {
            byte id = GetMapID(x, y);
            Pen pen;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // wall code
            int wallleftid = (id >> 6) & 0x3;
            int walldownid = (id >> 4) & 0x3;
            int wallrightid = (id >> 2) & 0x3;
            int wallupid = id & 0x3;

            if (wallleftid != 0)
            {
                pen = GetWallPen(wallleftid);
                e.Graphics.DrawLine(pen, new Point(ox + x * 16, oy + y * 16), new Point(ox + x * 16, oy + y * 16 + 15));
            }

            if (walldownid != 0)
            {
                pen = GetWallPen(walldownid);
                e.Graphics.DrawLine(pen, new Point(ox + x * 16, oy + y * 16 + 15), new Point(ox + x * 16 + 15, oy + y * 16 + 15));
            }

            if (wallrightid != 0)
            {
                pen = GetWallPen(wallrightid);
                e.Graphics.DrawLine(pen, new Point(ox + x * 16 + 15, oy + y * 16), new Point(ox + x * 16 + 15, oy + y * 16 + 15));
            }

            if (wallupid != 0)
            {
                pen = GetWallPen(wallupid);
                e.Graphics.DrawLine(pen, new Point(ox + x * 16, oy + y * 16), new Point(ox + x * 16 + 15, oy + y * 16));
            }

            // Show locations on map
            int locId = citymap.location[x, y];
            float textSize = 7.25f;

            if (locId >= 0 && locId <= 6) // Inns
            {
                int rx = ox + x * 16 + 1;
                int ry = oy + (1024 - 16) - (y * 16) + 1;
                e.Graphics.FillRectangle(innBrush, new Rectangle(rx, ry, 14, 14));

                using (Font myFont = new Font("Arial", textSize))
                {
                    e.Graphics.DrawString(citymap.location[x, y].ToString(), myFont, Brushes.Black, new Point(rx, ry));
                }
            }
            else if (locId >= 21 && locId <= 23) // Banks
            {
                int rx = ox + x * 16 + 1;
                int ry = oy + (1024 - 16) - (y * 16) + 1;
                e.Graphics.FillRectangle(bankBrush, new Rectangle(rx, ry, 14, 14));

                using (Font myFont = new Font("Arial", textSize))
                {
                    e.Graphics.DrawString(citymap.location[x, y].ToString(), myFont, Brushes.Black, new Point(rx, ry));
                }
            }
            else if (locId >= 55 && locId <= 66) // Guilds
            {
                int rx = ox + x * 16 + 1;
                int ry = oy + (1024 - 16) - (y * 16) + 1;
                e.Graphics.FillRectangle(guildBrush, new Rectangle(rx, ry, 14, 14));

                using (Font myFont = new Font("Arial", textSize))
                {
                    e.Graphics.DrawString(citymap.location[x, y].ToString(), myFont, Brushes.Black, new Point(rx, ry));
                }
            }
            else if (locId >= 53 && locId <= 54) // Healers
            {
                int rx = ox + x * 16 + 1;
                int ry = oy + (1024 - 16) - (y * 16) + 1;
                e.Graphics.FillRectangle(healerBrush, new Rectangle(rx, ry, 14, 14));

                using (Font myFont = new Font("Arial", textSize))
                {
                    e.Graphics.DrawString(citymap.location[x, y].ToString(), myFont, Brushes.Black, new Point(rx, ry));
                }
            }
            else if (locId >= 24 && locId <= 38) // Shops
            {
                int rx = ox + x * 16 + 1;
                int ry = oy + (1024 - 16) - (y * 16) + 1;
                e.Graphics.FillRectangle(shopBrush, new Rectangle(rx, ry, 14, 14));

                using (Font myFont = new Font("Arial", textSize))
                {
                    e.Graphics.DrawString(citymap.location[x, y].ToString(), myFont, Brushes.Black, new Point(rx, ry));
                }
            }
            else if (locId >= 7 && locId <= 20) // Taverns
            {
                int rx = ox + x * 16 + 1;
                int ry = oy + (1024 - 16) - (y * 16) + 1;
                e.Graphics.FillRectangle(tavernBrush, new Rectangle(rx, ry, 14, 14));

                using (Font myFont = new Font("Arial", textSize))
                {
                    e.Graphics.DrawString(citymap.location[x, y].ToString(), myFont, Brushes.Black, new Point(rx, ry));
                }
            }
            else if (locId >= 39 && locId <= 42) // Smith
            {
                int rx = ox + x * 16 + 1;
                int ry = oy + (1024 - 16) - (y * 16) + 1;
                e.Graphics.FillRectangle(smithyBrush, new Rectangle(rx, ry, 14, 14));

                using (Font myFont = new Font("Arial", textSize))
                {
                    e.Graphics.DrawString(citymap.location[x, y].ToString(), myFont, Brushes.Black, new Point(rx, ry));
                }
            }
            else if (locId >= 43 && locId <= 52 || (locId == 67 || locId == 68 || locId == 73 || locId == 74 || locId == 75 || locId == 69)) // Scenarios (Special locations)
            {
                int rx = ox + x * 16 + 1;
                int ry = oy + (1024 - 16) - (y * 16) + 1;
                e.Graphics.FillRectangle(scenarioBrush, new Rectangle(rx, ry, 14, 14));

                using (Font myFont = new Font("Arial", textSize))
                {
                    e.Graphics.DrawString(citymap.location[x, y].ToString(), myFont, Brushes.Black, new Point(rx, ry));
                }
            }
        }

        private Pen GetWallPen(int wallID)
        {
            if (wallID == 1) return new Pen(Color.LightGray, 1f); // Wall
            if (wallID == 2) return new Pen(Color.Magenta, 1f); // Secret Door
            if (wallID == 3) return new Pen(Color.Red, 1f); // Door
            return new Pen(Color.Black, 1f); // Empty space for wall // Will never execute
        }

        private string GetWallDetail(int wallID)
        {
            if (wallID == 0) return "Nothing";
            if (wallID == 1) return "Wall"; // Wall
            if (wallID == 2) return "1-way hidden door"; // Secret Door
            if (wallID == 3) return "Door"; // Door
            return "X";
        }

        private byte GetMapID(int x, int y)
        {
            return map[x, y];
        }

        void RenderPlayer(PaintEventArgs e)
        {
            int px = ox + player.X * 16 + 1;
            int py = oy + (1024 - 16) - (player.Y * 16) + 1;
            Rectangle ee = new Rectangle(px, py, 14, 14);
            using (Pen pen = new Pen(Color.FromArgb(255, 255, 0), 2))
            {
                e.Graphics.DrawRectangle(pen, ee);
            }
        }

        private void UpdateStats()
        {
            //this.Text = $"E:{player.X} N:{player.Y}"; // wall code: {citymap.location[player.X, player.Y]}";

            byte id = GetMapID(player.X, 63 - player.Y); // invert Y coordinates
            labCurrentPosWall.Text = $"{id}";

            int wallleftid = (id >> 6) & 0x3;
            int walldownid = (id >> 4) & 0x3;
            int wallrightid = (id >> 2) & 0x3;
            int wallupid = id & 0x3;

            string text = $"E:{player.X} N:{player.Y}" + Environment.NewLine;
            text = text + "Left:" + GetWallDetail(wallleftid) + Environment.NewLine;
            text = text + "Down:" + GetWallDetail(walldownid) + Environment.NewLine;
            text = text + "Right:" + GetWallDetail(wallrightid) + Environment.NewLine;
            text = text + "Up:" + GetWallDetail(wallupid) + Environment.NewLine;

            text = text + Environment.NewLine;
            int locId = citymap.location[player.X, player.Y];
            if (locId != 255)
            {
                text = text + $"Location Id : {citymap.location[player.X, player.Y].ToString()}" + Environment.NewLine;
                text = text + $"Name : {citymap.mapDescription[locId].LocationDescription}" + Environment.NewLine;
                text = text + $"Type : {citymap.mapDescription[locId].LocationType}";
            }
            labCurrPosDetails.Text = text;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) // Left arrow key pressed
            {
                byte id = GetMapID(player.X, 63 - player.Y); // invert Y coordinates.
                int wallleftid = (id >> 6) & 0x3;
                if (GetWallDetail(wallleftid) != "Wall")
                {
                    player.Heading = 180;
                    player.X = player.X - 1;
                }
            }
            else if (e.KeyCode == Keys.Right) // Right arrow key pressed
            {
                byte id = GetMapID(player.X, 63 - player.Y); // invert Y coordinates.
                int wallrightid = (id >> 2) & 0x3;
                if (GetWallDetail(wallrightid) != "Wall")
                {
                    player.Heading = 0;
                    player.X = player.X + 1;
                }
            }
            else if (e.KeyCode == Keys.Up) // Up arrow key pressed
            {
                byte id = GetMapID(player.X, 63 - player.Y); // invert Y coordinates.
                int wallupid = id & 0x3;
                if (GetWallDetail(wallupid) != "Wall")
                {
                    player.Heading = 270;
                    player.Y = player.Y + 1;
                }
            }
            else if (e.KeyCode == Keys.Down) // Down arrow key pressed
            {
                byte id = GetMapID(player.X, 63 - player.Y); // invert Y coordinates.
                int walldownid = (id >> 4) & 0x3;
                if (GetWallDetail(walldownid) != "Wall")
                {
                    player.Y = player.Y - 1;
                    player.Heading = 90;
                }
            }

            if (player.X < 0) player.X = 0;
            if (player.X > 63) player.X = 63;
            if (player.Y < 0) player.Y = 0;
            if (player.Y > 63) player.Y = 63;

            pictureBox1.Invalidate();
            UpdateStats();
        }
    }
}