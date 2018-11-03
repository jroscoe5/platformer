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

    private Collider2D playerHeadCollider;

    // Use this for initialization
    void Start()
    {
        playerHeadCollider = Player.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (KillTilesCollider.IsTouching(playerHeadCollider))
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
