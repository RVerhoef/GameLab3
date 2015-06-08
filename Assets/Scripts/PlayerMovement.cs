using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
 	private float _speed = 500;
	private float _jumpSpeed = 50000;
	public float _direction;
	private Rigidbody _rigidBody;
	private Animator _animator;

	void Awake ()
	{
		_rigidBody = this.GetComponent<Rigidbody>();
		_animator = this.GetComponent <Animator>();
	}

	void Update () 
	{
		float walkTranslation = Input.GetAxis ("Horizontal") * _speed;
		walkTranslation *= Time.deltaTime;
		transform.Translate(walkTranslation, 0, 0);



		if(Input.GetButton ("Jump") && _animator.GetBool("Jumping") == false)
		{ 
			Debug.Log("Jump!");
			_animator.SetBool("Jumping",true);
			_rigidBody.AddForce(transform.up * _jumpSpeed);
		}
	}

	void OnCollisionEnter (Collision other)
	{
		_animator.SetBool("Jumping",false);
	}
}
