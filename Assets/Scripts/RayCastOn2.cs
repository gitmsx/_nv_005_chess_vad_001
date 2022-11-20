using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;

public delegate void Ray_Delegate2();



public class RayCastOn2 : MonoBehaviour
{



    [HideInInspector] private Text Text__info001;

    public Transform Pointer;  // collide with Ray
    public Transform Pointer2;  // collide with Ray
                                       //  [HideInInspector] public event Ray_Delegate ray_event;
    [SerializeField][Range(0.2f, 2f)] public float FreqScansForRay = 0.5f;
    private float TimeCircle = 0;
    private float CircleS = 0;







    void Start()
    {

        var Text7 = GameObject.Find("TextInfo");
        Text__info001 = Text7.GetComponent<Text>();
        Text__info001.text = "Text__info001";

    }



    public void FixedUpdate()

    {
        TimeCircle += Time.deltaTime;

        if (TimeCircle > FreqScansForRay)
        {
            CircleS++;
            TimeCircle = 0;
            Text__info001.text = CircleS.ToString();
            raycast();
        }



    }
    public void raycast()
    {
        RaycastHit hit;

        Ray[] ray = new Ray[4];

        ray[0] = new Ray(transform.position, Vector3.forward * 30);
        ray[1] = new Ray(transform.position, Vector3.right * 30);
        ray[2] = new Ray(transform.position, -Vector3.forward * 30);
        ray[3] = new Ray(transform.position, -Vector3.right * 30);



        for (int i = 0; i < 4; i++)
        {
            if (Physics.Raycast(ray[i], out hit) )
            {
                //Debug.DrawRay(transform.position, Vector3.right * hit.distance, Color.red);
                //Debug.Log(hit.point);
                //Debug.Log("hit.point");


                if (hit.collider.gameObject.tag == "Player")
                {
                    Text__info001.text = Text__info001.text + hit.collider.gameObject.tag
                        + " hit.point " + hit.point.ToString();

                    Pointer.position = hit.point;
                }


                else

                {
                 
                    Pointer2.position = hit.point;
                }


            }
        }


    }

    // Update is called once per frame
    void Update()
    {


    }


}
