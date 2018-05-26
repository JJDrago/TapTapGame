using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

	Image PasekCzasu;       //grafika paska
	public float maxTime = 10f;	//maksymalny czas do ustawienia w inspektorze
	float timeLeft = 20f;		// pozostały czas, większy niż maksymalny żeby nie zaczął spadać podczas odliczania
	public GameObject menu; //Canvas z interfejsem
    public bool granie; //okreslenie czy można zdobywać punkty
  

    public Licznik _Licznik; //funkcja ze skryptu Licznik
    public Text odliczanie; //Tekst odliczania
    

	// Use this for initialization

	void Start () {
        granie = false;
       Time.timeScale = 1;     //czas nie płynie żeby pasek nie spadał i nie dało się zbieać punktów podczas odliczania
        menu.SetActive(false);  // interfejs z opcjami i rekordem jest schowany
        PasekCzasu = GetComponent<Image>(); //ustawiamy pasek        
        StartCoroutine(Countdown(3)); //korutyna z odliczaniem       
    }

    // Update is called once per frame
    void FixedUpdate() //uniezależniamy czas od ilości klatek na sekundę
    {           
        if (timeLeft > 0)   //Zanim czas się skończy
        {           
            timeLeft -= Time.deltaTime;  //odejmujemy upływająco czas
            PasekCzasu.fillAmount = timeLeft / maxTime; // zapełnienie paska równa się pozostałemu czasowi (czyli spada)
        }
        else
        {
            granie = false; //blokujemy zdobywanie punktów
            menu.SetActive(true); //włączamy wynik i opcje na ekranie           
            _Licznik.Rekord();      //wywołujemy funkcję ze skryptu Licznik
        }

    }

    IEnumerator Countdown(int seconds)  //korutynka do odliczania startowego, możemy wstawić sobie ile odliczanie ma trwać sekund
    {

        int count = seconds;    //zmienna do trzymania ilości sekund

        while (count > 0)       //pętelka odliczająca co sekundę
        {
            odliczanie.text = count.ToString();     //teskt do wyświetlenia to pozostałe sekundy

            yield return new WaitForSeconds(1);     //czekamy sekundę   
            count--;                                //odejmujemy ją 
            if (count == 0)                         // No i na zerze
            {
                odliczanie.text = "GO!";            //wyświetlamy "GO!"
                yield return new WaitForSeconds(1); //Czekamy
                odliczanie.text = "";               //i usuwamy napis z ekranu
            }
        }        
        timeLeft = maxTime; //dopiero po wykonaniu odliczania ustawiamy właściwe dziesięć sekund na klikanie
        granie = true;
    }




}
