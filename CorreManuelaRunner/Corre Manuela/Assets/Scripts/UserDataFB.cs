using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class UserDataFB
{
    public string userName;
    public float userScore;
    
    public UserDataFB(string name, float score)
    {
        userName = name;
        userScore = score;
    }
}
