namespace AnalyzerTestApp.Models
{
    public class CircleDrawable : IDrawable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; } = 25;
        public Color Color { get; set; } = Colors.Red;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Color;
            canvas.FillCircle(X, Y, Radius);
        }
    }
}
