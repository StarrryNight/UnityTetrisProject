using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{

    public string selection = "random";
    public GameObject Panel;

    private void Start()
    {
        Panel.SetActive(false);
    }
    public void showPanel()
    {
        Panel.SetActive(true);
    }
    public void L()
    {
        selection = "L";
        Panel.SetActive(false);
    }
    public void O()
    {
        selection = "O";
        Panel.SetActive(false);
    }
    public void I()
    {
        selection = "I";
        Panel.SetActive(false);
    }
    public void Z()
    {
        selection = "Z";
        Panel.SetActive(false);
    }
    public void S()
    {
        selection = "S";
        Panel.SetActive(false);
    }
    public void J()
    {
        selection = "J";
        Panel.SetActive(false);
    }
    public void T()
    {
        selection = "T";
        Panel.SetActive(false);
    }
    public void Random()
    {
        selection = "random";
        Panel.SetActive(false);
    }
}
