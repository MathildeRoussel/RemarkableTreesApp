using System;
using UIKit;

namespace RemarkableTreeApp.iOS.Helpers
{
    public static class ViewHelper
    {
        public static TView FindInHierarchy<TView>(UIView view) where TView : UIView
        {
            if (view is TView)
                return view as TView;

            foreach (var subview in view.Subviews)
            {
                var viewResult = FindInHierarchy<TView>(subview);

                if (viewResult != null)
                    return viewResult;
            }

            return null;
        }
    }
}
