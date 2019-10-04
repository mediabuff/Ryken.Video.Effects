﻿using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryken.Video.Effects
{
    public sealed class InterpolationEffectHandler : IVideoEffectHandler
    {
        public CanvasImageInterpolation DownscaleInterpolationMode { get; set; } = CanvasImageInterpolation.Linear;
        public CanvasImageInterpolation UpscaleInterpolationMode { get; set; } = CanvasImageInterpolation.Linear;

        void IVideoEffectHandler.ProcessFrame(IVideoEffectHandlerArgs args)
        {
            using (var ds = args.OutputFrame.CreateDrawingSession())
            {
                ds.DrawImage(args.InputFrame, args.OutputFrame.Bounds, args.InputFrame.Bounds, 1, 
                    (args.OutputFrame.SizeInPixels.Width > args.InputFrame.SizeInPixels.Width || args.OutputFrame.SizeInPixels.Height > args.InputFrame.SizeInPixels.Height) ? UpscaleInterpolationMode : DownscaleInterpolationMode);
            }
        }

        void IVideoEffectHandler.CreateResources()
        {
            
        }

        void IVideoEffectHandler.DestroyResources()
        {
            
        }

    }
}