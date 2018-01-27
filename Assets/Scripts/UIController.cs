using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject darkScreen;
    public GameObject tapText;

    private bool isDark;
    private bool inAnimation;
    // Use this for initialization
    void Start ()
    {
        tapText.SetActive(false);
        darkScreen.SetActive(true);
        isDark = false;
        inAnimation = false;
    }
    public void setTapTextEnabled(bool enabled)
    {
        tapText.SetActive(enabled);
    }
    public bool isInAnimation()
    {
        return inAnimation;
    }
    public void Darken()
    {
        isDark = true;
        darkScreen.SetActive(true);
        darkScreen.GetComponent<Animator>().SetBool("isHidden", false);
    }
    public void fastDarken()
    {
        isDark = true;
        darkScreen.SetActive(true);
        darkScreen.GetComponent<Animator>().CrossFade(0, 0, -1, 1f);
    }

    public void Undarken()
    {
        inAnimation = true;
        isDark = false;
        darkScreen.GetComponent<Animator>().SetBool("isHidden", true);
        StartCoroutine(WaitUndarken());
    }
    IEnumerator WaitUndarken()
    {
        yield return new WaitForSeconds(1);
        if (!isDark)
            darkScreen.SetActive(false);
        inAnimation = false;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
