using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public Collider2D CoinCollider;
    public GameObject Player;
    public PlayerManager PlayerManager;
    public TextMeshProUGUI Score;

    private Collider2D playerHeadCollider, playerFeetCollider;
    private void Start()
    {
        Player = GameObject.Find("Player");
        CoinCollider = this.GetComponent<Collider2D>();
        PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        Score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        playerHeadCollider = Player.GetComponent<BoxCollider2D>();
        playerFeetCollider = Player.GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CoinCollider.IsTouching(playerHeadCollider)
            || CoinCollider.IsTouching(playerFeetCollider))
        {
            this.gameObject.SetActive(false);
            PlayerManager.respawnObjects.Add(this.gameObject);
            ModifyScore();
        }
    }

    private void ModifyScore()
    {
        Score.text = (Random.Range(0,10) == 0)? (--PlayerManager.Score).ToString(): (++PlayerManager.Score).ToString();
    }
}
