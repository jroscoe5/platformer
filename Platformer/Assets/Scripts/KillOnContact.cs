using System;
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

    private Collider2D playerHeadCollider, playerFeetCollider;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        KillTilesCollider = this.GetComponent<Collider2D>();
        PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        DeathCounter = GameObject.Find("DeathCounter").GetComponent<TextMeshProUGUI>();
        playerHeadCollider = Player.GetComponent<BoxCollider2D>();
        playerFeetCollider = Player.GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
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
        // Reset player
        StartCoroutine(ResetInOneSec());
    }

    IEnumerator ResetInOneSec()
    {
        yield return new WaitForSeconds(1f);
        Player.transform.position = PlayerManager.spawnPos;
        Player.SetActive(true);

    }
}
