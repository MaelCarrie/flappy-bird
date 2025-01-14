using UnityEngine;

public class Level : MonoBehaviour
{
    public float Speed = -5f;
    public float deadZone = -20f;
    Vector3 initPosition;

    private void Start()
    {
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0f);

        if(transform.position.x < deadZone)
        {
            transform.position = initPosition + new Vector3(5f, 0f);
        }
    }
}
