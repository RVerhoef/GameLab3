using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
 	private float _speed = 50000;
	private float _jumpSpeed = 70000;
	private float _direction = 1;
	private Rigidbody _rigidBody;
	private Animator _animator;

	void Awake ()
	{
		_rigidBody = this.GetComponent<Rigidbody>();
		_animator = this.GetComponent<Animator>();
	}

	void FixedUpdate () 
	{
		//movement
		_rigidBody.velocity = new Vector3 ((Input.GetAxis ("Horizontal") * (_speed)) * Time.deltaTime, _rigidBody.velocity.y, _rigidBody.velocity.z);

		//flip sprite
		if(Input.GetAxis ("Horizontal") > 0)
		{
			_direction = 1;
		}
		else if(Input.GetAxis ("Horizontal") < 0)
		{
			_direction = -1;
		}

		transform.localScale = new Vector3(_direction ,transform.localScale.y ,transform.localScale.z);

		//set & unset walking animation
		if(Input.GetButton ("Horizontal") && _animator.GetBool("Jumping") == false)
		{
			_animator.SetBool("Walking",true);
		}
		else
		{
			_animator.SetBool("Walking",false);
		}

		//jumping
		if(Input.GetButton ("Jump") && _animator.GetBool("Jumping") == false)
		{ 
			_rigidBody.AddForce(transform.up * _jumpSpeed);
		}

		//if(_animator.GetBool("Jumping"))
		//{
			//_rigidBody.AddForce(new Vector3(0, -2000, 0));
		//}

		//attacking
		if(Input.GetButton ("Fire1") && _animator.GetBool("Jumping") == false)
		{
			_animator.SetBool("Punching",true);
		}
		else
		{
			_animator.SetBool("Punching",false);
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		//set jumping animation
		 Debug.Log("Hit!");
		_animator.SetBool("Jumping",false);
	}

	void OnCollisionExit (Collision collision)
	{
		//unset jumping animation
		_animator.SetBool("Jumping",true);
	}
}
