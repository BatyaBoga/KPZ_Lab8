using Decorator.DecoratorPatern;

namespace Decorator
{
    public partial class Form1 : Form
    {
        private Snow snow;

        Random random;
        public Form1()
        {
            InitializeComponent();

            this.ClientSize = new Size(800, 600);
            
            random = new Random();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Малюємо сніг на формі
           
            for (int i = 0; i < 100; i++)
            {
                var position = new Point(random.Next(this.ClientSize.Width), random.Next(this.ClientSize.Height));
                RandomSnow();
                snow.Draw(e.Graphics, position);
            }
        }

        private void RandomSnow()
        {
            switch (random.Next(1, 4))
            {
                case 1: snow = new Snowflake(random.Next(5, 40), Color.White); break;
                case 2: snow = new SnowWithShadow(new Snowflake(random.Next(5, 40), Color.White)); break;
                case 3: snow = new SnowWithBorder(new Snowflake(random.Next(5, 40), Color.White)); break;
                case 4: snow = new SnowWithBorder(new SnowWithShadow(new Snowflake(random.Next(5, 40), Color.White))); break;

            }
        }
    }
}