using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private GameController gameController;
    public GameObject ps_enemy;
    public GameObject ps_player;
    public float fireRate = 0.5f;
    public GameObject shot;
    public Transform shotSpawn;
    private float nextFire = 0.0f;

	void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bolt") 
        {
            Instantiate(ps_enemy, transform.position, transform.rotation);
            gameController.AddScore(20);
            if (other.gameObject.tag == "Player")
                Instantiate(ps_player, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

}
