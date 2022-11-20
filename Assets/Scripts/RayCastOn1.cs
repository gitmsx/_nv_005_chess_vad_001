using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 
using UnityEngine.UI;

public delegate void Ray_Delegate();



public class RayCastOn1 : MonoBehaviour
{



    [SerializeField] private Text Text14;
    private GameObject Text7;



    public Transform PointerPosition;
    // public event Ray_Delegate ray_event;






    // Start is called before the first frame update
    void Start()
    {

        Text7 = GameObject.Find("TextInfo");
        //  Text2.transform.Translate(1,1,1);
        Text14 = Text7.GetComponent<Text>();
        Text14.text = "111111111";



        // ray_event += raycast;

        Ray_Delegate rD;
        rD = raycast;
    }



    public void raycast()
    {
    
        // Bit shift the index of the layer (8) to get a bit mask
     int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer


        Ray ray1 = new Ray(transform.position, Vector3.right*30);
        Ray ray2 = new Ray(transform.position, Vector3.forward*20);

        //Debug.DrawRay(transform.position, Vector3.up * 20, Color.green);
        //Debug.DrawRay(transform.position, Vector3.right * 20, Color.red);
        //Debug.DrawRay(transform.position, Vector3.forward * 20, Color.blue);


        //  if (Input.GetMouseButtonDown(0)) {

        //if (Physics.Raycast(ray1, out hit, 20, layerMask))
            if (Physics.Raycast(ray1, out hit ))
        {
                Debug.DrawRay(transform.position+new Vector3(1,1,1), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);


            Debug.Log(hit.point);
            Debug.Log("hit.point");



            //Text14.text = "hit x " + Math.Round(hit.point.x, digits: 3).ToString() +
            //   "hit y " + Math.Round(hit.point.y, digits: 3).ToString() +
            //   "hit z " + Math.Round(hit.point.z, digits: 3).ToString();


            // PointerPosition.position=hit.point;
        }
        else
        {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
       // }
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }


}
