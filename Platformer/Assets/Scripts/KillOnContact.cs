﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillOnContact : MonoBehaviour
{

    public Collider2D KillTilesCollider;
    public GameObject Player;
    public PlayerManager PlayerManager;
    public TextMeshProUGUI DeathCounter;
    public AudioSource AudioSource;

    private Collider2D playerHeadCollider, playerFeetCollider;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        KillTilesCollider = this.GetComponent<Collider2D>();
        PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        DeathCounter = GameObject.Find("DeathCounter").GetComponent<TextMeshProUGUI>();
        AudioSource = GameObject.Find("DeathNoise").GetComponent<AudioSource>();
        playerHeadCollider = Player.GetComponent<BoxCollider2D>();
        playerFeetCollider = Player.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    { 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (KillTilesCollider.IsTouching(playerHeadCollider)
        || KillTilesCollider.IsTouching(playerFeetCollider))
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Player.SetActive(false);
        // Increment death count
        DeathCounter.text = (++PlayerManager.deathCount).ToString();

        // Play sound
        AudioSource.Play(0);

        // Reset player
        StartCoroutine(ResetInOneSec());
    }

    IEnumerator ResetInOneSec()
    {
        yield return new WaitForSeconds(1f);
        Player.transform.position = PlayerManager.spawnPos;
        Player.GetComponent<PlayerMovement>().crouch = false;

        //respawn objects
        foreach(GameObject g in PlayerManager.respawnObjects)
        {
            g.SetActive(true);
        }
        PlayerManager.respawnObjects.Clear();

        Player.SetActive(true);

    }
}
