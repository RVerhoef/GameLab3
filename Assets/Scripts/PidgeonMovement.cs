using UnityEngine;
using System.Collections;

public class PidgeonMovement : MonoBehaviour 
{
	private float _speed = 80000;
	private Rigidbody _rigidBody;

	void Awake () 
	{
		_rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate () 
	{
		//makes the pidgeon fly
		_rigidBody.velocity = new Vector3 (_speed * Time.deltaTime, _rigidBody.velocity.y, _rigidBody.velocity.z);
	}
}
