using LoveScreen.Controls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input.StylusPlugIns;

namespace LoveScreen.Controls
{
    public class ExtendedInkCanvas : InkCanvas
    {
        public void SetInkTool(DynamicRenderer dynamicRenderer)
        {
            if (dynamicRenderer != null)
                DynamicRenderer = dynamicRenderer;

        }

        protected override void OnStrokeCollected(InkCanvasStrokeCollectedEventArgs E)
        {
            void AddCustomStroke(Stroke CustomStroke)
            {
                Strokes.Remove(E.Stroke);

                Strokes.Add(CustomStroke);

                var args = new InkCanvasStrokeCollectedEventArgs(CustomStroke);

                base.OnStrokeCollected(args);
            }

            if (DynamicRenderer is IDynamicRenderer renderer)
            {
                AddCustomStroke(renderer.GetStroke(E.Stroke.StylusPoints, E.Stroke.DrawingAttributes));
            }
            else base.OnStrokeCollected(E);
        }
    }
}
