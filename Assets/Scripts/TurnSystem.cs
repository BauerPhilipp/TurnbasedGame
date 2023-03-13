using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    public static TurnSystem Instance { get; private set; }
    private int turnNumber = 1;

    public event EventHandler OnTurnChanged;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mehrere Instanzen von TurnSystem verf�gbar! Objekt wird gel�scht");
            Destroy(gameObject);
            return;
        }
    }

    public int GetTurnNumber() { return turnNumber; }


    public void NextTurn()
    {
        turnNumber++;
        OnTurnChanged?.Invoke(this, new EventArgs());
    }
}
