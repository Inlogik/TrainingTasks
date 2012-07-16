using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks2.LSP
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
    }

    public class Square : Rectangle
    {
        public override int Height
        {
            get { return base.Height; }
            set { SetWidthAndHeight(value); }
        }

        public override int Width
        {
            get { return base.Width; }
            set { SetWidthAndHeight(value); }
        }

        // Both sides of a square are equal.
        private void SetWidthAndHeight(int value)
        {
            base.Height = value;
            base.Width = value;
        }
    }
}
