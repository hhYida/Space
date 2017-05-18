using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    private Button startGame;

    void Start()
    {
        GameObject btn = GameObject.FindWithTag("Button");
        startGame = btn.GetComponent<Button>();
        startGame.onClick.AddListener(OnClick);
    }

	void OnClick()
    {
        Application.LoadLevel(1);
    }


}
