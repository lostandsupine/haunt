using UnityEngine;
using System.Collections;

public class foreground_controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 0.4f);
		gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "foreground";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
