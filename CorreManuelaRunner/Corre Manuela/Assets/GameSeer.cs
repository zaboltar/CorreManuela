using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSeer : MonoBehaviour
{
    public InputField usuarioNombre;
    public Text usuarioText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveUserName (string txt)
    {
              
        PlayerPrefs.SetString("userName", txt);
        Debug.Log(txt);
    }
}
