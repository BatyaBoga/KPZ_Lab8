namespace Decorator.DecoratorPatern
{
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
}
