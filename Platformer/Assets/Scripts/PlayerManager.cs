using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int deathCount;
    public int Score;
    public Vector3 spawnPos;
    public List<GameObject> respawnObjects;

	// Use this for initialization
	void Start ()
    {
        respawnObjects = new List<GameObject>();
        deathCount = 0;
        Score = 0;
	}
}
