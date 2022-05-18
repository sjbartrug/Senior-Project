using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Camera cam5;
    public Camera cam6;
    float timer = 12;
    int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<PlayerMovement>().enabled = false;
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        cam4.enabled = false;
        cam5.enabled = false;
        cam6.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(i);
        Debug.Log(timer);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (i == 1)
            {
                cam1.enabled = false;
                cam2.enabled = true;
            }
            if (i == 2)
            {
                cam2.enabled = false;
                cam3.enabled = true;
            }
            if (i == 3)
            {
                cam3.enabled = false;
                cam4.enabled = true;
            }
            if (i == 4)
            {
                cam4.enabled = false;
                cam5.enabled = true;
            }
            if (i == 5)
            {
                cam5.enabled = false;
                cam6.enabled = true;
            }
            i++;
            timer = 12;
        }
        if (i == 6)
        {
            this.gameObject.GetComponent<PlayerMovement>().enabled = true;
            this.gameObject.GetComponent<Introduction>().enabled = false;
        }
    }
}
