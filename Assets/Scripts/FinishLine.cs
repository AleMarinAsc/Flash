using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    Canvas canvas;
    public static ControladorPerder instance;
    public Text ganarTexto;

    private void Start()
    {
        ganarTexto = GameObject.Find("ScoreGanar").GetComponent<Text>();
        canvas = GameObject.Find("GanarScreen").GetComponent<Canvas>();
        canvas.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ganarTexto.text = Score.instance.setTextGanaste();
            canvas.enabled = !canvas.enabled;
            Time.timeScale = (canvas.enabled) ? 0 : 1f;
        }
    }
}
