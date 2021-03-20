using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour {
	private static int TOP = 0, RIGHT = 1, DOWN = 2, LEFT = 3; // a key to easily read code
	[SerializeField] private Room room;
	List<Vector2> spawns = new List<Vector2>(); // Keep track of spawns
	private int minRooms = 6, maxRooms = 12; // Clamping the number of rooms
	private int minRoomSize = 5, maxRoomSize = 10;
	private int gridSize = 50;

	// Initiates the spawn sequence
	private void GenerateSpawns() {
		CreateRoom(Vector2.zero, 5, Vector2.zero); // main spawn room with default size
		spawns.Add(Vector2.zero);
	}

	// Gets called into each individual room to get split into 4 possible rooms
	private IEnumerator Branch(Vector2 pos) {
		for (int i = 0; i < 4; i++) { // 4 possible rooms
			yield return new WaitForSeconds(0.01f);
			if (spawns.Count > maxRooms) { yield break; }

			if (Random.Range(0, 2) == 0 || spawns.Count < minRooms) { // 50:50 chance to add a room in that direction
				int yMult = 0;
				int xMult = 0;
				if (i == TOP) { // TOP
					yMult = 1;
				} else if (i == RIGHT) {  // RIGHT
					xMult = 1;
				} else if (i == DOWN) { // DOWN
					yMult = -1;
				} else if (i == LEFT) { // LEFT
					xMult = -1;
				}

				int size = Random.Range(minRoomSize, maxRoomSize + 1); // Generates a random size within the constraints 
				Vector2 spawnPoint = new Vector2(pos.x + gridSize * xMult, pos.y + gridSize * yMult);

				// if there are no duplicates
				if (!spawns.Contains(spawnPoint)) {
					spawns.Add(spawnPoint);
					CreateRoom(spawnPoint, size, pos);
				} else {
					// have a chance to branch together
				}
			}
		}
	}

	// Creates the physical rooms
	private void CreateRoom(Vector2 pos, int size, Vector2 connectionPos) {
		Room r = Instantiate(room, pos, Quaternion.identity); // creating the room
		r.SetDimensions(size, size); // sets the size
		r.ConnectTo(connectionPos); // where to connect

		// Branch into another room
		StartCoroutine(Branch(pos));
	}

	// Unity Callbacks
	private void Start() {
		GenerateSpawns();
	}
}