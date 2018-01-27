using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private List<ShipController> Ships;
    private SoundController sounds;
    private int victoryCount;
    private int stage;
    private int timer;
    private UIController ui;
    // Use this for initialization
    void Awake () {
        Ships = new List<ShipController>();
        sounds = GetComponent<SoundController>();
        ui = transform.GetComponent<UIController>();
    }
    void Start()
    {
        ui.fastDarken();
        victoryCount = 0;
        stage = 0;
    }
	public void setShip(ShipController ship)
    {
        Ships.Add(ship);
        victoryCount++;
    }
	// Update is called once per frame
	void Update () {
        switch (stage)
        {
            case 0: // Darken
                switch (timer)
                {
                    case 0:
                        ui.Darken();
                        ui.setTapTextEnabled(true);
                        timer = 1;
                        break;
                    case 1: // wait appear animation
                        if (!ui.isInAnimation())
                        {
                            timer = 2;
                        }
                        break;
                    case 2: // wait appear animation
                        if (Input.GetMouseButtonUp(0))
                        {
                            sounds.playClickSound();
                            ui.setTapTextEnabled(false);
                            ui.Undarken();
                            timer = 3;
                        }
                        break;
                    default:// wait appear animation
                        if ((!ui.isInAnimation()) || Input.GetMouseButtonUp(0))
                        {
                            stage = 1;
                            timer = 0;
                            foreach (var ship in Ships)
                            {
                                ship.setMoving(true);
                            }
                        }
                        break;
                    case 35: // wait appear animation
                        stage = 1;
                        timer = 0;
                        break;
                        /*default:
                            timer++;
                            break;*/
                }
                break;
            case 1: // main game
                break;
            case -1: // lose
                switch (timer)
                {
                    case 0:
                        sounds.playLoseSound();
                        timer++;
                        break;
                    case 1: 
                        break;
                }
                break;
        }
    }
    public void commandShipsCW(int color)
    {
        sounds.playButtonClickSound(color);
        commandShips(color, true);
    }
    public void commandShipsCCW(int color)
    {
        sounds.playButtonClickSound(color);
        commandShips(color, false);
    }
    public void commandShips(int color, bool clockwise)
    {
        foreach (ShipController ship in Ships)
        {
            if ((ship.color1 == color) || (ship.color2 == color))
            {
                ship.setRotation(clockwise);
            }
        }
    }
    public void lose()
    {
        stage = -1;
        timer = 0;
    }
    public void oneFinished()
    {
        sounds.playOneFinishedSound();
        victoryCount--;
        if (victoryCount <= 0)
        {
            stage = 10;
            timer = 0;
        }
    }
    public void win()
    {
        sounds.playWinSound();
    }
}
