using UnityEngine;

public class Scorer : MonoBehaviour
{
    GameManager Manager;

    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player _player = collision.gameObject.GetComponent<Player>();
        if(_player != null)
        {
            Manager.addScore();
        }
    }
}
