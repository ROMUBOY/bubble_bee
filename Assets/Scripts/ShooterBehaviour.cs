using UnityEngine;

public class ShooterBehaviour : MonoBehaviour {

	public float startTime;

	public float frequency;

	public Transform bullet;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Shoot",startTime, frequency);
	}

	void Shoot(){
		Instantiate (bullet, this.transform.position, this.transform.rotation);
	}
}