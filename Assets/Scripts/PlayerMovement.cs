using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
 	private float _speed = 500;
	private float _jumpSpeed = 30000;
	private float _direction = 1;
	private Rigidbody _rigidBody;
	private Animator _animator;

	void Awake ()
	{
		_rigidBody = this.GetComponent<Rigidbody>();
		_animator = this.GetComponent<Animator>();
	}

	void Update () 
	{
		this.transform.Translate ((Input.GetAxis ("Horizontal") * (_speed)) * Time.deltaTime, 0, 0);

		if(Input.GetAxis ("Horizontal") > 0)
		{
			_direction = 1;
		}
		else if(Input.GetAxis ("Horizontal") < 0)
		{
			_direction = -1;
		}

		transform.localScale = new Vector3(_direction ,1 ,1);

		if(Input.GetButton ("Horizontal") && _animator.GetBool("Jumping") == false)
		{
			_animator.SetBool("Walking",true);
		}
		else
		{
			_animator.SetBool("Walking",false);
		}

		if(Input.GetButton ("Jump") && _animator.GetBool("Jumping") == false)
		{ 
			_rigidBody.AddForce(transform.up * _jumpSpeed);
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		_animator.SetBool("Jumping",false);
	}

	void OnCollisionExit (Collision collision)
	{
		_animator.SetBool("Jumping",true);
	}
}
