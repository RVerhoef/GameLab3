//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
 	private float _speed = 50000;
	private float _jumpSpeed = 70000;
	private float _attackPower = 50000;
	private float _direction = 1;
	private float _minScreenHeight;
	private bool _onGround;
	private string _playerNumber;
	private int _lives = 3;
	private GameObject _respawnPoint;
	private Rigidbody _rigidBody;
	private Animator _animator;

	void Awake ()
	{
		_minScreenHeight = Screen.height - Screen.height * 2;
		_rigidBody = GetComponent<Rigidbody>();
		_animator = GetComponent<Animator>();
		_respawnPoint = GameObject.FindGameObjectWithTag ("Respawn");

		if(gameObject.name == "Player1")
		{
			_playerNumber = "1";
		}
		else if (gameObject.name == "Player2")
		{
			_playerNumber = "2";
		}
	}

	void FixedUpdate () 
	{
		//flip sprite
		if(Input.GetAxis ("Horizontal" + _playerNumber) > 0)
		{
			_direction = 1;
		}
		else if(Input.GetAxis ("Horizontal" + _playerNumber) < 0)
		{
			_direction = -1;
		}

		transform.localScale = new Vector3(_direction ,transform.localScale.y ,transform.localScale.z);

		//set & unset walking animation & movement (< 0 && > 0 makes the jump bug)
		if(Input.GetAxis ("Horizontal" + _playerNumber) < 0 || Input.GetAxis ("Horizontal" + _playerNumber) > 0 && _animator.GetBool("Jumping") == false && _animator.GetBool("Punching") == false && _onGround == true)
		{
			_rigidBody.velocity = new Vector3 ((Input.GetAxis ("Horizontal" + _playerNumber) * (_speed)) * Time.deltaTime, _rigidBody.velocity.y, _rigidBody.velocity.z);
			_animator.SetBool("Walking",true);
		}
		else
		{
			_animator.SetBool("Walking",false);
		}

		//jumping
		if(Input.GetButton ("Jump" + _playerNumber) && _animator.GetBool("Jumping") == false && _onGround == true)
		{ 
			_rigidBody.AddForce(transform.up * _jumpSpeed);
		}

		//if(_animator.GetBool("Jumping"))
		//{
			//_rigidBody.AddForce(new Vector3(0, -2000, 0));
		//}

		//attacking
		if(Input.GetButton ("Fire" + _playerNumber) && _animator.GetBool("Jumping") == false)
		{
			_animator.SetBool("Punching",true);
		}
		else
		{
			_animator.SetBool("Punching",false);
		}

		if(Input.GetButton ("Fire" + _playerNumber) && _animator.GetBool("Jumping") == true)
		{
			_animator.SetBool("Kicking",true);
		}
		else
		{
			_animator.SetBool("Kicking",false);
		}
		 
		//the player dies if he falls off the screen
		//if (transform.localPosition.y < _minScreenHeight) 
		//{
			//_animator.SetBool ("Dieing", true);
			//_rigidBody.AddForce (transform.up * 3000);
		//} 
		if (transform.localPosition.y < _minScreenHeight) 
		{
			_animator.SetBool ("Dieing", false);
			_lives -= 1;
			_rigidBody.velocity = Vector3.zero;
			_rigidBody.angularVelocity = Vector3.zero;
			transform.localPosition = new Vector3(_respawnPoint.transform.localPosition.x, _respawnPoint.transform.localPosition.y, transform.localPosition.z);
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Platform" && collision.transform.localPosition.y - transform.localPosition.y <= 310)
		{
			//set jumping animation
			Debug.Log("Hit ground!");
			_animator.SetBool("Jumping",false);
			_onGround = true;
		}
	}

	void OnCollisionExit (Collision collision)
	{
		if(collision.gameObject.tag == "Platform")
		{
			//unset jumping animation
			_animator.SetBool("Jumping",true);
			_onGround = false;
		}
	}

	void OnCollisionStay (Collision collision)
	{
		//when the player attacks he pushes the other player back
		if (collision.gameObject.tag == "Player" &&_animator.GetBool("Punching") == true || _animator.GetBool("Kicking") == true) 
		{
			Debug.Log("Attacking");
			if(transform.localPosition.x < collision.transform.localPosition.x && _direction == 1)
			{
				collision.rigidbody.AddForce(transform.right * _attackPower); 
				Debug.Log("Adding force");
			}
			else if(transform.localPosition.x > collision.transform.localPosition.x && _direction == -1)
			{
				collision.rigidbody.AddForce(transform.right * -_attackPower);
				Debug.Log("Adding force");
			}

		}
	}
}
