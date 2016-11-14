using UnityEngine;
using System.Collections;

public class fog_controller : MonoBehaviour {

	private float min_x = 10f;
	private float min_y = -50f;
	private float max_x = 30f;
	private float max_y = 10f;
	private Vector2 direction;
	private float velocity = 0.75f;
	private float velocity_shift;


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 0.5f);
		gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "fog";
		gameObject.transform.position.Set (Random.Range (min_x, (max_x - min_x) / 2), Random.Range (min_y, (max_y - min_y) / 2), -1f);
		direction = new Vector2 (Random.Range (0.5f, 1f), Random.Range (0.5f, 1f)).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		velocity_shift = Mathf.Sin (Time.fixedTime / 6f) * 0.5f;
		gameObject.transform.Translate (direction * (velocity + velocity_shift) * Time.deltaTime);
		//Debug.Log ((velocity + velocity_shift));

		if (gameObject.transform.position.x >= max_x) {
			gameObject.transform.position.Set (max_x, gameObject.transform.position.y, gameObject.transform.position.z);
			direction.Set (-direction.x, direction.y);
		}
		if (gameObject.transform.position.y >= max_y) {
			gameObject.transform.position.Set (gameObject.transform.position.x, max_y, gameObject.transform.position.z);
			direction.Set (direction.x, -direction.y);
		}
		if (gameObject.transform.position.x <= min_x) {
			gameObject.transform.position.Set (min_x, gameObject.transform.position.y, gameObject.transform.position.z);
			direction.Set (-direction.x, direction.y);
		}
		if (gameObject.transform.position.y <= min_y) {
			gameObject.transform.position.Set (gameObject.transform.position.x, min_y, gameObject.transform.position.z);
			direction.Set (direction.x, -direction.y);
		}
	}
}
