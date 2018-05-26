using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
   
    public void _Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // włączamy ten sam poziom raz jeszcze
    }
}
