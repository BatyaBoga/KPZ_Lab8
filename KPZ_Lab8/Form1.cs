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


    // Базовий клас для об'єктів снігу
    abstract class Snow
    {
        protected int size; // Розмір сніжинки
        protected Color color; // Колір сніжинки

        public int Size { get { return size; } }
        public Color Color { get { return color; } }

        public abstract void Draw(Graphics graphics, Point position); // Метод для малювання сніжинки
    }

    // Конкретний клас снігу
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

    // Декоратор для снігу, який додає обрамлення
    class SnowWithBorder : Snow
    {
        private Snow snow; // Посилання на об'єкт снігу

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

    // Декоратор для снігу, який додає тінь
    class SnowWithShadow : Snow
    {
        private Snow snow; // Посилання на об'єкт снігу

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

    // Приклад використання
    class SnowfallForm : Form
    {
        private Snow snow; // Об'єкт снігу

        public SnowfallForm()
        {
            this.ClientSize = new Size(800, 600);

            // Створюємо об'єкт снігу і обгортаємо його декораторами
            snow = new SnowWithBorder(new SnowWithShadow(new Snowflake(20, Color.White)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Малюємо сніг на формі
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Point position = new Point(random.Next(this.ClientSize.Width), random.Next(this.ClientSize.Height));
                snow.Draw(e.Graphics, position);
            }
        }
    }
}