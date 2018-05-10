namespace Painter
{
    using System.Windows.Forms;

    public static class Extensions
    {
        public static void InitDraggable(this PictureBox pictureBox)
        {
            bool draggingStarted = false;

            int x = 0;
            int y = 0;

            pictureBox.MouseDown += delegate(object o, MouseEventArgs args)
            {
                x = args.X;
                y = args.Y;

                draggingStarted = true;
            };
            pictureBox.MouseMove += delegate(object o, MouseEventArgs args)
            {
                if (draggingStarted)
                {
                    if (args.X > x)
                    {
                        pictureBox.Left += args.X - x;
                    }
                    else if (args.X < x)
                    {
                        pictureBox.Left -= x - args.X;
                    }


                    if (args.Y > y)
                    {
                        pictureBox.Top += args.Y - y;
                    }
                    else if (args.Y < y)
                    {
                        pictureBox.Top -= y - args.Y;
                    }
                }
            };
            pictureBox.MouseUp += delegate(object o, MouseEventArgs args)
            {
                draggingStarted = false;
            };
        }
    }
}
