///
/// Name: Grid By Kilosoft
/// Author: Kilosoft (Шаганов Артем)
/// Version: 0.1
/// Date: 26.09.2016
/// 
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
public class GridEditor : Editor
{

    Grid grid;
        
    void OnEnable() { EditorApplication.update += Update; }

    [MenuItem("Kilosoft/Grid")]
    public static void Init()
    {
        new GameObject("Grid By Kilosoft", typeof(Grid));
    }

    public override void OnInspectorGUI()
    {
        grid = (Grid)target;

        EditorGUILayout.LabelField ("Настройка шага:",EditorStyles.boldLabel);
        grid.Width = EditorGUILayout.FloatField ("По оси X", grid.Width);
        grid.Height = EditorGUILayout.FloatField ("По оси Y", grid.Height);
        grid.Draw = EditorGUILayout.Toggle("Показывать", grid.Draw);

        EditorGUILayout.LabelField("Настройка сетки:", EditorStyles.boldLabel);
        grid.CountLines = EditorGUILayout.IntSlider("Кол-во линий", (int)grid.CountLines, 1, 1000);

        EditorGUILayout.LabelField ("Выбранные объекты:",EditorStyles.boldLabel);
        foreach (var obj in Selection.objects)
        {
            EditorGUILayout.TextField("Имя объекта:", obj.name);
        }

        grid.name = "Grid By Kilosoft";
        EditorUtility.SetDirty(grid);

        EditorGUILayout.LabelField("О программе:", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Name: Grid By Kilosoft\nAuthor: Kilosoft\nVersion: 0.1", EditorStyles.helpBox);
    }

    void Update()
    {
        grid = (Grid)target;

        if (grid.Draw)
        {
            foreach (var obj in Selection.objects)
            {
                Vector3 pos = (obj as GameObject).transform.position;
                float x = Mathf.CeilToInt(pos.x / grid.Width) * grid.Width;
                float y = Mathf.CeilToInt(pos.y / grid.Height) * grid.Height;
                float z = pos.z;
                (obj as GameObject).transform.position = new Vector3(x, y, z);
            }
        }
    }

}