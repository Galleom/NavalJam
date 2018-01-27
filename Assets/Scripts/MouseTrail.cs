using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrail : MonoBehaviour
{
    ParticleSystem ps;
    Vector3 pos;
    // Use this for initialization
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ps.Play();
        }
        if (Input.GetMouseButton(0))
        {
            //pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos = Input.mousePosition;
            pos.z = 0;

            this.transform.position = pos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            ps.Stop();
        }
    }
}
