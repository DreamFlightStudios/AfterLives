using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetect : MonoBehaviour
{
    bool _isTrigger;
    [SerializeField] private FirstPersonController FirstPersonController;
    private void Start()
    {
        FirstPersonController.GetComponent<FirstPersonController>();
    }
    private void OnTriggerStay(Collider other)
    {
        _isTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _isTrigger = false;
    }
    private void Update()
    {
        FirstPersonController.GetComponent<FirstPersonController>().isGround = _isTrigger;
    }
}
