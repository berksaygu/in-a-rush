using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        
        GameObject.Find("Player").SendMessage("Finish");
    }

}
