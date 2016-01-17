using UnityEngine;
using System.Collections;

// Main static game class
// Contains directory strings, static functions, and other utilities
internal static class Game
{
    // Returns the prefab directory + prefab name + prefab extension
    public static string GetPrefabLocation(string prefab)
    { return "Prefabs/" + prefab; }

    // Returns the mesh directory + mesh name (must include mesh extension)
    public static string GetMeshLocation(string mesh)
    { return "Meshes/" + mesh; }

    // Returns the texture directory + mesh name (must include texture extension)
    public static string GetTextureLocation(string texture)
    { return "Textures/" + texture; }

    // Returns the material directory + material name + material extension
    public static string GetMaterialLocation(string material)
    { return "Materials/" + material; }

    // Returns the scene directory + material name + scene extension
    public static string GetSceneLocation(string scene)
    { return "Scenes/" + scene; }

}
