using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject _target;
    void LateUpdate()
    {
        transform.position = _target.transform.position + new Vector3(0, 1F, -5);
    }
}
