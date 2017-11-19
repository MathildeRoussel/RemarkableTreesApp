using System;
using CoreGraphics;
using Foundation;
using MapKit;
using RemarkableTreeApp.iOS.MapClassesExtensions;
using UIKit;

namespace RemarkableTreeApp.iOS.Annotations
{
    [Register("ClusterView")]
    public class ClusterView : MKAnnotationView
    {
        public static UIColor ClusterColor = UIColor.FromRGB(46, 125, 50);

        public override IMKAnnotation Annotation
        {
            get
            {
                return base.Annotation;
            }
            set
            {
                base.Annotation = value;

                var cluster = MKAnnotationWrapperExtensions.UnwrapClusterAnnotation(value);
                if (cluster != null)
                {
                    var renderer = new UIGraphicsImageRenderer(new CGSize(40, 40));
                    var count = cluster.MemberAnnotations.Length;

                    Image = renderer.CreateImage((context) => {
                        ClusterColor.SetFill();
                        UIBezierPath.FromOval(new CGRect(0, 0, 40, 40)).Fill();

                        UIColor.White.SetFill();
                        UIBezierPath.FromOval(new CGRect(8, 8, 24, 24)).Fill();

                        var attributes = new UIStringAttributes()
                        {
                            ForegroundColor = UIColor.Black,
                            Font = UIFont.BoldSystemFontOfSize(19)
                        };
                        var text = new NSString($"{count}");
                        var size = text.GetSizeUsingAttributes(attributes);
                        var rect = new CGRect(20 - size.Width / 2, 20 - size.Height / 2, size.Width, size.Height);
                        text.DrawString(rect, attributes);
                    });
                }
            }
        }

        public ClusterView()
        {
        }

        public ClusterView(NSCoder coder) : base(coder)
        {
        }

        public ClusterView(IntPtr handle) : base(handle)
        {
        }

        public ClusterView(IMKAnnotation annotation, string reuseIdentifier) : base(annotation, reuseIdentifier)
        {
            // Initialize
            DisplayPriority = MKFeatureDisplayPriority.DefaultHigh;
            CollisionMode = MKAnnotationViewCollisionMode.Circle;

            // Offset center point to animate better with marker annotations
            CenterOffset = new CoreGraphics.CGPoint(0, -10);
        }
    }
}
