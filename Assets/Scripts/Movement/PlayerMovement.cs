using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate((Input.GetAxis("Horizontal") * (speed * 10)) * Time.deltaTime, 0, 0);
    }
}
