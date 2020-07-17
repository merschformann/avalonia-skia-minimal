using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Rendering.SceneGraph;
using Avalonia.Skia;
using SkiaSharp;

namespace Skia.Debug.Rendering
{
    /// <summary>
    /// Custom operation for drawing simulation elements in 2D via skia.
    /// </summary>
    public class ElementRenderOperation : ICustomDrawOperation
    {
        /// <summary>
        /// Text shown, if no rendering backend is available.
        /// </summary>
        private static readonly FormattedText NoEngine = new FormattedText {Text = "Current rendering API is not Skia"};

        public ElementRenderOperation(Rect bounds)
        {
            Bounds = bounds;
        }

        public void Dispose()
        {
            // No-op
        }

        /// <summary>
        /// The bounds of the drawing canvas.
        /// </summary>
        public Rect Bounds { get; }
        public bool HitTest(Point p) => false;
        public bool Equals(ICustomDrawOperation other) => false;

        private static SKPaint _debugPaint = new SKPaint {Color = SKColors.Crimson, StrokeWidth = 10};

        public void Render(IDrawingContextImpl context)
        {
            var canvas = (context as ISkiaDrawingContextImpl)?.SkCanvas;
            if (canvas == null)
                context.DrawText(Brushes.Black, new Point(), NoEngine.PlatformImpl);
            else
            {
                canvas.Save();
                canvas.DrawOval(500, 500, 100, 200, _debugPaint);
                canvas.Restore();
            }
        }
    }
}