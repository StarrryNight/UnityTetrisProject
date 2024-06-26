using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Piece pieceScript;
    public bool start = false;
    public Button start1;
    public Button select;
    public Button confirm;
    public Button clear;
    public Button retry;
    public Button erase;
    public Button leftMove;
    public Button rightMove;
    public Button downMove;
    public Button leftSpin;
    public Button rightSpin;
    public Button downDrop;
    // Start is called before the first frame update

    public void beginGame()
    {
        start = true;
        GameObject.Find("Board").GetComponent<Board>().begin();
        changeColor(select);
        changeColor(confirm);
        changeColor(clear);
        changeColor(erase);
        changeColor(start1);
        changeColor1(retry);
    }
    public void endGame()
    {
        start = true;
        changeColor1(select);
        changeColor1(confirm);
        changeColor1(clear);
        changeColor1(erase);
        changeColor1(start1);
        changeColor(retry);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeColor(Button change)
    {change.interactable = false;
        Image buttonImage = change.GetComponent<Image>();
        Color currentColor = buttonImage.color;
        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 0.3f);
        buttonImage.color = newColor;
    }

    private void changeColor1(Button change)
    {
        change.interactable = true;
        Image buttonImage = change.GetComponent<Image>();
        Color currentColor = buttonImage.color;
        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
        buttonImage.color = newColor;
    }

    public void changeKeyBindings1()
    {
        pieceScript.ChangeKey(leftMove, 1);
    }
    public void changeKeyBindings2()
    {
        pieceScript.ChangeKey(rightMove, 2);

    }
    public void changeKeyBindings3()
    {
        pieceScript.ChangeKey(downMove,3 );
    }

    public void changeKeyBindings4()
    {
        pieceScript.ChangeKey(leftSpin, 4);
    }
    public void changeKeyBindings5()
    {
        pieceScript.ChangeKey(rightSpin, 5);
    }
    public void changeKeyBindings6()
    {
        pieceScript.ChangeKey(downDrop, 6);
    }
}

