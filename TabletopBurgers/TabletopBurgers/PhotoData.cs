using System;

namespace Drag_and_Drop
{
    public class PhotoData
    {
        public string Source { get; private set; }
        public string Caption { get; private set; }
        public double Price { get; private set; }

        public PhotoData(string source, string caption, double price)
        {
            this.Source = source;
            this.Caption = caption;
            this.Price = price;
        }
    }
}
