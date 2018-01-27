using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Transform ButtonRedClockwise;
    public Transform ButtonBlueClockwise;
    public Transform ButtonGreenClockwise;
    public Transform ButtonPurpleClockwise;
    public Transform ButtonRedCounterclockwise;
    public Transform ButtonBlueCounterclockwise;
    public Transform ButtonGreenCounterclockwise;
    public Transform ButtonPurpleCounterclockwise;

    public float recoverTime;

    // Use this for initialization
    void Start () {
		
	}

    public void setAbleColor(int color, bool able)
    {
        switch (color)
        {
            case 0: // Red
                ButtonRedClockwise.GetComponent<Button>().interactable = able;
                ButtonRedCounterclockwise.GetComponent<Button>().interactable = able;
                break;
            case 1: // Green
                ButtonBlueClockwise.GetComponent<Button>().interactable = able;
                ButtonBlueCounterclockwise.GetComponent<Button>().interactable = able;
                break;
            case 2: // Blue
                ButtonGreenClockwise.GetComponent<Button>().interactable = able;
                ButtonGreenCounterclockwise.GetComponent<Button>().interactable = able;
                break;
            case 3: // Purple
                ButtonPurpleClockwise.GetComponent<Button>().interactable = able;
                ButtonPurpleCounterclockwise.GetComponent<Button>().interactable = able;
                break;
        }
    }
    public void resetColor(int color)
    {
        switch (color)
        {
            case 0: // Red
                ButtonRedClockwise.GetComponent<Button>().interactable = false;
                ButtonRedCounterclockwise.GetComponent<Button>().interactable = false;
                break;
            case 1: // Green
                ButtonBlueClockwise.GetComponent<Button>().interactable = false;
                ButtonBlueCounterclockwise.GetComponent<Button>().interactable = false;
                break;
            case 2: // Blue
                ButtonGreenClockwise.GetComponent<Button>().interactable = false;
                ButtonGreenCounterclockwise.GetComponent<Button>().interactable = false;
                break;
            case 3: // Purple
                ButtonPurpleClockwise.GetComponent<Button>().interactable = false;
                ButtonPurpleCounterclockwise.GetComponent<Button>().interactable = false;
                break;
        }
        StartCoroutine(waitRecolor(color));
    }
    public void resetAllColors()
    {
        ButtonRedClockwise.GetComponent<Button>().interactable = false;
        ButtonRedCounterclockwise.GetComponent<Button>().interactable = false;
        ButtonBlueClockwise.GetComponent<Button>().interactable = false;
        ButtonBlueCounterclockwise.GetComponent<Button>().interactable = false;
        ButtonGreenClockwise.GetComponent<Button>().interactable = false;
        ButtonGreenCounterclockwise.GetComponent<Button>().interactable = false;
        ButtonPurpleClockwise.GetComponent<Button>().interactable = false;
        ButtonPurpleCounterclockwise.GetComponent<Button>().interactable = false;
        StartCoroutine(waitRecolorAll());
    }
    IEnumerator waitRecolor(int color)
    {
        if ((color >= 0) && (color <= 3))
        {
            yield return new WaitForSeconds(recoverTime);
        }

        switch (color)
        {
            case 0: // Red
                ButtonRedClockwise.GetComponent<Button>().interactable = true;
                ButtonRedCounterclockwise.GetComponent<Button>().interactable = true;
                break;
            case 1: // Green
                ButtonBlueClockwise.GetComponent<Button>().interactable = true;
                ButtonBlueCounterclockwise.GetComponent<Button>().interactable = true;
                break;
            case 2: // Blue
                ButtonGreenClockwise.GetComponent<Button>().interactable = true;
                ButtonGreenCounterclockwise.GetComponent<Button>().interactable = true;
                break;
            case 3: // Purple
                ButtonPurpleClockwise.GetComponent<Button>().interactable = true;
                ButtonPurpleCounterclockwise.GetComponent<Button>().interactable = true;
                break;
        }
    }
    IEnumerator waitRecolorAll()
    {
        yield return new WaitForSeconds(recoverTime);

        ButtonRedClockwise.GetComponent<Button>().interactable = true;
        ButtonRedCounterclockwise.GetComponent<Button>().interactable = true;
        ButtonBlueClockwise.GetComponent<Button>().interactable = true;
        ButtonBlueCounterclockwise.GetComponent<Button>().interactable = true;
        ButtonGreenClockwise.GetComponent<Button>().interactable = true;
        ButtonGreenCounterclockwise.GetComponent<Button>().interactable = true;
        ButtonPurpleClockwise.GetComponent<Button>().interactable = true;
        ButtonPurpleCounterclockwise.GetComponent<Button>().interactable = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
