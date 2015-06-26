//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class ChangeScreenEdge : MonoBehaviour 
{
	private float _maxScreenWidth;
	private float _minScreenWidth;
	private float _currentPosition;
	
	void Awake()  
	{
		//gets the screen size
		_maxScreenWidth = Screen.width;
		_minScreenWidth = Screen.width - Screen.width * 2;
	}

	void Update () 
	{
		//makes the object appear on the other side of the screen
		if(transform.localPosition.x > _maxScreenWidth)
		{
			Debug.Log ("Change Position");
			_currentPosition = _minScreenWidth;
			transform.localPosition = new Vector3(_currentPosition ,transform.localPosition.y ,transform.localPosition.z);
		}

		if(transform.localPosition.x < _minScreenWidth)
		{
			Debug.Log ("Change Position");
			_currentPosition = _maxScreenWidth;
			transform.localPosition = new Vector3(_currentPosition ,transform.localPosition.y ,transform.localPosition.z);
		}
	}
}
