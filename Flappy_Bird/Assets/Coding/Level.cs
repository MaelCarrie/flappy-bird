using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    public float speed = -5f;
    public float deadZone = -25f;
    public float waitTime = 2f; // Par exemple, attendre 2 secondes
    public Vector3 initPosition;
    private bool canMove = false; // Flag pour savoir si l'objet peut bouger

    void Start()
    {
        initPosition = transform.position;
        transform.position = new Vector3(transform.position.x, Random.Range(0f, 5f), transform.position.z);
        StartCoroutine(WaitAndEnableMovement());
    }

    IEnumerator WaitAndEnableMovement()
    {
        yield return new WaitForSeconds(waitTime); // Attend la durée spécifiée
        canMove = true; // Autorise le mouvement après l'attente
    }

    void Update()
    {
        if (canMove) // Déplace seulement si autorisé
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f);
            if (transform.position.x < deadZone)
            {
                transform.position = initPosition;
                transform.position = new Vector3(transform.position.x, Random.Range(0f, 5f), transform.position.z);
            }
        }
    }
}