
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorPerder : MonoBehaviour
{
    Canvas canvas;
    public static ControladorPerder instance;
    public Text perderTexto;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        perderTexto = GameObject.Find("Perdiste").GetComponent<Text>();
        canvas = GameObject.Find("PerderScreen").GetComponent<Canvas>();
        canvas.enabled = false;
    }
    public void Perder()
    {
        perderTexto.text = Score.instance.setTextPerdiste();
        canvas.enabled = !canvas.enabled;
        Time.timeScale = (canvas.enabled) ? 0 : 1f;
    }
}
