using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{

    [SerializeField] private Animator Bus;


   [SerializeField] private string Move = "Move";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Bus.Play("Move",0,0.0f);



        }
    }
 
    
}