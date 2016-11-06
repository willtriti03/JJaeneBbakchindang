using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour
{
	public bool CustomCursor
	{
		get { return !Cursor.visible; }
		set { Cursor.visible = !value; }
	}

    void OnDestroy()
    {
        CustomCursor = false;
    }

	void Start()
	{
		CustomCursor = true;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			CustomCursor = !CustomCursor;
		}
	}
}
