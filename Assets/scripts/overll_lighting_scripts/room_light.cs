using UnityEngine;
using System.Collections;

public class room_light : MonoBehaviour {

	public float opacity = 0.4f;
	public float visibility_shift = 0.2f;

	void OnTriggerEnter2D(Collider2D coll){
		coll.gameObject.GetComponent<move_player> ().set_room_visibility_shift (visibility_shift);
		Debug.Log ("trigger enter");
	}

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, opacity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
