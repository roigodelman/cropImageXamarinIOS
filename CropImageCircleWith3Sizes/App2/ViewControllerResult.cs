using CoreGraphics;
using Foundation;
using System;
using System.Drawing;
using UIKit;

namespace App2
{
    public partial class ViewControllerResult : UIViewController
    {
        public UIImage ImageResult { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetImageView(ImageViewMid, ImageResult, 50.0f);

            SetImageView(ImageViewBig,ImageResult,80.0f);

            SetImageView(ImageViewSmall, ImageResult, 30.0f);




        }


        public ViewControllerResult (IntPtr handle) : base (handle)
        {
        }

        public void SetImageView(UIImageView imageView,UIImage sourceImage,float cornerRadius)
        {
            imageView.Image = ResizeImage(sourceImage, (float)imageView.Bounds.Width, (float)imageView.Bounds.Height);
            imageView.Layer.CornerRadius = cornerRadius;
            imageView.Center = View.Center;
            imageView.Layer.MasksToBounds = true;
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