using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPausa : MonoBehaviour
{
    Canvas canvas;

    private void Start()
    {
        canvas = GameObject.Find("PausaScreen").GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void Pausa()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = (canvas.enabled) ? 0 : 1f;
    }
}
