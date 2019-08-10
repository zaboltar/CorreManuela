using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class RankingsManager : MonoBehaviour
{
    public List<GameObject> rankingList = new List<GameObject>(10);
    public List<GameObject> rankingListScores = new List<GameObject>(10);

    public GameObject[] userScores;
    public string usersRoute;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void getAllUserScores()
    {

        FirebaseDatabase.DefaultInstance
          .GetReference("userScores")
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  // Handle the error...
                  Debug.Log("upsi");
              }
              else if (task.IsCompleted)
              {
                  DataSnapshot snapshot = task.Result;
                  // Do something with snapshot...
                  var i = 0;
                  foreach (var childSnapshot in snapshot.Children)
                  {
                      var name = childSnapshot.Child("userName").Value.ToString();
                      var score = childSnapshot.Child("userScore").Value.ToString();
                      
                     
                      i++;
                  }



              }
          });

    }

    
}
