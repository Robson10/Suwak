using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suwak
{
    public partial class Suwak : UserControl
    {
        public Suwak()
        {
            InitializeComponent();
            DoubleBuffered = true;
//            this.Size = new Size(100, 20);
            this.Size = new Size(250, 50);
            BackColor = Color.Blue;
            Invalidate();

        }
        
        private bool isHorizontal = true;
        [System.ComponentModel.CategoryAttribute("IsHorizontal")]
        public bool IsHorizontal
        {
            set { isHorizontal = value; Invalidate(); }
            get { return isHorizontal; }
        }
        private int min = 0;
        [System.ComponentModel.CategoryAttribute("Min")]
        public int Min
        {
            get { return min; }
            set { min = value; }
        }
        private int max = 150;
        [System.ComponentModel.CategoryAttribute("Max")]
        public int Max
        {
            get { return max; }
            set { max = value; }
        }
        private int value = 0;
        [System.ComponentModel.CategoryAttribute("Value")]
        public int Value
        {
            get { return value; }
            set
            {
                this.value = value;
                //przeliczanie z wartosci na punkt na lini dla suwaka
                Invalidate();
            }
        }
        private Color myLineColor=Color.Red;
        [System.ComponentModel.CategoryAttribute("myLineColor")]
        public Color MyLineColor
        {
            set { myLineColor = value;Invalidate(); }
            get { return myLineColor; }
        }
        private Color myBackColor= Color.Blue;
        [System.ComponentModel.CategoryAttribute("myBackColor")]
        public Color MyBackColor
        {
            set { myBackColor = value; Invalidate(); }
            get { return myBackColor; }
        }
        private Color myRectColor=Color.Yellow;
        [System.ComponentModel.CategoryAttribute("myRectColor")]
        public Color MyRectColor
        {
            set { myRectColor = value; Invalidate(); }
            get { return myRectColor; }
        }
        Rectangle suwak = new Rectangle();
        protected override void OnPaint(PaintEventArgs e)
        {
            BackColor = myBackColor;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (isHorizontal)
            {
                e.Graphics.FillRectangle(new SolidBrush(myLineColor), new Rectangle(new Point(0, Height * 45 / 100), new Size(Width, Height * 10 / 100)));
                suwak.Size = new Size(Height * 80 / 200, Height * 80 / 100);
                e.Graphics.FillRectangle(new SolidBrush(myRectColor), suwak);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(myLineColor), new Rectangle(new Point(Width*45/100, 0), new Size(Width*10/100,Height)));
                suwak.Size = new Size(Width*80/100, Width* 80 / 200);
                e.Graphics.FillRectangle(new SolidBrush(myRectColor), suwak);

            }
            e.Graphics.DrawString(Value.ToString(),new Font("arial", 12, FontStyle.Bold), new SolidBrush(Color.Red), suwak.Location);

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isHorizontal) MoveAndCalulateForHorizontal(e.Location);
                else MoveAndCalulateForVertical(e.Location);
                Invalidate();
            }
        }
        private void MoveAndCalulateForHorizontal(Point Location)
        {
            double procentSzer = ((Location.X - suwak.Width) * 100) / (ClientRectangle.Width - suwak.Width) + 5;
            int temp = (int)(max - (Math.Abs(min) + Math.Abs(max)) * (100 - procentSzer) / 100);

            if (temp < min)
                Value = (int)(max - (Math.Abs(min) + Math.Abs(max)) * 100.0 / 100.0);
            else if (temp > max)
                Value = (int)(max - (Math.Abs(min) + Math.Abs(max)) * 0.0 / 100.0);
            else
                value = temp;

            if (Location.X + suwak.Width / 2 <= Width && Location.X - suwak.Width / 2 >= 0)
                suwak.Location = new Point(Location.X - suwak.Width / 2, Height * 10 / 100);
        }
        private void MoveAndCalulateForVertical(Point Location)
        {
            double procentWys = ((Location.Y - suwak.Height) * 100) / (ClientRectangle.Height - suwak.Height) + 5;
            int temp = (int)(max - (Math.Abs(min) + Math.Abs(max)) * procentWys / 100);

            if (temp < min)
                Value = (int)(max - (Math.Abs(min) + Math.Abs(max)) * 100.0 / 100.0);
            else if (temp > max)
                Value = (int)(max - (Math.Abs(min) + Math.Abs(max)) * 0.0 / 100.0);
            else
                value = temp;

            if (Location.Y + suwak.Height / 2 <= Height && Location.Y - suwak.Height / 2 >= 0)
                suwak.Location = new Point(Width * 10 / 100, Location.Y - suwak.Height / 2);
        }

    }
}
