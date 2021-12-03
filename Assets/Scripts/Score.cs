using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
   
    private int score;
    public static Score instance;
    public Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        score = 0;
        setText();
    }

    public void AumentarScore(int cantidad)
    {
        score += cantidad;
        setText();
    }

    public string setTextPerdiste()
    {
        return "PERDISTE CON: " + score + " PUNTOS";
    }

    public string setTextGanaste()
    {
        return "Score: " + score + " puntos";
    }

    private void setText()
    {
        scoreText.text = "Score: " + score;
    }

    
}
