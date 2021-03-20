using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	Player player;

	private Vector2 GetPlayerPos() => player.transform.position;

    void Start() {
        player = GameObject.FindObjectOfType<Player>();
    }

    void Update() {
        
    }
}
