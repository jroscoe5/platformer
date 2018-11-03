using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillOnContact : MonoBehaviour
{

    public Collider2D KillTilesCollider;
    public GameObject Player;
    public GameObject PlayerManager;
    public TextMeshProUGUI DeathCounter;

    private Collider2D playerFeetCollider, playerHeadCollider;

    private int killCount;
    bool playerAlive;

    // Use this for initialization
    void Start()
    {
        playerAlive = true;
        killCount = 0;
        playerFeetCollider = Player.GetComponent<CircleCollider2D>();
        playerHeadCollider = Player.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((KillTilesCollider.IsTouching(playerHeadCollider)
            || KillTilesCollider.IsTouching(playerFeetCollider)) && playerAlive)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        playerAlive = false;
        // Increment death count
        DeathCounter.text = (++killCount).ToString();
        // Reset player
        Player.transform.position = new Vector3(24.63f, 15.23f, 0f);
        playerAlive = true;
    }
}
