﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public GameObject unicorn;
    public GameObject playersManagerObject;
    public Text bloodSituation;
    private GameObject settingGameObject;
    private SettingControl initialSettings;
    private PlayersManager playerGenerateScript;

    private int level;
    private int playersNum;
    private int player1;
    private int player2;
    private int player3;
    private int player4;

    // Start is called before the first frame update
    void Start()
    {
        settingGameObject = GameObject.Find("SettingGameObject");
        initialSettings = settingGameObject.GetComponent<SettingControl>();

        // set the game difficulty level
        level = initialSettings.level;
        if (level == 0)
        {
            unicorn.GetComponent<RoleController>().maxHealth = 240;
            unicorn.GetComponent<RoleController>().currentHealth = 240;
            bloodSituation.text = 240.ToString();
        }
        else if (level == 1)
        {
            unicorn.GetComponent<RoleController>().maxHealth = 160;
            unicorn.GetComponent<RoleController>().currentHealth = 160;
            bloodSituation.text = 160.ToString();
        }
        else if (level == 2)
        {
            unicorn.GetComponent<RoleController>().maxHealth = 80;
            unicorn.GetComponent<RoleController>().currentHealth = 80;
            bloodSituation.text = 80.ToString();
        }

        // set the background music volume
        backgroundMusic.volume = initialSettings.volume;

        // generate players
        playerGenerateScript = playersManagerObject.GetComponent<PlayersManager>();
        GeneratePlayers(initialSettings, playerGenerateScript);


    }

    public void GeneratePlayers(SettingControl initialSettings, PlayersManager playerGenerateScript)
    {
        // set the players
        playersNum = initialSettings.players;
        player1 = initialSettings.player1;
        player2 = initialSettings.player2;
        player3 = initialSettings.player3;
        player4 = initialSettings.player4;

        // see how many players need to be generate
        if (playersNum == 1)
        {
            // set the player1 avatar
            playerGenerateScript.GeneratePlayer(0, player1);
        }

        if (playersNum == 2)
        {
            // set the player1 avatar
            playerGenerateScript.GeneratePlayer(0, player1);
            // set the player2 avatar
            playerGenerateScript.GeneratePlayer(1, player2);
        }

        if (playersNum == 3)
        {
            // set the player1 avatar
            playerGenerateScript.GeneratePlayer(0, player1);
            // set the player2 avatar
            playerGenerateScript.GeneratePlayer(1, player2);
            // set the player3 avatar
            playerGenerateScript.GeneratePlayer(2, player3);
        }

        if (playersNum == 4)
        {
            // set the player1 avatar
            playerGenerateScript.GeneratePlayer(0, player1);
            // set the player2 avatar
            playerGenerateScript.GeneratePlayer(1, player2);
            // set the player3 avatar
            playerGenerateScript.GeneratePlayer(2, player3);
            // set the player4 avatar
            playerGenerateScript.GeneratePlayer(3, player4);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
