using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SoftArt.WPF.Graph
{
    /// <summary>
    /// 对连线的Path的HitTest
    /// </summary>
    public static class PathHitTestingService
    {
        private static  List<DependencyObject> hitResultsList = new List<DependencyObject>();
        private static Path selectedPath = null;
        private static Brush originalBrush = Brushes.Black;

        public static void HitTesting(Visual hitObject, Point hitPoint)
        {
            // Expand the hit test area by creating a geometry centered on the hit test point.
            EllipseGeometry expandedHitTestArea = new EllipseGeometry(hitPoint, 10.0, 10.0);
            // Clear the contents of the list used for hit test results.
            hitResultsList.Clear();
            // Set up a callback to receive the hit test result enumeration.
            VisualTreeHelper.HitTest(hitObject, null,
                new HitTestResultCallback(hitTestResultCallback),
                new GeometryHitTestParameters(expandedHitTestArea));

            // Perform actions on the hit test results list.
            if (hitResultsList.Count > 0)
            {
                Path path = hitResultsList[0] as System.Windows.Shapes.Path;
                if (path != null)
                {
                    selectedPath = path;
                    UpdatePath(true);
                }
            }
        }
        /// <summary>
        /// 更新SeletecdPath的状态 
        /// </summary>
        /// <param name="isSelected"></param>
        public static void UpdatePath(bool isSelected)
        {
            if (isSelected)
            {
                if (selectedPath != null)
                {
                    if (originalBrush == Brushes.Black)
                    {
                        originalBrush = selectedPath.Stroke.Clone();
                    }
                    selectedPath.Stroke = Brushes.Red;
                }
            }
            else
            {
                if (selectedPath != null)
                {
                    selectedPath.Stroke = originalBrush;
                    selectedPath = null;
                }
            }
        }

        // Return the result of the hit test to the callback.
        private static HitTestResultBehavior hitTestResultCallback(HitTestResult result)
        {
            // Retrieve the results of the hit test.
            IntersectionDetail intersectionDetail = ((GeometryHitTestResult)result).IntersectionDetail;
            switch (intersectionDetail)
            {
                case IntersectionDetail.FullyContains:
                    // Add the hit test result to the list that will be processed after the enumeration.
                    hitResultsList.Add(result.VisualHit);
                    return HitTestResultBehavior.Continue;
                case IntersectionDetail.Intersects:
                    hitResultsList.Add(result.VisualHit);
                    // Set the behavior to return visuals at all z-order levels.
                    return HitTestResultBehavior.Continue;
                case IntersectionDetail.FullyInside:
                    hitResultsList.Add(result.VisualHit);
                    // Set the behavior to return visuals at all z-order levels.
                    return HitTestResultBehavior.Continue;
                default:
                    return HitTestResultBehavior.Stop;
            }
        }

    }
}
