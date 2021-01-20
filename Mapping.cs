using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawMapping
{
    public partial class Mapping : UserControl
    {
        private const int seperatorWidth = 10;
        private bool initialized = false;
        private short[,] mappingStates;
        private string[,] mappingTexts;

        private readonly Pen _blackPen = new Pen(Color.Black, 3);
        private readonly Pen _yellowGreenPen = new Pen(Color.YellowGreen, 3);
        private readonly SolidBrush _yellowGreenBrush = new SolidBrush(Color.YellowGreen);
        private readonly Pen _greenPen = new Pen(Color.Green, 3);
        private readonly SolidBrush _greenBrush = new SolidBrush(Color.Green);
        private readonly Graphics _graphics;

        public Mapping()
        {
            InitializeComponent();
            _graphics = CreateGraphics();
        }

        public int XCount { get; private set; }
        public int YCount { get; private set; }

        private int RectWidth { get => (Width - (XCount + 1) * seperatorWidth) / XCount; }
        private int RectHeight { get => (Height - (YCount + 1) * seperatorWidth) / YCount; }

        public void InitializeMapping(int xCount, int yCount)
        {
            if(xCount <= 0 || yCount<= 0)
            {
                throw new ArgumentException("xCount and yCount must be greater than 0.");
            }
            XCount = xCount;
            YCount = yCount;
            mappingStates = new short[xCount, yCount];
            mappingTexts = new string[xCount, yCount];
            mappingStates[0, 0] = 1;
            initialized = true;
            Draw();
        }

        private void Draw()
        {
            CheckInitializedStatus();
            Controls.Clear();
            _graphics.Clear(Parent.BackColor);
            int xLocation = seperatorWidth;
            for (int x = 0; x < XCount; x++)
            {
                int yLocation = seperatorWidth;
                for (int y = 0; y < YCount; y++)
                {
                    var point = new Point(xLocation, yLocation);
                    switch (mappingStates[x, y])
                    {
                        case 1:
                            DrawGreenRectangle(point);
                            break;
                        case 2:
                            DrawFillGreenRectangle(point, mappingTexts[x,y]);
                            break;
                        case 0:
                        default:
                            DrawBlackRectangle(point);
                            break;
                    }
                    
                    yLocation += RectHeight + seperatorWidth;
                }
                xLocation += RectWidth + seperatorWidth;
            }
        }

        public void FocusRect(int x, int y)
        {
            CheckInitializedStatus();
            CheckXY(x, y);
            int xLocation = (x + 1) * seperatorWidth + x * RectWidth;
            int yLocation = (y + 1) * seperatorWidth + y * RectHeight;
            DrawGreenRectangle(new Point(xLocation, yLocation));
            mappingStates[x, y] = 1;
        }

        public void FillRect(int x, int y, string text)
        {
            CheckInitializedStatus();
            CheckXY(x, y);
            int xLocation = (x + 1) * seperatorWidth + x * RectWidth;
            int yLocation = (y + 1) * seperatorWidth + y * RectHeight;
            DrawFillGreenRectangle(new Point(xLocation, yLocation), text);
            mappingStates[x, y] = 2;
            mappingTexts[x, y] = text;
        }

        private void DrawBlackRectangle(Point point) =>
            _graphics.DrawRectangle(_blackPen, new Rectangle(point, new Size(RectWidth, RectHeight)));

        private void DrawGreenRectangle(Point point)
        {
            Rectangle rect = new Rectangle(point, new Size(RectWidth, RectHeight));
            _graphics.DrawRectangle(_yellowGreenPen, rect);
            _graphics.FillRectangle(_yellowGreenBrush, rect);
        }

        private void DrawFillGreenRectangle(Point point, string text)
        {
            Rectangle rect = new Rectangle(point, new Size(RectWidth, RectHeight));
            _graphics.DrawRectangle(_greenPen, rect);
            _graphics.FillRectangle(_greenBrush, rect);
            Label label = new Label
            {
                Location = new Point((int)(point.X + RectWidth * 0.15), (int)(point.Y + RectHeight * 0.15)),
                Size = new Size((int)(RectWidth * 0.7), (int)(RectHeight * 0.7)),
                BackColor = Color.Green,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = text
            };
            this.Controls.Add(label);
        }
            

        private void CheckInitializedStatus()
        {
            if (!initialized)
            {
                throw new MappingNeedInitializeException();
            }
        }

        private void CheckXY(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new ArgumentException("x and y must be greater than 0.");
            if (x >= XCount || y >= YCount)
                throw new ArgumentException("x and y must be lower than XCount and YCount.");
        }

        private void Mapping_Resize(object sender, EventArgs e)
        {
            lock (this)
            {
                if (XCount <= 0 || YCount <= 0) return;
                if (!initialized) return;
                Draw();
            }
        }
    }

    public sealed class MappingNeedInitializeException : Exception
    {
        public MappingNeedInitializeException() : base("Need call InitializeMapping before using.") { }
    }
}
