using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject credits;
    bool shown;
    bool firstRelease;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shown && Input.GetMouseButtonUp(0))
        {
            if (firstRelease)
            {
                firstRelease = false;
                return;
            }
            shown = false;
            credits.SetActive(false);
        }
    }
    public void Show()
    {
        shown = true;
        firstRelease = true;
        credits.SetActive(true);
    }
}
