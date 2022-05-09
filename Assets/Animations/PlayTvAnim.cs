using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTvAnim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator TV;

    [SerializeField] private string TvFall = "TvFall";


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TV.Play("TvFall", 0, 0.0f);
        }
    }

}