using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text healthText;

    public static GameController instance;
    
    // Aweke é inicializado antes de todos os metodos start() do seu projeto 
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x " + value.ToString();
    }
    
}
