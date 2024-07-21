using UnityEngine;

public class AiControl : MonoBehaviour
{
    private BallControl ballControl;
    private float speed = 8.0f;
    private void Start()
    {
        ballControl = GameObject.FindWithTag("Ball").GetComponent<BallControl>();
    }
    void Update()
    {
        if (ballControl.newPosition.y == 4)
        { 
            transform.position = Vector3.MoveTowards(transform.position, new(Mathf.Clamp(ballControl.newPosition.x, -7, 7), transform.position.y, transform.position.z), Time.deltaTime * speed);
        }
    }
}
