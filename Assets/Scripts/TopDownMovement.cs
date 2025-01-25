using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento
    public float dashSpeed = 20f; // Velocidade do dash
    public float dashDuration = 0.2f; // Tempo que o dash dura
    public float dashCooldown = 1f; // Tempo de recarga do dash em segundos

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 dashDirection;
    private bool isDashing;
    private float dashEndTime;
    private float lastDashTime;
    private float threshold = 0.1f;

    float auxMoveSpeed;

    void Start()
    {
        auxMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {  
        // Define a área de movimento
        DefineArea(GameObject.FindGameObjectWithTag("Area"));

        // Captura o input de movimento (WASD)
        if (!isDashing)
        {
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");

            // Normaliza o vetor para evitar movimento mais rápido em diagonais
            if (movementInput.magnitude > 1f)
            {
                movementInput.Normalize();
            }
        }

        // Dash com o botão direito do mouse
        if (Input.GetMouseButtonDown(1) && !isDashing && Time.time >= lastDashTime + dashCooldown)
        {
            StartDash();
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            // Move o personagem na direção do dash
            rb.velocity = dashDirection * dashSpeed;

            // Termina o dash após a duração
            if (Time.time >= dashEndTime)
            {
                EndDash();
            }
        }
        else
        {
            // Movimenta o personagem normalmente
            if (movementInput.magnitude > threshold)
                rb.velocity = movementInput * moveSpeed;
            else
                rb.velocity = Vector2.zero;
        }
    }

    private void StartDash()
    {
        // Obtém a posição do mouse no mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calcula a direção do dash
        dashDirection = (mousePosition - transform.position).normalized;

        // Ativa o dash
        isDashing = true;
        dashEndTime = Time.time + dashDuration;
        lastDashTime = Time.time;
    }

    private void EndDash()
    {
        isDashing = false;
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDashing && collision.gameObject.CompareTag("Block"))
        {
            // Calcula a direção do ricochete usando a normal da colisão
            Vector2 normal = collision.contacts[0].normal;
            dashDirection = Vector2.Reflect(dashDirection, normal);

            // Atualiza a velocidade do Rigidbody para continuar o dash na nova direção
            rb.velocity = dashDirection * dashSpeed;
        }
    }

    private void DefineArea(GameObject Area)
    {
        if (!Area) return;
        if (Vector2.Distance(gameObject.transform.position,Area.transform.position) > (Area.transform.localScale.x/2))
        {
            moveSpeed = 0f;
        }
        else
        {
            moveSpeed = auxMoveSpeed; 
        }
    }
}