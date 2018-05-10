namespace Painter
{
    using System.Drawing;

    public class ImagePart : IImagePart
    {
        private readonly Color[,] _colors;

        private ImagePart(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            this._colors = new Color[this.Height, this.Width];
        }

        public ImagePart(Bitmap bitmap)
            : this(bitmap.Width, bitmap.Height)
        {
            for (int row = 0; row < bitmap.Height; row++)
            {
                for (int col = 0; col < bitmap.Width; col++)
                {
                    this._colors[row, col] = bitmap.GetPixel(col, row);
                }
            }
        }

        public ImagePart(Bitmap bitmap, int startRow, int startColumn, int width, int height)
            : this(width, height)
        {
            for (int currentRow = startRow, row = 0; currentRow < startRow + height; currentRow++, row++)
            {
                for (int currentCol = startColumn, col = 0; currentCol < startColumn + width; currentCol++)
                {
                    this._colors[row, col++] = bitmap.GetPixel(currentCol, currentRow);
                }
            }
        }

        public ImagePart(IImagePart imagePart, int startRow, int startColumn, int width, int height)
            : this(width, height)
        {
            for (int currentRow = startRow, row = 0; currentRow < startRow + height; currentRow++, row++)
            {
                for (int currentCol = startColumn, col = 0; currentCol < startColumn + width; currentCol++)
                {
                    this._colors[row, col++] = imagePart.GetColor(currentRow, currentCol);
                }
            }
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public void SetColor(int row, int col, Color color)
        {
            this._colors[row, col] = color;
        }

        public Color GetColor(int row, int col)
        {
            return this._colors[row, col];
        }

        public Bitmap Export()
        {
            if (this.Width <= 0 || this.Height <= 0)
            {
                return null;
            }

            var bitmapToExport = new Bitmap(this.Width, this.Height);

            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    bitmapToExport.SetPixel(col, row, this._colors[row, col]);
                }
            }

            return bitmapToExport;
        }
    }
}
