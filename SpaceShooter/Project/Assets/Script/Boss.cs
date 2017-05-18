using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public GameObject ps_enemy;
    public GameObject ps_player;
    public GameObject enemy;
    public float fireRate = 0.5f;
    public GameObject shot;
    public Transform shotSpawn;
    private float nextFire = 0.0f;
    public int healthy_boss = 100;
    private Vector3 rotation_bolt;
    private int n = 0;
    private Vector3 spawnPosition_e = Vector3.zero;
    private Quaternion spawnRotation_e;


	void Update () {
        if(Time.time > nextFire && n == 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            shotSpawn.Rotate(0, -10, 0);
            Instantiate(shot, shotSpawn.position + new Vector3(1, 0, 0), shotSpawn.rotation);
            shotSpawn.Rotate(0, -10, 0);
            Instantiate(shot, shotSpawn.position + new Vector3(2, 0, 0), shotSpawn.rotation);
            shotSpawn.Rotate(0, 30, 0);
            Instantiate(shot, shotSpawn.position - new Vector3(1, 0, 0), shotSpawn.rotation);
            shotSpawn.Rotate(0, 10, 0);
            Instantiate(shot, shotSpawn.position - new Vector3(2, 0, 0), shotSpawn.rotation);
            shotSpawn.Rotate(0, -20, 0);
            GetComponent<AudioSource>().Play();
            n = 1;
        }
        else if (Time.time > nextFire && n == 1) 
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            shotSpawn.Rotate(0, 10, 0);
            Instantiate(shot, shotSpawn.position + new Vector3(1, 0, 0), shotSpawn.rotation);
            shotSpawn.Rotate(0, 10, 0);
            Instantiate(shot, shotSpawn.position + new Vector3(2, 0, 0), shotSpawn.rotation);
            shotSpawn.Rotate(0, -30, 0);
            Instantiate(shot, shotSpawn.position - new Vector3(1, 0, 0), shotSpawn.rotation);
            shotSpawn.Rotate(0, -10, 0);
            Instantiate(shot, shotSpawn.position - new Vector3(2, 0, 0), shotSpawn.rotation);
            shotSpawn.Rotate(0, 20, 0);
            GetComponent<AudioSource>().Play();
            n = 2;
        }
        else if (Time.time > nextFire && n == 2)
        {
            nextFire = Time.time + 3 * fireRate;
            shotSpawn.position += new Vector3(0, 0, 5);
            for(int i=1;i<=18;i++)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                shotSpawn.Rotate(0, 20, 0);
            }
            shotSpawn.position -= new Vector3(0, 0, 5);
            n = 0;
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteriod" || other.gameObject.tag == "Bolt" || other.gameObject.tag == "Player")
        {
            healthy_boss -= 1;
            if (other.gameObject.tag == "Player")
                Instantiate(ps_player, transform.position, transform.rotation);
            if (other.gameObject.tag == "Bolt")
                Instantiate(ps_enemy, transform.position, transform.rotation);
            Destroy(other.gameObject);
            StartCoroutine(SpawnWaves_e());
        }
        if (healthy_boss == 0)
            Destroy(this.gameObject);
    }

    IEnumerator SpawnWaves_e()
    {
        yield return new WaitForSeconds(1.0f); 
        spawnPosition_e.x = Random.Range(-11, 11);
        spawnPosition_e.z = 17;
        spawnRotation_e = new Quaternion(0, 1, 0, 0);
        Instantiate(enemy, spawnPosition_e, spawnRotation_e);

    }

}
