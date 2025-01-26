using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject Pop;
    private void OnDestroy() {
        GetComponentInParent<EnemiesContainer>().WasEnemyDestroyed();
        Instantiate(Pop, this.transform.position + new Vector3(1,1,0), this.transform.rotation);
    }
}
