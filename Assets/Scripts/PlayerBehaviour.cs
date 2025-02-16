using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject PlayerDeath;
    [SerializeField] GameObject dialogue;
    [SerializeField] GameObject Pop;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Harzard"))
        {
            Transform camera = transform.Find("Main Camera");
            camera.SetParent(transform.parent);
            camera.gameObject.GetComponent<Camera>().enabled = true;
            Instantiate (PlayerDeath, this.transform.position, this.transform.rotation);

            var dialogues = FindObjectsOfType<DialogueSetup>();

            foreach (var dialog in dialogues)
            {
                if (dialog.isActiveAndEnabled)
                {
                    dialog.gameObject.SetActive(false);
                }
            }

            dialogue.SetActive(true);
            dialogue.transform.parent = transform.parent;
            
            Instantiate(Pop, this.transform.position + new Vector3(0, 1, 0), this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
