using UnityEngine;

public class FollowCameraSet : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Vector3 _offset;
    [SerializeField] [Range(0, 90f)] private float _angle;

    private void Awake() => Init();
    
    private void Init()
    {
        _cam = Camera.main;
    }

    private void LateUpdate()
    {
        SetPosition();
        SetRotation();
    }

    private void SetRotation()
    {
        _cam.transform.rotation = Quaternion.Euler(_angle, 0, 0);
    }

    private void SetPosition()
    {
        _cam.transform.position = transform.position + _offset;
    }
}
