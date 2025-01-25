using UnityEngine;

public class DestroyOnHazardTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Harzard"))
        {
            Destroy(this.gameObject);
        }       
    }
}
