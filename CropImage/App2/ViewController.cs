using CoreGraphics;
using System;
using System.Drawing;
using UIKit;

namespace App2
{
    public partial class ViewController : UIViewController
    {
        private UIPinchGestureRecognizer _pinch;
        private UIPanGestureRecognizer _pan;
        private CropperView cropperView;
        private UIImageView _imageView;
        private string imagePath = "Image/thul-DSC_0048.jpg";
        private int _width = 400;
        private int _height = 400;

        public ViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetLayout();
            
        }

        public void SetLayout()
        {
             var  image = ResizeImage(UIImage.FromFile(imagePath), _width, _height);
            
            CGRect frame = new RectangleF(0, 0, _width, _height);
            _imageView = new UIImageView()
            {
                Frame = frame,
                Image = image
            };
            cropperView = new CropperView() { Frame = _imageView.Frame };
            SetPen();
            View.AddSubviews(_imageView,cropperView);
        }



        partial void UIButton3_TouchUpInside(UIButton sender)
        {
            var cropCGImage = _imageView.Image.CGImage.WithImageInRect(cropperView.CropRect);
            using (var croppedImage = UIImage.FromImage(cropCGImage))
            {
                _imageView.Image = croppedImage;
                _imageView.Frame = cropperView.CropRect;
                _imageView.Center = View.Center;
                cropperView.Origin = new CGPoint(_imageView.Frame.Left, _imageView.Frame.Top);
                cropperView.Hidden = true;
            }
        }


        public void SetPen()
        {
            nfloat dx = 0;
            nfloat dy = 0;
            _pan = new UIPanGestureRecognizer(() =>
            {
                if ((_pan.State == UIGestureRecognizerState.Began || _pan.State == UIGestureRecognizerState.Changed) && (_pan.NumberOfTouches == 1))
                {

                    var p0 = _pan.LocationInView(View);

                    if (dx == 0)
                        dx = p0.X - cropperView.Origin.X;

                    if (dy == 0)
                        dy = p0.Y - cropperView.Origin.Y;

                    var p1 = new CGPoint(p0.X - dx, p0.Y - dy);

                    cropperView.Origin = p1;
                }
                else if (_pan.State == UIGestureRecognizerState.Ended)
                {
                    dx = 0;
                    dy = 0;
                }
            });

            cropperView.AddGestureRecognizer(_pan);

            nfloat s0 = 1;
            _pinch = new UIPinchGestureRecognizer(() =>
            {
                nfloat s = _pinch.Scale;
                nfloat ds = (nfloat)Math.Abs(s - s0);
                nfloat sf = 0;
                const float rate = 0.5f;

                if (s >= s0)
                {
                    sf = 1 + ds * rate;
                }
                else if (s < s0)
                {
                    sf = 1 - ds * rate;
                }
                s0 = s;

                cropperView.CropSize = new CGSize(cropperView.CropSize.Width * sf, cropperView.CropSize.Height * sf);

                if (_pinch.State == UIGestureRecognizerState.Ended)
                {
                    s0 = 1;
                }
            });
            cropperView.AddGestureRecognizer(_pinch);

        }

        partial void UIButton7_TouchUpInside(UIButton sender)
        {
            SetLayout();
        }

        public static UIImage ResizeImage(UIImage sourceImage, float width, float height)
        {
            UIGraphics.BeginImageContext(new SizeF(width, height));
            sourceImage.Draw(new RectangleF(0, 0, width, height));
            var resultImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return resultImage;
        }
    }
}