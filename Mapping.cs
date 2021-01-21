using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawMapping
{
    public partial class Mapping : UserControl
    {
        private bool initialized = false;
        private short[,] mappingStates;
        private string[,] mappingTexts;

        private readonly Pen _initializePen = new Pen(Color.Black, 3);
        private readonly Pen _focusPen = new Pen(Color.YellowGreen, 3);
        private readonly Pen _fillPen = new Pen(Color.Green, 3);
        private readonly Graphics _graphics;

        public Mapping()
        {
            InitializeComponent();
            _graphics = CreateGraphics();
        }

        #region Properties
        public int XCount { get; private set; }
        public int YCount { get; private set; }
        public int HorizontalSpace { get; set; }
        public int VerticalSpace { get; set; }
        public Color InitializedColor
        {
            get => _initializePen.Color;
            set => _initializePen.Color = value;
        }
        public Color FocusedColor
        {
            get => _focusPen.Color;
            set => _focusPen.Color = value;
        }
        public Color FilledColor
        {
            get => _fillPen.Color;
            set => _fillPen.Color = value;
        }
        public float BorderWidth
        {
            get => _initializePen.Width;
            set
            {
                _initializePen.Width = value;
                _focusPen.Width = value;
                _fillPen.Width = value;
            }
        }

        private int RectWidth { get => (Width - (XCount + 1) * HorizontalSpace) / XCount; }
        private int RectHeight { get => (Height - (YCount + 1) * VerticalSpace) / YCount; }
        #endregion

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
            int xLocation = HorizontalSpace;
            for (int x = 0; x < XCount; x++)
            {
                int yLocation = VerticalSpace;
                for (int y = 0; y < YCount; y++)
                {
                    var point = new Point(xLocation, yLocation);
                    switch (mappingStates[x, y])
                    {
                        case 1:
                            DrawFocusedRectangle(point);
                            break;
                        case 2:
                            DrawFilledRectangle(point, mappingTexts[x,y]);
                            break;
                        case 0:
                        default:
                            DrawInitializedRectangle(point);
                            break;
                    }
                    yLocation += RectHeight + VerticalSpace;
                }
                xLocation += RectWidth + HorizontalSpace;
            }
        }

        public void Focus(int x, int y)
        {
            CheckInitializedStatus();
            CheckXY(x, y);
            int xLocation = (x + 1) * HorizontalSpace + x * RectWidth;
            int yLocation = (y + 1) * VerticalSpace + y * RectHeight;
            DrawFocusedRectangle(new Point(xLocation, yLocation));
            mappingStates[x, y] = 1;
        }

        public void Fill(int x, int y, string text = "")
        {
            CheckInitializedStatus();
            CheckXY(x, y);
            int xLocation = (x + 1) * HorizontalSpace + x * RectWidth;
            int yLocation = (y + 1) * VerticalSpace + y * RectHeight;
            DrawFilledRectangle(new Point(xLocation, yLocation), text);
            mappingStates[x, y] = 2;
            mappingTexts[x, y] = text;
        }

        private void DrawInitializedRectangle(Point point) =>
            _graphics.DrawRectangle(_initializePen, new Rectangle(point, new Size(RectWidth, RectHeight)));

        private void DrawFocusedRectangle(Point point)
        {
            Rectangle rect = new Rectangle(point, new Size(RectWidth, RectHeight));
            _graphics.DrawRectangle(_focusPen, rect);
            _graphics.FillRectangle(_focusPen.Brush, rect);
        }

        private void DrawFilledRectangle(Point point, string text)
        {
            Rectangle rect = new Rectangle(point, new Size(RectWidth, RectHeight));
            _graphics.DrawRectangle(_fillPen, rect);
            _graphics.FillRectangle(_fillPen.Brush, rect);
            if (!string.IsNullOrWhiteSpace(text))
            {
                Label label = new Label
                {
                    Location = new Point((int)(point.X + RectWidth * 0.15), (int)(point.Y + RectHeight * 0.15)),
                    Size = new Size((int)(RectWidth * 0.7), (int)(RectHeight * 0.7)),
                    BackColor = _fillPen.Color,
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = text
                };
                this.Controls.Add(label);
            }
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
            { 
                throw new ArgumentException("x and y must be greater than 0."); 
            }
            if (x >= XCount || y >= YCount)
            {
                throw new ArgumentException("x and y must be lower than XCount and YCount.");
            }
        }

        private void Mapping_Resize(object sender, EventArgs e)
        {
            if (XCount <= 0 || YCount <= 0) return;
            if (!initialized) return;

            lock (this)
            {
                Draw();
            }
        }
    }

    public sealed class MappingNeedInitializeException : Exception
    {
        public MappingNeedInitializeException() : base("Need call InitializeMapping method before using.") { }
    }
}
