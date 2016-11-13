using UnityEngine;
using System.Collections;

public class fog_controller : MonoBehaviour {

	public float min_x = 10f;
	public float min_y = -50f;
	public float max_x = 30f;
	public float max_y = 10f;


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 0.5f);
		gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "fog";
		gameObject.transform.position.x = Random.Range (min_x, max_x);
		gameObject.transform.position.y = Random.Range (min_y, max_y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
