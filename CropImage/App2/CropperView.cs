using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace App2
{
    public sealed class CropperView : UIView
    {
        private CGPoint _origin;
        private CGSize _cropSize;
        
        public CropperView()
        {
            _origin = new CGPoint(0, 100);
            _cropSize = new CGSize(100, 100);

            BackgroundColor = UIColor.Clear;
            Opaque = false;
            Alpha = 0.5f;
        }

        public CGPoint Origin
        {
            get
            {
                return _origin;
            }

            set
            {
                _origin = value;
                SetNeedsDisplay();
            }
        }

        public CGSize CropSize
        {
            get
            {
                return _cropSize;
            }
            set
            {
                _cropSize = value;
                SetNeedsDisplay();
            }
        }

        public CGRect CropRect => new CGRect(Origin, CropSize);

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            using (var g = UIGraphics.GetCurrentContext())
            {

                g.SetFillColor(UIColor.Black.CGColor);
                g.FillRect(rect);

                g.SetBlendMode(CGBlendMode.Clear);
                UIColor.Clear.SetColor();

                var path = new CGPath();
                path.AddRect(new CGRect(_origin, _cropSize));

                g.AddPath(path);
                g.DrawPath(CGPathDrawingMode.FillStroke);

                //MyUILibraryPixel.addView(0, 60, MyUiUtils.basewidth, MyUiUtils.baseheight-160);
            }
        }
    }
}
