namespace Decorator.DecoratorPatern
{
    abstract class Snow
    {
        protected int size; // Розмір сніжинки
        protected Color color; // Колір сніжинки

        public int Size { get { return size; } }
        public Color Color { get { return color; } }

        public abstract void Draw(Graphics graphics, Point position); // Метод для малювання сніжинки
    }
}

