namespace Adapter
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        public SquareToRectangleAdapter(Square square)
        {
            width = square.Side;
            height = square.Side;
        }

        private int width;
        private int height;

        public int Width => width;
        public int Height => height;
    }
}
