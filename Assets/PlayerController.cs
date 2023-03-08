using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _speed;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        MovementAndRotation();
    }

    private void MovementAndRotation()
    {
        _controller.Move(MoveVector());
        transform.rotation = MouseRotation();
    }


    private Vector3 MoveVector()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        return movement* _speed* Time.deltaTime;
    }

    private Quaternion MouseRotation()
    {
        Quaternion rotation = Quaternion.Euler(Mathf.Clamp(transform.rotation.x+Input.GetAxis("Mouse Y"),-355,355), Mathf.Clamp(transform.rotation.y+Input.GetAxis("Mouse X"),-90,90),0);
        return rotation;
    }
}
