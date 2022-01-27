using UnityEngine;

public static class Utils
{ 
    public static void IsInteractive (this ObjectView objectView, bool isEnabled)
    {
        var allMeshesInObject = objectView.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in allMeshesInObject)
        {
            mesh.enabled = isEnabled;
        }

        var collider = objectView._collider;
        collider.enabled = isEnabled;
    }
}
