using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
 	private float _speed = 500;
	private float _jumpSpeed = 100;
	private Rigidbody _rigidBody;

	void Awake ()
	{
		_rigidBody = this.GetComponent<Rigidbody>();
	}

	void Update () 
	{
		float walkTranslation = Input.GetAxis ("Horizontal") * _speed;
		walkTranslation *= Time.deltaTime;
		transform.Translate(walkTranslation, 0, 0);


	}
}
