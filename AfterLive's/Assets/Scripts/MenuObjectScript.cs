using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObjectScript : MonoBehaviour
{
    [SerializeField] private Vector3 _randomRotation;
    private void FixedUpdate()
    { 
        transform.Rotate(_randomRotation);
    }
}
