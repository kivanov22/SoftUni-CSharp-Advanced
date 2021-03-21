using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
   public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length , double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length 
        {
            get => this.length;
            private set 
            {
                this.ThrowInvalidSide(value, nameof(this.Length));
                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                this.ThrowInvalidSide(value, nameof(this.Width));
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                this.ThrowInvalidSide(value, nameof(this.Height));
                this.height = value;
            }
        }
        public double CalculateVolume()
        {
            return this.Width * this.Length * this.Height;
        }
        public double CalculateLatercalSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }
        public double CalculateSurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }
        private void ThrowInvalidSide(double value,string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
