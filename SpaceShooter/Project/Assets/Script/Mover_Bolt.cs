﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Bolt : MonoBehaviour {
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    void Update()
    {
        if (transform.position.z > 20 || transform.position.z < -20) 
            Destroy(this.gameObject);
    }

}
