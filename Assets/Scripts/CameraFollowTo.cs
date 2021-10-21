using UnityEngine;

public class CameraFollowTo : MonoBehaviour
{
    [Header("Object for following")] 
    [SerializeField] private GameObject _gameObject;

    [Header("Camera propertys")] 
    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _heigth;
    [SerializeField] private float _rearDistance;

    private Vector3 _currentVector;

    private void Start()
    {
        transform.position = new Vector3(_gameObject.transform.position.x, _gameObject.transform.position.y + _heigth, _gameObject.transform.position.z - _rearDistance);
        transform.rotation = Quaternion.LookRotation(_gameObject.transform.position - transform.position);
    }

    private void LateUpdate()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        _currentVector = new Vector3(_gameObject.transform.position.x, _gameObject.transform.position.y + _heigth, _gameObject.transform.position.z - _rearDistance);
        transform.position = Vector3.Lerp(transform.position, _currentVector, _returnSpeed * Time.deltaTime);
    }
}

