using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRantator : MonoBehaviour {
    public float tumbel = 10.0f;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumbel;
    }

}
