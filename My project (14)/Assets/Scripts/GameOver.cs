using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI mejor;
    public TextMeshProUGUI actual;
    private int puntajeActual;
    private int puntajeMax;
    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetText(){
        puntajeActual = PlayerPrefs.GetInt("puntajeActual");
        puntajeMax = PlayerPrefs.GetInt("puntajeMax");
        mejor.text = "El mejor puntaje es " + puntajeMax.ToString();
        actual.text = "Tu ultimo puntaje es " + puntajeActual.ToString();
    }
}
