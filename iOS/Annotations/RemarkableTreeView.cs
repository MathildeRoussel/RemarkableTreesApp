using System;
using Foundation;
using MapKit;
using UIKit;

namespace RemarkableTreeApp.iOS.Annotations
{
    [Register("RemarkableTreeView")]
    public class RemarkableTreeView : MKMarkerAnnotationView
    {
        public static UIColor TreeColor = UIColor.FromRGB(76, 175, 80);

        public override IMKAnnotation Annotation
        {
            get
            {
                return base.Annotation;
            }
            set
            {
                base.Annotation = value;

                var tree = value as RemarkableTree;
                if (tree != null)
                {
                    ClusteringIdentifier = "remarkableTree";
                    MarkerTintColor = TreeColor;
                    GlyphImage = UIImage.FromBundle("ic_tree");
                    DisplayPriority = MKFeatureDisplayPriority.DefaultHigh;
                    TitleVisibility = MKFeatureVisibility.Adaptive;
                }
            }
        }

        public RemarkableTreeView()
        {
        }

        public RemarkableTreeView(NSCoder coder) : base(coder)
        {
        }

        public RemarkableTreeView(IntPtr handle) : base(handle)
        {
        }

        public RemarkableTreeView(IMKAnnotation annotation, string identifier) : base(annotation, identifier)
        {

        }
    }
}
