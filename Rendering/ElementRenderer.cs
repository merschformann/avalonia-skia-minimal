using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;

namespace Skia.Debug.Rendering
{
    public class ElementRenderer : Control
    {
        public ElementRenderer()
        {
            ClipToBounds = true;
        }

        public override void Render(DrawingContext context)
        {
            // Render elements
            context.Custom(new ElementRenderOperation(new Rect(0, 0, Bounds.Width, Bounds.Height)));
            Dispatcher.UIThread.InvokeAsync(InvalidateVisual, DispatcherPriority.Background);
        }
    }
}