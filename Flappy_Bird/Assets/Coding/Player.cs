using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    bool isJumping;
    public float JumpForce = 250f;
    public float TiltSpeed = 10f; // Augmenté pour que l'oiseau s'incline plus rapidement
    public float MaxTiltUp = 30f; // Inclinaison maximale vers le haut
    public float MaxTiltDown = -60f; // Inclinaison maximale vers le bas
    public float TiltMultiplier = 2f; // Facteur d'influence plus fort pour rendre l'inclinaison plus rapide

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y > 5.5f)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            Rigidbody.AddForce(new Vector2(0f, JumpForce));
            isJumping = false;
        }

        // Ajuste l'inclinaison de l'oiseau en fonction de sa vitesse verticale
        AdjustTilt();
    }

    private void AdjustTilt()
    {
        // Obtenir la vitesse verticale du Rigidbody
        float verticalVelocity = Rigidbody.linearVelocity.y;

        // Calculer l'inclinaison en fonction de la vitesse verticale
        // On multiplie la vitesse par TiltMultiplier pour accélérer l'inclinaison
        float tiltSpeed = Mathf.Abs(verticalVelocity) * TiltMultiplier;

        // Calculer l'angle d'inclinaison en fonction de la vitesse
        float targetAngle = Mathf.Clamp(verticalVelocity * TiltMultiplier, MaxTiltDown, MaxTiltUp);

        // Appliquer une rotation lissée avec une vitesse d'inclinaison plus rapide
        float smoothAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, tiltSpeed * Time.fixedDeltaTime);
        transform.eulerAngles = new Vector3(0f, 0f, smoothAngle);
    }
}
