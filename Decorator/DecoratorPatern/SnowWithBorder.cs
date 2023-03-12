namespace Decorator.DecoratorPatern
{
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
}
