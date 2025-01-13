using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    bool isJumping;
    public float JumpForce = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}