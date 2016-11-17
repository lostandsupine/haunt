using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class move_player : MonoBehaviour {

	public Sprite[] sprite_list;
	private int direction = 0;
	private int current_frame = 0;
	public enum move_type {
		still,
		creep,
		normal,
		dash
	}
	public move_type moving;
	private Dictionary<move_type,float> move_type_velocity_dict = new Dictionary<move_type,float>(){
		{move_type.still, 0f},
		{move_type.creep, 1f},
		{move_type.normal, 2f},
		{move_type.dash, 6f}
	};
	private Dictionary<move_type,float> move_type_visibility_dict = new Dictionary<move_type,float>(){
		{move_type.still, 0.05f},
		{move_type.creep, 0.1f},
		{move_type.normal, 0.2f},
		{move_type.dash, 1f}
	};

	private float velocity;
	public float visibility;
	private float min_visibilty;
	private float dash_stamina = 2f;
	private float dash_time;
	public bool recovering = false;
	private float recover_visibility = 0.2f;
	private float room_visibility_shift = 0.0f;

	public void set_room_visibility_shift(float shift_in){
		room_visibility_shift = shift_in;
	}

	public void set_move_type(move_type move_type_in){
		
		if (moving != move_type.dash & move_type_in == move_type.dash & !recovering) {
			// if NOT dashing, and NOT recovering, start dashing
			dash_time = Time.time;
			moving = move_type.dash;
		} else if (moving == move_type.dash & !recovering) {
			// if dashing currently, and not recovering, continue dashing
			moving = move_type.dash;
		} else if (recovering & move_type_in == move_type.dash) {
			moving = move_type.normal;
		} else {
			// otherwise do whatever the inputed movement type is
			moving = move_type_in;
		}
	}

	public bool get_recovering(){
		return (recovering);
	}

	public move_type get_move_type(){
		return moving;
	}
		
	void fade_visibility(){
		move_type_visibility_dict.TryGetValue (moving, out min_visibilty);
		visibility = Mathf.Max (0f, Mathf.Max (min_visibilty, visibility - Time.fixedDeltaTime * 0.2f) - room_visibility_shift);
		gameObject.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, visibility);
	}

	void Start () {
		moving = move_type.still;
		visibility = 0f;
	}

	public void move(int in_direction, float attenuate = 1f){
		direction = in_direction;
		move_type_velocity_dict.TryGetValue (moving, out velocity);
		switch (in_direction) {
		case 0:
			this.transform.Translate ((Vector3.down * velocity) * Time.deltaTime / attenuate);
			break;
		case 1:
			this.transform.Translate ((Vector3.left * velocity) * Time.deltaTime / attenuate);
			break;
		case 2:
			this.transform.Translate ((Vector3.up * velocity) * Time.deltaTime / attenuate);
			break;
		case 3:
			this.transform.Translate ((Vector3.right * velocity) * Time.deltaTime / attenuate);
			break;
		}
	}

	void Update () {

		if (moving == move_type.dash & Time.time - dash_time >= dash_stamina) {
			recovering = true;
			Debug.Log ("start recovering");
		}
		if (recovering & visibility <= recover_visibility) {
			recovering = false;
			Debug.Log ("end recovering");
		}

		fade_visibility ();

		GetComponent<SpriteRenderer> ().flipX = false;

		if (moving != move_type.still) {
			switch (direction) {
			case 0:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [0 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				break;
			case 1:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [0 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				break;
			case 2:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [0 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				break;
			case 3:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [0+ current_frame];
				GetComponent<SpriteRenderer> ().flipX = true;
				current_frame = (int)((3 * Time.fixedTime) % 2);
				break;
			}

		} else {
			switch (direction) {
			case 0:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [0];
				break;
			case 1:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [0];
				break;
			case 2:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [0];
				break;
			case 3:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [0];
				GetComponent<SpriteRenderer> ().flipX = true;
				break;
			}

		}
	}
}
