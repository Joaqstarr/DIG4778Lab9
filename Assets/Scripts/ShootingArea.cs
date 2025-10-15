using UnityEngine;

public class ShootingArea : MonoBehaviour
{
    private static ShootingArea _instance;
    public static ShootingArea Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<ShootingArea>();
                if(_instance == null)
                {
                    GameObject obj = new GameObject("ShootingArea");
                    _instance = obj.AddComponent<ShootingArea>();
                }
            }
            return _instance;
        }
    }

    [field: SerializeField]
    public Vector2 AreaSize { get; private set; } = new Vector2(10f, 5f);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(AreaSize.x, AreaSize.y, 0f));
    }

}
