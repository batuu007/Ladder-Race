using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorBrick : EditorWindow
{
       private float _zValue;
       private int _count;
   
       private GameObject _parent;
   
       [MenuItem("Window/EditorBrick")]
   
       public static void ShowWindow()
       {
           GetWindow<EditorBrick>("EditorBrick");
       }
   
       private void OnGUI()
       {
           GUILayout.Label("Create From Selected Object :", EditorStyles.boldLabel);
           GUILayout.Label("Z Value :", EditorStyles.boldLabel);
           _zValue = EditorGUILayout.FloatField(_zValue);
           GUILayout.Label("Count :", EditorStyles.boldLabel);
           _count = EditorGUILayout.IntField(_count);
           _parent = GameObject.FindGameObjectWithTag("Brick");
   
           if (GUILayout.Button("Create"))
           {
               foreach (GameObject obj in Selection.gameObjects)
               {
                   for (int i = 0; i < _count; i++)
                   {
                       GameObject g = Instantiate(obj);
                       Vector3 pos = obj.transform.position;
                       pos.z += _zValue * (i + 1);
                       g.transform.position = pos;
                       g.transform.SetParent(_parent.transform);
                   }
               }
           }
       }
}
