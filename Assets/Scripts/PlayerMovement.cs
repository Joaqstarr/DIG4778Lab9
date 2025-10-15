using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 5f;
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
    
        transform.Translate(Vector3.right * input * _speed * Time.deltaTime);

        if(transform.position.x < ShootingArea.Instance.AreaSize.x / -2)
        {
            transform.position = new Vector3(ShootingArea.Instance.AreaSize.x / 2, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > ShootingArea.Instance.AreaSize.x / 2)
        {
            transform.position = new Vector3(ShootingArea.Instance.AreaSize.x / -2, transform.position.y, transform.position.z);
        }
    }
}
