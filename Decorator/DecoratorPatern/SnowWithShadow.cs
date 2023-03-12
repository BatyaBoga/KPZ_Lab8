
namespace Decorator.DecoratorPatern
{
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
}
