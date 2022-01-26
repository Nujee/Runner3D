using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void MakeInvisible(this MeshRenderer[] allMeshesInObject)
    {
        foreach (MeshRenderer mesh in allMeshesInObject)
        {
            mesh.enabled = false;
        }
    }

    public static void MakeNoninteractive(this Collider collider)
    {
        collider.enabled = false;
    }
}
