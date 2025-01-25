using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

	// Update is called once per frame
	void Update () {
		this.transform.Translate (0f, speed* Time.deltaTime, 0f);
	}
}
