using UnityEngine;
using System.Collections;

public class BirdShitBehaviour : MonoBehaviour
{
    public float speed = 5;
    public float deleteHeight = 100;
    
    private Vector3 fallDir;
    
    
    // Use this for initialization
    void Start()
    {
        fallDir = new Vector3((1 * 1) * speed, -0.5f * speed * 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += fallDir;

        if(this.transform.position.y < deleteHeight)
        {
            Destroy(this.gameObject, 0);
        }
    }
}
