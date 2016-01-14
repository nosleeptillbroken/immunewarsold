using UnityEngine;
using System.Collections;

// Main static game class
// Contains directory strings, static functions, and other utilities
internal static class Game
{
    // Returns the prefab directory + prefab name + prefab extension
    public static string GetPrefabLocation(string prefab, string ext = ".prefab")
    { return "Assets/Prefabs/" + prefab + ext; }

    // Returns the mesh directory + mesh name (must include mesh extension)
    public static string GetMeshLocation(string mesh, string ext = ".obj")
    { return "Assets/Meshes/" + mesh + ext; }

    // Returns the texture directory + mesh name (must include texture extension)
    public static string GetTextureLocation(string texture, string ext = ".png")
    { return "Assets/Textures/" + texture + ext; }

    // Returns the material directory + material name + material extension
    public static string GetMaterialLocation(string material, string ext = ".mat")
    { return "Assets/Materials/" + material + ext; }

    // Returns the scene directory + material name + scene extension
    public static string GetSceneLocation(string scene, string ext = ".unity")
    { return "Assets/Scenes/" + scene + ext; }

}
