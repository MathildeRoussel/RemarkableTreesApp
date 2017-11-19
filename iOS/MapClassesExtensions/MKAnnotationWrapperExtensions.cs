using System;
using MapKit;

namespace RemarkableTreeApp.iOS.MapClassesExtensions
{
    public static class MKAnnotationWrapperExtensions
    {
        public static MKClusterAnnotation UnwrapClusterAnnotation(IMKAnnotation annotation)
        {
            if (annotation == null) return null;
            return ObjCRuntime.Runtime.GetNSObject(annotation.Handle) as MKClusterAnnotation;
        }
    }
}
