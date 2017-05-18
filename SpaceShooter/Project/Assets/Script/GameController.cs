using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public GameObject enemy;
    public GameObject Boss;
    public GameObject healthy;
    public GameObject power;
    public GameObject player;
    public Vector3 spawnValues;
    public RectTransform blood;
    public int hazardCount;
    public int enemyCount;
    public int healthyCount;
    public int powerCount;
    private Vector3 spawnPosition_h = Vector3.zero;
    private Vector3 spawnPosition_e = Vector3.zero;
    private Vector3 spawnPosition_H = Vector3.zero;
    private Vector3 spawnPosition_p = Vector3.zero;
    private Quaternion spawnRotation_h;
    private Quaternion spawnRotation_e;
    private Quaternion spawnRotation_H;
    private Quaternion spawnRotation_p;
    public Text scoreText;
    private int score;
    private string str_l;
    private string str_b; 
    private string str_win;
    private int n;
    private bool noNewEnemy = false;
    private bool boss = false;
    private int bossCount = 0;
    private GameObject enemyTag;
    private GameObject bossTag;

    IEnumerator SpawnWaves_h()
    {
        yield return new WaitForSeconds(5.0f);
        for (int i = 0; i < hazardCount; ++i)
        {
            spawnPosition_h.x = Random.Range(-spawnValues.x, spawnValues.x);
            spawnPosition_h.z = spawnValues.z;
            spawnRotation_h = Quaternion.identity;
            Instantiate(hazard, spawnPosition_h, spawnRotation_h);
            yield return new WaitForSeconds(4.0f);
        }
    }


    IEnumerator SpawnWaves_e()
    {
        yield return new WaitForSeconds(1.0f);
        spawnPosition_e.z = 17;
        spawnRotation_e = new Quaternion(0, 1, 0, 0);
        for (int i = 0; i < enemyCount; ++i)
        {
            spawnPosition_e.x = Random.Range(-11, 11);
            Instantiate(enemy, spawnPosition_e, spawnRotation_e);
            yield return new WaitForSeconds(3.0f);
        }
        noNewEnemy = true;        
    }


    IEnumerator SpawnWaves_H()
    {
        yield return new WaitForSeconds(7.0f);
        spawnPosition_H.z = spawnValues.z;
        spawnRotation_H = Quaternion.identity;
        for (int i = 0; i < healthyCount; ++i)
        {
            spawnPosition_H.x = Random.Range(-spawnValues.x, spawnValues.x);
            Instantiate(healthy, spawnPosition_H, spawnRotation_H);
            yield return new WaitForSeconds(8.0f);
        }
    }

        IEnumerator SpawnWaves_p()
    {
        yield return new WaitForSeconds(9.0f);
        spawnPosition_p.z = spawnValues.z;
        spawnRotation_p = Quaternion.identity;
        for (int i = 0; i < powerCount; ++i)
        {
            spawnPosition_p.x = Random.Range(-spawnValues.x, spawnValues.x);
            Instantiate(power, spawnPosition_p, spawnRotation_p);
            yield return new WaitForSeconds(10.0f);
        }
    }


	void Start () {
        StartCoroutine(SpawnWaves_h());
        StartCoroutine(SpawnWaves_e());
        StartCoroutine(SpawnWaves_H());
        StartCoroutine(SpawnWaves_p());
        score = 0;
        str_l = "";
        str_b = "Pause";
        str_win = "";
        n = 0;
	}

    void Update()
    {
        enemyTag = GameObject.FindWithTag("Enemy");
        if (player == null)
            str_l = "Game Over";
        if (noNewEnemy && enemyTag == null)
            boss = true;
        if (boss)
        {
            if (bossCount == 0)
            {
                Instantiate(Boss, new Vector3(0, 0, 15), new Quaternion(0, 1, 0, 0));
                bossCount = 1;
            }
            bossTag = GameObject.FindWithTag("Boss");
            if (bossTag == null && enemyTag == null)
                str_win = "You Win";
        }

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        scoreText.text = "Score :" + score.ToString();
    }

    void OnGUI()
    {
        GUIStyle style_l = new GUIStyle();
        style_l.fontSize = 50;
        style_l.normal.textColor = Color.white;
        //style_b.normal.textColor = Color.white;
        GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 2 - 50, 40, 40), str_l, style_l);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 40, 40), str_win, style_l);
        if (GUI.Button(new Rect(Screen.width - 100, 10, 100, 30), "Restart")) 
            Application.LoadLevel(1);
        if (GUI.Button(new Rect(Screen.width - 100, 60, 100, 30), str_b))
        {
            if (n == 0)
            {
                Time.timeScale = 0;
                n = 1;
                str_b = "Continue";
            }
            else
            {
                Time.timeScale = 1;
                n = 0;
                str_b = "Pause";
            }
        }
        if (GUI.Button(new Rect(Screen.width - 100, 110, 100, 30), "Quit"))
            Application.Quit();
    }
}
