using UnityEngine;

namespace Helper
{
    public static class HelperMethods // Extention functions
    {
        internal static void Rotate180Deg(this RectTransform tr)
        {
            tr.rotation = Quaternion.Euler(tr.rotation.x, tr.rotation.y, tr.rotation.z + 180);
        }

        internal static void RotateAsParent(this RectTransform tr, RectTransform parent)
        {
            tr.rotation = Quaternion.Euler(parent.rotation.x, parent.rotation.y, parent.rotation.z);
        }

        internal static void Rotate0Deg(this RectTransform tr)
        {
            tr.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
