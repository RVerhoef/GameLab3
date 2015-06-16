using UnityEngine;
using System.Collections;

public class PigeonController : MonoBehaviour
{
    public float speed = 5;
    public float cruiseHeight = 625;
    public float shitCooldown = 0.1f;
    public GameObject birdShit;
    public ParticleSystem hitPS;

    private bool stationary = true;
    private Vector3 liftDir;
    private Vector3 cruiseDir;
    private float cTime; 




    // Use this for initialization
    void Start()
    {
        liftDir = new Vector3(0, 1 * speed, 1 * this.transform.localScale.x);
        cruiseDir = new Vector3((1 * this.transform.localScale.x) * speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if(stationary == false)
        {
            if(this.transform.position.y < cruiseHeight)
            {
                this.transform.position += liftDir;
            }
            else
            {
                this.transform.position += cruiseDir;
                cTime += Time.deltaTime;
                if(cTime >= shitCooldown)
                {
                    shit();
                    cTime = 0;
                }
            }
        }

    }
    
    void shit()
    {
        Instantiate(birdShit, this.transform.position, this.gameObject.transform.rotation);
    }
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(hitPS, this.transform.position, this.transform.rotation);
            stationary = false;
        }
    }
}
