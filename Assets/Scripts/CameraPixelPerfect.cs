using UnityEngine;
using System.Collections;

public class CameraPixelPerfect : MonoBehaviour 
{
	
	void Awake () 
	{
		//Sets the camera size to be pixel perfect
		GetComponent<Camera>().orthographicSize = ((float)Screen.height) /1;
	}
}
