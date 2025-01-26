using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private void OnDestroy() {
        GetComponentInParent<EnemiesContainer>()?.WasEnemyDestroyed();
    }
}
