using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test4Failed : MonoBehaviour
{
    [SerializeField] private LevelComplete _levelComplete;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
        _levelComplete.CriticalError();
        }
    }
}
