using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _contact;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) 
        {
            _contact.Play();
        }
        else if (collision.gameObject.CompareTag("Train") || collision.gameObject.CompareTag("Floor"))
        {
            _contact.Play();
        }
    }
}
