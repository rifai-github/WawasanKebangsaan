using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour 
{
    void OnEnable()
    {
        LeanTouch.OnFingerSwipe += OnFingerSwipe;
    }
    void OnDisable()
    {
        LeanTouch.OnFingerSwipe -= OnFingerSwipe;
    }

    private void OnFingerSwipe(LeanFinger finger)
    {
        Vector2 swipe = finger.SwipeScreenDelta;

        if (swipe.x < -Mathf.Abs(swipe.y)) //kanan ke kiri
        {
            //Debug.Log("kanan ke kiri");
            ARModal ar = ARModal.Instance();
            ar.ShowProvinsi = true;
        }

        if (swipe.x > Mathf.Abs(swipe.y)) //kiri ke kanan
        {
            //Debug.Log("kiri ke kanan");
            ARModal ar = ARModal.Instance();
            ar.ShowProvinsi = false;
        }

        if (swipe.y < -Mathf.Abs(swipe.x)) //atas ke bawah
        {
            //Debug.Log("atas ke bawah");
        }

        if (swipe.y > Mathf.Abs(swipe.x)) // bawah ke atas
        {
            //Debug.Log("bawah ke atas");
        }
        
    }
}
