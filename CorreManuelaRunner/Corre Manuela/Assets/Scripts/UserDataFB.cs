using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataFB : MonoBehaviour
{
    public string userName;
    public float userScore;
    
    public UserDataFB(string name, float score)
    {
        userName = name;
        userScore = score;
    }
}
