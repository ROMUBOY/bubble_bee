using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null)
			LookAt(player.transform);
	}

	void LookAt(Transform obj){
		float angle = Mathf.Atan2(obj.transform.position.x - this.transform.position.x, obj.transform.position.y - this.transform.position.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, -angle); 
	}
}