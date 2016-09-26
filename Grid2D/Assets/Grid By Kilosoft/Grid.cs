///
/// Name: Grid By Kilosoft
/// Author: Kilosoft (Шаганов Артем)
/// Version: 0.1
/// Date: 26.09.2016
/// 

using UnityEngine;

public class Grid : MonoBehaviour
{
	public float Width = 1f;
	public float Height = 1f;
	public bool Draw = true;

    public float CountLines = 10f;

    void OnDrawGizmos()
    {
		if (Width < 0.1f) Width = 0.1f;
		if (Height < 0.1f) Height = 0.1f;
        
		if (Draw)
        {
            var xVar = (CountLines / 2f) * Width;
            for (float x = -xVar; x < xVar; x += Width)
            {
                var c = Mathf.Floor(x / Width) * Width + Width / 2f;
                var a = new Vector3(c, -CountLines * Width / 2f - Width / 2f);
                var b = new Vector3(c, CountLines * Width / 2f - Width / 2f);
                Gizmos.DrawLine(a, b);
            }

            var yVar = (CountLines / 2f) * Height;
            for (float y = -yVar; y < yVar; y += Height)
            {
                var c = Mathf.Floor(y / Height) * Height + Height / 2f;
                var a = new Vector3(-CountLines * Height / 2f - Height / 2f, c);
                var b = new Vector3(CountLines * Height / 2f - Height / 2f, c);
                Gizmos.DrawLine(a, b);
            }
		}

    }
}
