using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class R_Hand : MonoBehaviour
{
    GameObject Rhand;
    LineRenderer lineR;
    Ray ray;
    RaycastHit hit;
    public UnityEvent<bool> changeColor01 = new UnityEvent<bool>();
    bool hitButton01;
    public UnityEvent<bool> changeColor02 = new UnityEvent<bool>();
    bool hitButton02;
    //public UnityEvent<bool> changeColor03 = new UnityEvent<bool>();
    //bool hitButton03;
    //public UnityEvent<bool> changeColor04 = new UnityEvent<bool>();
    //bool hitButton04;
    //public UnityEvent<bool> changeColor05 = new UnityEvent<bool>();
    //bool hitButton05;
    //public UnityEvent<bool> changeColor06 = new UnityEvent<bool>();
    //bool hitButton06;
    Coroutine vibeHandle;

    //GameObject startScreen;
    //GameObject selectScreen;
    //GameObject tutorialScreen;
    GameObject optionScreen;
    GameObject cameraCenter;

    bool optionSwitch;

    void Start()
    {
        Rhand = GameObject.Find("RightHandAnchor");
        transform.position = Rhand.transform.position;
        transform.eulerAngles = Rhand.transform.eulerAngles;
        transform.parent = Rhand.transform;

        lineR = GetComponent<LineRenderer>();

        //startScreen = GameObject.Find("StartScreen");
        //selectScreen = GameObject.Find("SelectScreen");
        //selectScreen.SetActive(false);
        //tutorialScreen = GameObject.Find("TutorialScreen");
        optionScreen = GameObject.Find("OptionScreen");
        cameraCenter = GameObject.Find("CenterEyeAnchor");
        optionScreen.SetActive(false);
    }


    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        lineR.SetPosition(0, ray.origin);
        lineR.SetPosition(1, ray.direction * 8);
        lineR.material.color = Color.cyan;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            lineR.SetPosition(0, ray.origin);
            lineR.SetPosition(1, hit.point);

            //if (hit.collider.gameObject.CompareTag("startscreen"))
            //{
            //    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            //    {
            //        hit.collider.gameObject.SetActive(false);
            //    }
            //}

            if (hit.collider.gameObject.CompareTag("button01"))
            {
                if (hitButton01 == false)
                {
                    hitButton01 = true;
                    changeColor01.Invoke(hitButton01);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }
            }
            if (hit.collider.gameObject.CompareTag("button02"))
            {
                if (hitButton02 == false)
                {
                    hitButton02 = true;
                    changeColor02.Invoke(hitButton02);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                    StartCoroutine(VibeHandle());
                }
            }
            //if (hit.collider.gameObject.CompareTag("button03"))
            //{
            //    if (hitButton03 == false)
            //    {
            //        hitButton03 = true;
            //        changeColor03.Invoke(hitButton03);
            //    }

            //    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            //    {
            //        hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
            //        StartCoroutine(VibeHandle());
            //    }
            //}

            //if (hit.collider.gameObject.CompareTag("off"))
            //{
            //    if (hitButton06 == false)
            //    {
            //        hitButton06 = true;
            //        changeColor06.Invoke(hitButton06);
            //    }

            //    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            //    {
            //        hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
            //        StartCoroutine(VibeHandle());
            //    }
            //}

            //if (hit.collider.gameObject.CompareTag("stand"))
            //{
            //    if (hitButton04 == false)
            //    {
            //        hitButton04 = true;
            //        changeColor04.Invoke(hitButton04);
            //    }
            //    if (hitButton05 == true)
            //    {
            //        hitButton05 = false;
            //        changeColor05.Invoke(hitButton05);
            //    }

            //    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            //    {
            //        hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
            //        StartCoroutine(VibeHandle());
            //    }
            //}
            //if (hit.collider.gameObject.CompareTag("table"))
            //{
            //    if (hitButton05 == false)
            //    {
            //        hitButton05 = true;
            //        changeColor05.Invoke(hitButton05);
            //    }
            //    if (hitButton04 == true)
            //    {
            //        hitButton04 = false;
            //        changeColor04.Invoke(hitButton04);
            //    }

            //    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            //    {
            //        hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
            //        StartCoroutine(VibeHandle());
            //    }
            //}
        }
        else if (hitButton01 == true)
        {
            hitButton01 = false;
            changeColor01.Invoke(hitButton01);
        }
        else if (hitButton02 == true)
        {
            hitButton02 = false;
            changeColor02.Invoke(hitButton02);
        }
        //else if (hitButton03 == true)
        //{
        //    hitButton03 = false;
        //    changeColor03.Invoke(hitButton03);
        //}
        //else if (hitButton04 == true)
        //{
        //    hitButton04 = false;
        //    changeColor04.Invoke(hitButton04);
        //}
        //else if (hitButton05 == true)
        //{
        //    hitButton05 = false;
        //    changeColor05.Invoke(hitButton05);
        //}
        //else if (hitButton06 == true)
        //{
        //    hitButton06 = false;
        //    changeColor06.Invoke(hitButton06);
        //}

        //if (startScreen.activeSelf == false)
        //{
        //    selectScreen.SetActive(true);
        //}

        //if (tutorialScreen.activeSelf == true)
        //{
        //    selectScreen.SetActive(false);
        //}
        //else
        //{
        //    selectScreen.SetActive(true);
        //}

        if (optionScreen.activeSelf == true && optionSwitch == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                optionScreen.SetActive(false);
                optionSwitch = false;
            }
        }
        else if (optionScreen.activeSelf == false && optionSwitch == false)
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                optionScreen.SetActive(true);
                optionSwitch = true;
                optionScreen.transform.position = cameraCenter.transform.position + cameraCenter.transform.forward * 5;
                optionScreen.transform.forward = cameraCenter.transform.forward;
            }
        }
    }
    IEnumerator VibeHandle()
    {
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
        yield return new WaitForSeconds(0.5f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
    }
}