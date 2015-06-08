using UnityEngine;
using System.Collections;

public class CameraPixelPerfect : MonoBehaviour 
{
	
	void Awake () 
	{
		Camera.orthographicSize = ((float)Screen.height) / 2;
	}
}
