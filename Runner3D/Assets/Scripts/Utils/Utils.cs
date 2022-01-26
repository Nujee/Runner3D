using UnityEngine;

public static class Utils
{   /*
    public static void IsVisible(this MeshRenderer[] allMeshesInObject, bool isVisible)
    { 
        foreach (MeshRenderer mesh in allMeshesInObject)
        {
            mesh.enabled = isVisible;
        }
    }

        public static void IsCollidable(this Collider collider, bool isCollidable)
    {
        collider.enabled = isCollidable;
    }
    */

    public static void IsInteractive (this ObjectView objectView, bool isInteractive)
    {
        var allMeshesInObject = objectView.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in allMeshesInObject)
        {
            mesh.enabled = isInteractive;
        }

        var collider = objectView._collider;
        collider.enabled = isInteractive;
    }
}
