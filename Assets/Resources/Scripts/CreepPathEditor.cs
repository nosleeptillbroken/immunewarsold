using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEditor;

[@CustomEditor(typeof(CreepPath))]
public class CreepPathEditor : Editor
{
    public override void OnInspectorGUI()
    {

        CreepPath path = (CreepPath)target;
        List<Vector3> points = path.points;
        
        base.OnInspectorGUI();

        if (GUILayout.Button("Add Point")) {

            points.Add(Vector3.zero);

        }
    }

    void OnSceneGUI()
    {
        Handles.color = Color.blue;

        CreepPath path = (CreepPath)target;
        List<Vector3> points = path.points;

        Handles.Label(path.transform.position, "Origin");
        
        for (int i = 0; i < points.Count;i++)
        {
            Handles.lighting = false;
            points[i] = Handles.PositionHandle(points.ElementAt(i), Quaternion.identity);
            Handles.lighting = true;
            
            Handles.Label(points[i], i.ToString());
            Handles.DrawSolidDisc(points[i], Vector3.up, 0.05f);

            if (i+1 < points.Count)
            {
                Handles.DrawLine(points[i], points[i+1]);
            }
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }

    } 

}
