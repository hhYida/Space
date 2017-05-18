using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Ps : MonoBehaviour {
    private float lifetime = 1.5f;

	void Start () {
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, lifetime);
	}
	
}
