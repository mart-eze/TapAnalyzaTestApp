using System.Timers;
using AnalyzerTestApp.Models;

namespace AnalyzerTestApp
{
    public partial class MainPage : ContentPage
    {
        private readonly CircleDrawable _circleDrawable;
        private readonly Random _random;
        private readonly System.Timers.Timer _timer;
        private readonly List<Color> _colorPalette = new()
        {
            Colors.Red,
            Colors.Green,
            Colors.Blue,
            Colors.Yellow,
            Colors.Orange,
            Colors.Pink,
            Colors.Cyan,
            Colors.Purple,
            Colors.Teal,
            Colors.Red
        };
        public MainPage()
        {
            InitializeComponent();

            _circleDrawable = new CircleDrawable();
            CircleCanvas.Drawable = _circleDrawable;

            _random = new Random();
            _timer = new System.Timers.Timer(3000);
            _timer.Elapsed += OnTimerElapsed;

            CircleCanvas.SizeChanged += (s, e) =>
            {
                UpdateCenterCoordinates();
                DrawRandomColor(); // First draw
                _timer.Start();
            };
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                DrawRandomColor();
            });
        }

        private void UpdateCenterCoordinates()
        {
            var centerX = (float)(CircleCanvas.Width / 2);
            var centerY = (float)(CircleCanvas.Height / 2);

            _circleDrawable.X = centerX;
            _circleDrawable.Y = centerY;
        }

        private void DrawRandomColor()
        {
            int index = _random.Next(_colorPalette.Count);
            _circleDrawable.Color = _colorPalette[index];

            CircleCanvas.Invalidate();
        }
    }
}
