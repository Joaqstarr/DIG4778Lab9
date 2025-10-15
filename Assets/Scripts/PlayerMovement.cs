using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _bulletCooldown = 0.5f;
    private float _bulletTimer = 0f;
    [SerializeField]
    private ObjectPool _bulletPool;


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


        _bulletTimer -= Time.deltaTime;

        if(Input.GetKey(KeyCode.Space) && _bulletTimer <= 0f)
        {
            GameObject bullet = _bulletPool.GetObject();
            bullet.transform.position = transform.position + Vector3.up * 0.5f;
            bullet.transform.rotation = Quaternion.identity;
            _bulletTimer = _bulletCooldown;
        }
    }
}
