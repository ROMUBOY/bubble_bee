using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject PlayerDeath;    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Harzard"))
        {
            Transform camera = transform.Find("Main Camera");
            camera.SetParent(transform.parent);
            camera.gameObject.GetComponent<Camera>().enabled = true;
            Instantiate (PlayerDeath, this.transform.position, this.transform.rotation);

            Destroy(this.gameObject);
        }       
    }
}
