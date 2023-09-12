using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMovement : MonoBehaviour
{

    [Header("Settings")]
    [Tooltip("Скорость передвижения камеры")]
    public float _speed = 1;
    //[Tooltip("Доступный радиус перемещения камеры")]
    //public float _radius = 10;
    [Tooltip("Точка от которой считается доступный радиус перемещения камеры (если она не задана в инспекторе, то по умолчанию он определяется как компонент, на котором находится сценарий)")]
    public Transform _target;
    
    private Touch _touch;
    private Vector3 _targetPos;
    public float speedRotation = 15;
    public GameObject car;

    private void Start()
    {
        if (_target == null)
        {
            _target = this.transform;
        }
        _targetPos = _target.localEulerAngles;
    }

    private void Update()
    {
       
        transform.Rotate(0, speedRotation * Time.deltaTime, 0);

        if (Input.touchCount == 1)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                Vector3 movePos = new Vector3(
                    transform.localEulerAngles.x,
                    transform.localEulerAngles.y +_touch.deltaPosition.x * _speed * -1 * Time.deltaTime,
                    transform.localEulerAngles.z);

                Vector3 distance = movePos - _targetPos;

                //if (distance.magnitude < _radius)
                    transform.localEulerAngles = movePos;
            }
        }
    }
}
