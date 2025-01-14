using UnityEngine;

public class Tuyau : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player _player = collision.gameObject.GetComponent<Player>();
        if (_player != null)
        {
            _player.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().killPlayer();
        }
    }
}
