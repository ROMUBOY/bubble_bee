using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject PlayerDeath;
    public GameObject Pop;
    private void OnDestroy() {
        Transform camera = transform.Find("Main Camera");
        camera.SetParent(transform.parent);
        camera.gameObject.GetComponent<Camera>().enabled = true;
        Instantiate (PlayerDeath, this.transform.position, this.transform.rotation);
        Instantiate(Pop, this.transform.position + new Vector3(1, 1, 0), this.transform.rotation);
    }
}
