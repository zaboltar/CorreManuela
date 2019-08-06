using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpikeMeowthing : MonoBehaviour
{
    public AudioSource catUltiSFX;
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            catUltiSFX.Play();
        } 
    }
}
