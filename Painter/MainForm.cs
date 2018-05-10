namespace Painter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private const string FileFilter = "Image (*.bmp, *.jpg, *.gif, *.png)|*.bmp; *.jpg; *.gif; *.png";
        private const int DeltaWidth = 40;
        private const int DeltaHeight = 92;

        private PictureBox _pictureBox;
        private IImagePart _imagePart;
        private IImagePart _currentSelection;
        private Bitmap _copied;

        private int _x;
        private int _y;
        private int _zIndex;

        public MainForm()
        {
            InitializeComponent();

            this.openFileDialog.Filter = FileFilter;
            this.saveFileDialog.Filter = FileFilter;
        }

        private void OnResize(object sender, EventArgs eventArgs)
        {
            this.flowLayoutPanel.Width = this.Width - DeltaWidth;
            this.flowLayoutPanel.Height = this.Height - DeltaHeight;
        }

        private void OnOpenButtonClick(object sender, EventArgs eventArgs)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.flowLayoutPanel.Controls.Clear();

                this._pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Margin = DefaultPadding,
                    Image = new Bitmap(this.openFileDialog.FileName)
                };

                bool selectionStarted = false;

                this._pictureBox.MouseDown += delegate(object o, MouseEventArgs args)
                {
                    this._x = args.X;
                    this._y = args.Y;

                    selectionStarted = true;
                };
                this._pictureBox.MouseUp += delegate(object o, MouseEventArgs args)
                {
                    if (!selectionStarted)
                    {
                        return;
                    }

                    int x = 0, y = 0, width = 0, height = 0;

                    if (args.X > this._x && args.Y > this._y)
                    {
                        x = this._x;
                        y = this._y;
                        width = args.X - x;
                        height = args.Y - y;
                    }
                    else if (args.X > this._x && args.Y < this._y)
                    {
                        x = this._x;
                        y = args.Y;
                        width = args.X - x;
                        height = this._y - y;
                    }
                    else if (args.X < this._x && args.Y > this._y)
                    {
                        x = args.X;
                        y = this._y;
                        width = this._x - x;
                        height = args.Y - y;
                    }
                    else if (args.X < this._x && args.Y < this._y)
                    {
                        x = args.X;
                        y = args.Y;
                        width = this._x - x;
                        height = this._y - y;
                    }

                    this._currentSelection = new ImagePart(
                        this._imagePart,
                        y,
                        x,
                        width,
                        height
                    );

                    selectionStarted = false;
                };

                this._imagePart = new ImagePart(this._pictureBox.Image as Bitmap);
                this.flowLayoutPanel.Controls.Add(this._pictureBox);
                this._zIndex = 0;
            }
        }

        private void OnSaveAsButtonClick(object sender, EventArgs eventArgs)
        {
            if (this._pictureBox == null)
            {
                return;
            }

            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.EmbedRecentlyAddedImageParts();

                this._pictureBox.Image.Save(this.saveFileDialog.FileName);
            }
        }

        private void OnImportButtonClick(object sender, EventArgs eventArgs)
        {
            if (this._pictureBox == null)
            {
                return;
            }

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(this.openFileDialog.FileName);
                var pictureBox = new PictureBox
                {
                    Image = image,
                    Margin = DefaultMargin,
                    Left = 0,
                    Top = 0,
                    Width = image.Width,
                    Height = image.Height
                };

                pictureBox.InitDraggable();
                
                this._pictureBox.Controls.Add(pictureBox);
                this._pictureBox.Controls[this._zIndex++].BringToFront();
            }
        }

        private void OnCopyButtonClick(object sender, EventArgs eventArgs)
        {
            if (this._currentSelection == null)
            {
                return;
            }

            this._copied = this._currentSelection.Export();
        }

        private void OnPasteButtonClick(object sender, EventArgs eventArgs)
        {
            if (this._copied == null)
            {
                return;
            }

            var pictureBox = new PictureBox
            {
                Image = this._copied,
                Margin = DefaultPadding,
                Left = 0,
                Top = 0,
                Width = this._copied.Width,
                Height = this._copied.Height,
            };
            
            pictureBox.InitDraggable();

            this._pictureBox.Controls.Add(pictureBox);
            this._pictureBox.Controls[this._zIndex++].BringToFront();
        }

        private void OnEmbedImagesButtonClick(object sender, EventArgs e)
        {
            if (this._imagePart == null)
            {
                return;
            }
            
            this.EmbedRecentlyAddedImageParts();
        }

        private void EmbedRecentlyAddedImageParts()
        {
            for (int index = this._pictureBox.Controls.Count - 1; index >= 0; index--)
            {
                var pictureBoxControl = this._pictureBox.Controls[index] as PictureBox;

                if (pictureBoxControl == null)
                {
                    continue;
                }

                var bitmap = pictureBoxControl.Image as Bitmap;

                if (bitmap == null)
                {
                    continue;
                }

                int bottom = pictureBoxControl.Top + pictureBoxControl.Height;
                int right = pictureBoxControl.Left + pictureBoxControl.Width;
                
                if (bottom > this._pictureBox.Height)
                {
                    bottom = this._pictureBox.Height;
                }

                if (right > this._pictureBox.Width)
                {
                    right = this._pictureBox.Width;
                }

                int initialRow = pictureBoxControl.Top < 0 ? 0 : pictureBoxControl.Top;
                int initialCol = pictureBoxControl.Left < 0 ? 0 : pictureBoxControl.Left;
                int initialTop = pictureBoxControl.Top < 0 ? Math.Abs(pictureBoxControl.Top) : 0;
                int initialLeft = pictureBoxControl.Left < 0 ? Math.Abs(pictureBoxControl.Left) : 0;

                for (int row = initialRow, top = initialTop; row < bottom; row++, top++)
                {
                    for (int col = initialCol, left = initialLeft; col < right; col++, left++)
                    {
                        this._imagePart.SetColor(row, col, bitmap.GetPixel(left, top));
                    }
                }
            }

            this._pictureBox.Image = this._imagePart.Export();
            this._pictureBox.Controls.Clear();
            this._zIndex = 0;
        }
    }
}
