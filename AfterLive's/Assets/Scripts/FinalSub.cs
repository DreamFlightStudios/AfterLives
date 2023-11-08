using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSub : MonoBehaviour
{
    [SerializeField] private TMP_Text _sub;
    [SerializeField] private string[] _subText;
    bool a=false;
    bool b=false;
    bool c=false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InvokeRepeating("Sub", 0, 17);
    }

    private void Sub ()
    {
        if (!a)
        {
            _sub.text = _subText[0];
            a = true;
        }
        else if (!b)
        {
            _sub.text = _subText[1];
            b = true;
        }
        else if (!c)
        {
            _sub.text = _subText[2];
            c = true;
        }
        else
        {
            _sub.text = "";
            Invoke("LS", 60);
        }
    }
    private void LS()
    {
        SceneManager.LoadScene(0);
    }
}
