using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirJuego : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Salio del juego");
    }
}
