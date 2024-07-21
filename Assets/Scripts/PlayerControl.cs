using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float speed = 10.0f;
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        //if (gameObject.transform.position.x > 7)
        //    transform.position = new(7, -4, 0);
        //else if (gameObject.transform.position.x < -7)
        //    transform.position = new(-7, -4, 0);
        transform.Translate(horizontal * speed * Time.deltaTime * Vector3.down);
        transform.position = new(Mathf.Clamp(transform.position.x, -7, 7), transform.position.y, transform.position.z);
    }
}
