using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

	// Update is called once per frame
	void Update () {
		this.transform.Translate (0f, speed* Time.deltaTime, 0f);
	}

	private void OnTriggerEnter2D(Collider2D other) {
        Destroy(this.gameObject);
    }
}
