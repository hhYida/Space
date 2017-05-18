using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody rd;
    public Boundary boundary;
    private float tilt = -2;
    public float fireRate = 0.5f;
    public GameObject shot;
    public Transform shotSpawn;
    private float nextFire = 0.0f;
    public GameObject ps_player;
    public int healthy;
    //public Text healthyText;
    public GameObject fire_player;
    private int boltNum = 1;
    private GameController gameController;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
        fire_player.GetComponent<ParticleSystem>().Stop();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rd.velocity = movement * speed;
        rd.position = new Vector3(Mathf.Clamp(rd.position.x, boundary.xMin, boundary.xMax),0.0f,Mathf.Clamp(rd.position.z,boundary.zMin,boundary.zMax));
        rd.rotation = Quaternion.Euler(0.0f, 0.0f, rd.velocity.x * tilt);
	}

    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            if (boltNum == 1)
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            else if (boltNum == 2)
            {
                Instantiate(shot, new Vector3(shotSpawn.position.x + 1, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
                Instantiate(shot, new Vector3(shotSpawn.position.x - 1, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
            }
            else if(boltNum==3)
            {
                Instantiate(shot, new Vector3(shotSpawn.position.x + 1, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
                Instantiate(shot, new Vector3(shotSpawn.position.x - 1, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
                Instantiate(shot, new Vector3(shotSpawn.position.x, shotSpawn.position.y, shotSpawn.position.z), shotSpawn.rotation);
            }
                GetComponent<AudioSource>().Play();
        }

        if (healthy == 3)
            gameController.blood.offsetMax = new Vector2(0, 0);
        else if (healthy == 2)
            gameController.blood.offsetMax = new Vector2(-53, 0);
        else if (healthy == 1)
            gameController.blood.offsetMax = new Vector2(-106, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteriod" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss") 
            healthy = 0;
        if(other.gameObject.tag=="Bolt_enemy"||other.gameObject.tag=="Healthy")
        {
            if (other.gameObject.tag == "Bolt_enemy")
                healthy -= 1;
            else if (other.gameObject.tag == "Healthy" && healthy <= 2) 
                healthy += 1;

            if (healthy <= 1)
                fire_player.GetComponent<ParticleSystem>().Play();

            if (healthy > 1)
                fire_player.GetComponent<ParticleSystem>().Stop();

            Destroy(other.gameObject);
        }
        //healthyText.text = "Healthy :" + healthy.ToString();
        if (healthy == 0)
        {
            gameController.blood.offsetMax = new Vector2(-160, 0);
            Instantiate(ps_player, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Power")
        {
            boltNum += 1;
            Destroy(other.gameObject);
        }
    }
}
