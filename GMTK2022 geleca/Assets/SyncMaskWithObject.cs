using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncMaskWithObject : MonoBehaviour
{
    [SerializeField] Transform otherObj;
    [SerializeField] Transform mask;
    [SerializeField] Transform child;
    [SerializeField] Transform anchor;

    Transform oldPos;

    private void Update() 
    {
        transform.position = otherObj.position;
        child.position = anchor.position;
    }
}
