using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSFXer : MonoBehaviour
{
    public AudioSource pwrUp;


    void   OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "PowerUp")
        {
            pwrUp.Play();
        }  
    }
}
