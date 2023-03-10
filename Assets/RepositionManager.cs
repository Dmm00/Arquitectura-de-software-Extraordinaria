using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionManager : MonoBehaviour
{
    [SerializeField] private Transform _oppositeCollider;
    [SerializeField] private Transform _box;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _box.transform.LookAt(_oppositeCollider);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            CubeBehaviour.canMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CubeBehaviour.canMove = false;
        }
    }
}
