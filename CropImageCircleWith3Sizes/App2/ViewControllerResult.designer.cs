// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace App2
{
    [Register ("ViewControllerResult")]
    partial class ViewControllerResult
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImageViewBig { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImageViewMid { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImageViewSmall { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ImageViewBig != null) {
                ImageViewBig.Dispose ();
                ImageViewBig = null;
            }

            if (ImageViewMid != null) {
                ImageViewMid.Dispose ();
                ImageViewMid = null;
            }

            if (ImageViewSmall != null) {
                ImageViewSmall.Dispose ();
                ImageViewSmall = null;
            }
        }
    }
}