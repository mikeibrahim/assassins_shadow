using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	// References
	Camera cam;

	// Instance Fields
	private float speedMult = 5;
	Rigidbody2D rb;
	Vector2 velocity;

	//Getters
	private Vector2 GetVelocity() => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	private Vector2 GetMousePos() => cam.ScreenToWorldPoint(Input.mousePosition);

	//Functions
	private void Move() => rb.MovePosition(rb.position + velocity.normalized * speedMult * Time.deltaTime);
	private void Turn() {
		Vector2 lookDir = GetMousePos() - rb.position;
		float turnMagnitude = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = turnMagnitude;
	}

	// Unity Callbacks
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

	private void Start() {
		cam = GameObject.FindObjectOfType<Camera>();
	}

    private void Update() {
		velocity = GetVelocity();
    }

	private void FixedUpdate() {
		Move();
		Turn();
	}
}
