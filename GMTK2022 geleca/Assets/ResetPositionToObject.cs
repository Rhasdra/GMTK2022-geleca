using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionToObject : MonoBehaviour
{
    [SerializeField] Transform otherObj;

    private void Update() {
        transform.position = otherObj.position;
    }
}
