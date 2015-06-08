using UnityEngine;
using System.Collections;

public class CameraPixelPerfect : MonoBehaviour 
{
	
	void Awake () 
	{
		GetComponent<Camera>().orthographicSize = ((float)Screen.height) / 2;
	}
}
