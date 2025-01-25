using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    public float targetAspect = 16f / 9f; // Exemplo: proporção 16:9

    void Start()
    {
        // Calcular a proporção atual
        float windowAspect = (float)Screen.width / Screen.height;

        // Relacionar a proporção atual com a desejada
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            // Adicionar letterbox (barras pretas nas laterais)
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            // Adicionar pillarbox (barras pretas no topo/inferior)
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}
