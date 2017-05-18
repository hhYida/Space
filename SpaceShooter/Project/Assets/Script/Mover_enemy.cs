using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_enemy : MonoBehaviour {
    public float speed;
    private float x;
    private float z;
    private Vector3 movement;
    private Rigidbody rd;
    void Start()
    {
        x = Random.Range(-11, 11);
        z = Random.Range(-7, 17);
        movement = new Vector3(x, 0, z);
        rd = GetComponent<Rigidbody>();
        rd.velocity = movement * speed;
    }
	
	void Update () {
        if (transform.position.x <= -11 ||transform.position.x >= 11) 
            ChangeDirection_x();
        if (transform.position.z <= -7 || transform.position.z >= 17) 
            ChangeDirection_z();
	}

    void ChangeDirection_x()
    {
        x = Random.Range(-11, 11);
        movement = new Vector3(x, 0, z);
        rd.velocity = movement * speed;
        rd.position = new Vector3(Mathf.Clamp(rd.position.x, -11, 11), 0.0f, Mathf.Clamp(rd.position.z, -7, 17));
    }

    void ChangeDirection_z()
    {
        z = Random.Range(-7, 17);
        movement = new Vector3(x, 0, z);
        rd.velocity = movement * speed;
        rd.position = new Vector3(Mathf.Clamp(rd.position.x, -11, 11), 0.0f, Mathf.Clamp(rd.position.z, -7, 17));
    }

}
