using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeEnergia : MonoBehaviour
{
    public Image energia;
    private int energiaMaxima = 100;
    private WaitForSeconds regeneracion = new WaitForSeconds(.01f);
    private Coroutine regenerar = null;

    public static BarraDeEnergia instance;
    public float energiaActual;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        energiaActual = energiaMaxima;
        energia.fillAmount = energiaMaxima;
    }

    public void UsarEnergia(float cantidad)
    {
        if(energiaActual > 0)
        {
            energiaActual -= cantidad;
            energia.fillAmount = energiaActual / energiaMaxima;

            if(regenerar == null)
            {
                regenerar = StartCoroutine(Descanso());
            }
            else
            {
                StopCoroutine(Descanso());
            }
        }
    }

    public IEnumerator Descanso()
    {
        yield return new WaitForSeconds(3);

        while (energiaActual <= energiaMaxima)
        {
            energiaActual += 0.06f;
            energia.fillAmount = energiaActual / energiaMaxima;
            yield return regeneracion;
        }
        regenerar = null;
    }
}
