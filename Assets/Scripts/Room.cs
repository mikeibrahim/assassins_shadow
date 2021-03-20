using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	private static int TOP = 0, RIGHT = 1, DOWN = 2, LEFT = 3; // a key to easily access the array values
	[SerializeField] private GameObject floorTile;

	bool[] connections = new bool[] { false, false, false, false }; // array of conenctions
	int width, height; // dimentions of room

	public void SetDimensions(int width, int height) {
		this.width = width;
		this.height = height;
		CreateRoom();
	}

	public void ConnectTo(Vector2 connctionPos) {
		// overlap circle to find the room
		Collider2D[] cols = Physics2D.OverlapCircleAll(connctionPos, 1);
		Room r = null;
		// Getting room component
		foreach (Collider2D col in cols) {
			if (col.GetComponent<Room>()) {
				r = col.GetComponent<Room>();
			}
		}
		
		// get dimensions
		// add floor tiles
	}

	private void CreateRoom() {
		CreateFloor();
		CreateWalls();
	}

	// Creates the floorTiles that the player can walk on
	private void CreateFloor() {
		for (int x = -width; x <= width; x++) {
			for (int y = -height; y <= height; y++) {
				Vector2 floorTilePos = new Vector2(transform.position.x + x, transform.position.y + y);
				GameObject t = Instantiate(floorTile, floorTilePos, Quaternion.identity);
				t.transform.SetParent(transform);
			}
		}
	}

	// Creates the wallTiles that the player is blocked by
	private void CreateWalls() {
		// for (int x = -width; x <= width; x++) {
		// 	for (int y = -height; y <= height; y++) {
				
		// 	}
		// }
		print("Made walls");
	}
}