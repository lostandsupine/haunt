using UnityEngine;
using System.Collections;

public class input_manager : MonoBehaviour {

	public static bool is_paused = false;
	private bool pause_down = false;
	private float velocity = 2f;
	private Vector2 current_direction = new Vector2(0f,0f);
	private Vector2 last_direction = new Vector2(0f,-1f);

	void Start () {

	}

	public Vector2 get_direction(){
		return(last_direction);
	}

	void FixedUpdate () {
		if((Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.JoystickButton7)) && !pause_down)
		{
			Application.Quit ();
			Time.timeScale = 1.0f - Time.timeScale;
			is_paused = !is_paused;
			pause_down = true;
		}
		float move_x = 0;
		float move_y = 0;
		pause_down = Input.GetKey (KeyCode.Escape) || Input.GetKey (KeyCode.JoystickButton7);

		if (!is_paused) {

			if (!is_paused && (Input.GetKey (KeyCode.DownArrow))) {
				move_y--;
			}
			if (!is_paused  && (Input.GetKey (KeyCode.LeftArrow))) {
				move_x--;
			}
			if (!is_paused && (Input.GetKey (KeyCode.UpArrow))) {
				move_y++;
			}
			if (!is_paused && (Input.GetKey (KeyCode.RightArrow))) {
				move_x++;
			}

			if (Input.GetKey (KeyCode.LeftControl)) {
				GameObject.Find ("ghost").GetComponent<move_player> ().set_move_type (move_player.move_type.creep);
			} else if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey(KeyCode.Space)) {
				Debug.Log ("Send Dashing");
				GameObject.Find ("ghost").GetComponent<move_player> ().set_move_type (move_player.move_type.dash);
			} else {
				GameObject.Find ("ghost").GetComponent<move_player> ().set_move_type (move_player.move_type.normal);
			}

			if (move_x != 0 && move_y == 0) {
				GameObject.Find ("ghost").GetComponent<move_player> ().move (2 + (int)move_x);
			} else if (move_x == 0 && move_y != 0) {
				GameObject.Find ("ghost").GetComponent<move_player> ().move (1 + (int)move_y);
			} else if (move_x != 0 && move_y != 0) {
				GameObject.Find ("ghost").GetComponent<move_player> ().move (1 + (int)move_y, 1.414214f);
				GameObject.Find ("ghost").GetComponent<move_player> ().move (2 + (int)move_x, 1.414214f);
			} else if (GameObject.Find ("ghost").GetComponent<move_player> ().get_move_type() != move_player.move_type.dash){
				GameObject.Find ("ghost").GetComponent<move_player> ().set_move_type (move_player.move_type.still);
			}

			current_direction = new Vector2 (move_x, move_y);
			if (current_direction.magnitude > 0) {
				last_direction = current_direction;
			}


		}
	}
}
