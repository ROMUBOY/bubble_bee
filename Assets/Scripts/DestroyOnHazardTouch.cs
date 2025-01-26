using UnityEngine;

public class DestroyOnHazardTouch : MonoBehaviour
{
    public GameObject Pop;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Harzard"))
        {
            Instantiate(Pop, this.transform.position + new Vector3(0,1,0), this.transform.rotation);
            Destroy(this.gameObject);
        }       
    }
}
