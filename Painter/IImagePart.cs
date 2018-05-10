namespace Painter
{
    using System.Drawing;

    public interface IImagePart
    {
        int Width { get; }

        int Height { get; }

        void SetColor(int row, int col, Color color);

        Color GetColor(int row, int col);

        Bitmap Export();
    }
}