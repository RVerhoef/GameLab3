using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 5);
    }
}
