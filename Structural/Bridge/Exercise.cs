using System;

namespace Bridge
{
    public interface IRenderer1
    {
        string WhatToRenderAs { get; }
    }

    public abstract class Shape1
    {
        public string Name { get; set; }

        protected IRenderer1 renderer;

        protected Shape1(IRenderer1 renderer)
        {
            this.renderer = renderer ?? throw new ArgumentNullException(paramName: $"{nameof(renderer)}");
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    public class VectorRenderer1 : IRenderer1
    {
        public string WhatToRenderAs => "lines";
    }

    public class RasterRenderer1 : IRenderer1
    {
        public string WhatToRenderAs => "pixels";
    }

    public class Triangle : Shape1
    {
        public Triangle(IRenderer1 renderer) : base(renderer) => Name = "Triangle";
    }

    public class Square : Shape1
    {
        public Square(IRenderer1 renderer) : base(renderer) => Name = "Square";
    }

    //public class VectorSquare : Square
    //{
    //    public VectorSquare(IRenderer1 renderer) : base(renderer)
    //    {
    //    }

    //    public override string ToString() => $"Drawing {Name} as lines";
    //}

    //public class RasterSquare : Square
    //{
    //    public RasterSquare(IRenderer1 renderer) : base(renderer)
    //    {
    //    }

    //    public override string ToString() => $"Drawing {Name} as pixels";
    //}

    //public class VectorTriangle : Triangle
    //{
    //    public VectorTriangle(IRenderer1 renderer) : base(renderer)
    //    {
    //    }

    //    public override string ToString() => $"Drawing {Name} as lines";
    //}

    //public class RasterTriangle : Triangle
    //{
    //    public RasterTriangle(IRenderer1 renderer) : base(renderer)
    //    {
    //    }

    //    public override string ToString() => $"Drawing {Name} as pixels";
    //}
}
