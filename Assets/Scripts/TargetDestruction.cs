using UnityEngine;

public class TargetDestruction : MonoBehaviour
{
    public int Points = 10;
    
    public delegate void TargetDestroyedSignature(int points);
    public static event TargetDestroyedSignature OnTargetDestroyed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            OnTargetDestroyed?.Invoke(Points);
            Destroy(gameObject);
        }
    }

    public void OutOfBounds()
    {
        OnTargetDestroyed?.Invoke(-Points);
        Destroy(gameObject);
    }
}
