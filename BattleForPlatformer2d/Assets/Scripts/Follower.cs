using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform _hunted;

    private void LateUpdate()
    {
        transform.position = new Vector3(_hunted.position.x, transform.position.y, transform.position.z);
    }
}
