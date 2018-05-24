using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour {

	public Text tCount; //tekst z wartością punktową

	// Update is called once per frame
	void Update () {
		tCount.text = Input.touchCount.ToString (); //zbieramy ilość kliknięć w ekran i zmieniamy ją w ciąg znaków  (string)
	}
}
