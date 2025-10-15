using UnityEngine;

[CreateAssetMenu(fileName = "TargetFactory", menuName = "ScriptableObjects/TargetFactory", order = 1)]
public class TargetFactory : ScriptableObject
{
    [SerializeField]
    private GameObject _targetPrefab;
    [SerializeField]
    private float _speed = 2;
    [SerializeField]
    private float _verticalRowDistance = 2;
    [SerializeField]
    private Vector3 _scale = Vector3.one;

    [SerializeField]
    private int _points = 10;

    public GameObject ConstructTarget(Vector2 pos)
    {
        GameObject target = Instantiate(_targetPrefab, pos, Quaternion.identity);

        if(target.TryGetComponent<TargetMovement>(out TargetMovement movement))
        {
            movement.HorizontalSpeed = _speed;
            movement.VerticalRowDistance = _verticalRowDistance;
            movement.IsMovingRight = pos.x < 0;
        }

        if(target.TryGetComponent<TargetDestruction>(out TargetDestruction destruction))
        {
            destruction.Points = _points;
        }


        target.transform.localScale = _scale;

        return target;
    }
}
