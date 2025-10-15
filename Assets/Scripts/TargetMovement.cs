using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [SerializeField]
    public float HorizontalSpeed = 2f;
    [SerializeField]
    public float VerticalRowDistance = 1f;

    [SerializeField]
    public bool IsMovingRight = true;

    private void Update()
    {
        transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime * (IsMovingRight ? 1 : -1));
        if(IsMovingRight && transform.position.x > ShootingArea.Instance.AreaSize.x / 2)
        {
            IsMovingRight = false;
            transform.position = new Vector3(ShootingArea.Instance.AreaSize.x / 2, transform.position.y - VerticalRowDistance, transform.position.z);
        }
        else if(!IsMovingRight && transform.position.x < -ShootingArea.Instance.AreaSize.x / 2)
        {
            IsMovingRight = true;
            transform.position = new Vector3(-ShootingArea.Instance.AreaSize.x / 2, transform.position.y - VerticalRowDistance, transform.position.z);
        }

        if(transform.position.y < -ShootingArea.Instance.AreaSize.y / 2)
        {
            if (TryGetComponent<TargetDestruction>(out TargetDestruction destruction))
            {
                destruction.OutOfBounds();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
