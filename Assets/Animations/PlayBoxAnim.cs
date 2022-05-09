using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBoxAnim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator Box;

    [SerializeField] private string Fall = "Fall";


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Box.Play("Fall", 0, 0.0f);



        }


    }
}
