using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Asteroid : MonoBehaviour {

    public float speed;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    void Update()
    {
        if (transform.position.z < -20)
            Destroy(this.gameObject);
    }
}
