using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject PlayerDeath;
    private void OnDestroy() {
        Transform camera = transform.Find("Main Camera");
        camera.SetParent(transform.parent);
        camera.gameObject.GetComponent<Camera>().enabled = true;
        Instantiate (PlayerDeath, this.transform.position, this.transform.rotation);
    }
}
