using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    private GameController gc;
    public int color1;
    public int color2;
    public float movementSpeed;
    public float rotationTime;

    private bool moving;
    private Vector3 speedVec;
	// Use this for initialization
	void Start () {
        moving = false;
        gc = GameObject.FindGameObjectWithTag("Scripts").GetComponent<GameController>();
        gc.setShip(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
            transform.position += transform.up * Time.deltaTime * movementSpeed;
	}
    public void setMoving(bool move)
    {
        moving = move;
    }
    public void setRotation(bool clockwise)
    {
        StartCoroutine(RotateMe(new Vector3(0, 0, clockwise ? -90 : 90), rotationTime));
    }
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
    }
    public void setColor(int color)
    {
        color1 = color2 = color;
    }
    public void setColors(int color_1, int color_2)
    {
        color1 = color_1;
        color2 = color_2;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ship")
        {
            gc.lose();
            Destroy(this.gameObject);
        }
        else if (coll.gameObject.tag == "Finish")
        {
            gc.oneFinished();
            Destroy(this.gameObject);
        }

    }
}
