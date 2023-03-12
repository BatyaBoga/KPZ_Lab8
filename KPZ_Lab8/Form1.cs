namespace KPZ_Lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SnowfallForm());
        }
    }


    // ������� ���� ��� ��'���� ����
    abstract class Snow
    {
        protected int size; // ����� �������
        protected Color color; // ���� �������

        public int Size { get { return size; } }
        public Color Color { get { return color; } }

        public abstract void Draw(Graphics graphics, Point position); // ����� ��� ��������� �������
    }

    // ���������� ���� ����
    class Snowflake : Snow
    {
        public Snowflake(int size, Color color)
        {
            this.size = size;
            this.color = color;
        }

        public override void Draw(Graphics graphics, Point position)
        {
            Brush brush = new SolidBrush(color);
            graphics.FillEllipse(brush, position.X, position.Y, size, size);
        }
    }

    // ��������� ��� ����, ���� ���� ����������
    class SnowWithBorder : Snow
    {
        private Snow snow; // ��������� �� ��'��� ����

        public SnowWithBorder(Snow snow)
        {
            this.snow = snow;
            this.size = snow.Size;
            this.color = snow.Color;
        }

        public override void Draw(Graphics graphics, Point position)
        {
            snow.Draw(graphics, position);

            Pen pen = new Pen(Color.Black, 1);
            graphics.DrawEllipse(pen, position.X, position.Y, size, size);
        }
    }

    // ��������� ��� ����, ���� ���� ���
    class SnowWithShadow : Snow
    {
        private Snow snow; // ��������� �� ��'��� ����

        public SnowWithShadow(Snow snow)
        {
            this.snow = snow;
            this.size = snow.Size;
            this.color = snow.Color;
        }

        public override void Draw(Graphics graphics, Point position)
        {
            snow.Draw(graphics, position);

            Brush brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0));
            graphics.FillEllipse(brush, position.X + size / 2, position.Y + size / 2, size, size / 2);
        }
    }

    // ������� ������������
    class SnowfallForm : Form
    {
        private Snow snow; // ��'��� ����

        public SnowfallForm()
        {
            this.ClientSize = new Size(800, 600);

            // ��������� ��'��� ���� � ��������� ���� ������������
            snow = new SnowWithBorder(new SnowWithShadow(new Snowflake(20, Color.White)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // ������� ��� �� ����
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Point position = new Point(random.Next(this.ClientSize.Width), random.Next(this.ClientSize.Height));
                snow.Draw(e.Graphics, position);
            }
        }
    }
}