using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    float openTime;
    float moveD;
    bool openSwitch;
    bool stopSwitch;

    R_Hand Rhand;

    void Start()
    {
        Rhand = GameObject.Find("rightHand").GetComponent<R_Hand>();
        openSwitch = false;
    }

    
    void Update()
    {
        if (openSwitch == false)
        {
            transform.Translate(Time.deltaTime * moveD, 0, 0);
            openTime += Time.deltaTime;

            if (openTime >= 1f && openTime < 3.3f)
            {
                moveD = 1;
            }
            if (openTime >= 3.3f)
            {
                moveD = 0;
                openSwitch = true;
                openTime = 0;
            }
        }
        if(Rhand.moveIn == true && stopSwitch == false)
        {
            transform.Translate(Time.deltaTime * moveD, 0, 0);
            openTime += Time.deltaTime;

            if (openTime >= 1f && openTime < 3.3f)
            {
                moveD = -1;
            }
            if (openTime >= 3.3f)
            {
                moveD = 0;
                openTime = 0;
                stopSwitch = true;
            }
        }
    }
}
