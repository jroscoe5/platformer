using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public Collider2D DoorCollider;
    public GameObject Player;
    public PlayerManager PlayerManager;
    public AudioSource Audio;
    public Animator animator;
    public int level;

    public bool knocked;

    private Collider2D playerHeadCollider, playerFeetCollider;
    private void Start()
    {
        animator = GetComponent<Animator>();
        knocked = false;
        Player = GameObject.Find("Player");
        DoorCollider = GetComponent<Collider2D>();
        PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        playerHeadCollider = Player.GetComponent<BoxCollider2D>();
        playerFeetCollider = Player.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if ((DoorCollider.IsTouching(playerHeadCollider)
            || DoorCollider.IsTouching(playerFeetCollider)) &&
            Player.GetComponent<PlayerMovement>().knock == true)
        {
            SceneManager.LoadScene(level + 1);
            animator.SetBool("Knocked", true);
        }
    }
}
