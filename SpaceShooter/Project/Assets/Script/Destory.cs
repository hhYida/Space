using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour {
    public GameObject ps_player;
    public GameObject ps_stone;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bolt" || other.gameObject.tag == "Bolt_enemy") 
        {
            Instantiate(ps_stone, transform.position, transform.rotation);
            if (other.gameObject.tag == "Player")
                Instantiate(ps_player, transform.position, transform.rotation);
            gameController.AddScore(10); 
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
