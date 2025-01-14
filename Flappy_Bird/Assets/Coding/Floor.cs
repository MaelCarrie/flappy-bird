using UnityEngine;

public class Floor : MonoBehaviour
{
    public float Speed = -5f;
    public float deadZone = -13f;
    Vector3 initPosition;

    private void Start()
    {
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0f);

        if (transform.position.x < deadZone)
        {
            transform.position = initPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player _player = collision.gameObject.GetComponent<Player>();
        if(_player != null)
        {
            _player.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().killPlayer();
        }
    }
}
