using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int deathCount;
    public int Score;
    public Vector3 spawnPos;
    public GameObject Player;

	// Use this for initialization
	void Start ()
    {
        Player.SetActive(false);
        Player.transform.position = spawnPos;
        Player.SetActive(true);
        deathCount = 0;
        Score = 0;
	}
}
