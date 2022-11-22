using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.UIElements;

public delegate void Ray_Delegate3();



public class RayCastOnDracon : MonoBehaviour
{



    [HideInInspector] private Text Text__info001;
    public GameObject BulletPF;
    private GameObject bulletClone;

    public float bulletSpeed=100;
    public Transform Pointer;  // collide with Ray
    public Transform Pointer2;  // collide with Ray
                                       //  [HideInInspector] public event Ray_Delegate ray_event;
    [SerializeField][Range(0.2f, 2f)] public float FreqScansForRay = 0.5f;
    private float TimeCircle = 0;
    private float CircleS = 0;

    private int AngleSector = 0;



    private Ray[] ray = new Ray[4];
    


   
    private  Vector3[] DirectionM = new Vector3[4];


    [HideInInspector] private Text Text__info004;




    void Start()
    {

        var Text7 = GameObject.Find("TextInfo");
        Text__info001 = Text7.GetComponent<Text>();
        Text__info001.text = "Text__info001";


        Text__info004 = GameObject.Find("TextInfo3").GetComponent<Text>();
        Text__info004.text = "Text__info004";


    }



    public void FixedUpdate()

    {
        TimeCircle += Time.deltaTime;

        if (TimeCircle > FreqScansForRay)
        {
            CircleS++;
            TimeCircle = 0;
            
            
            

            

            
            raycast();
        }



    }
    public void raycast()
    {
        RaycastHit hit;


        DirectionM[0] = Vector3.forward;
        DirectionM[1] = Vector3.right;
        DirectionM[2] = -Vector3.forward;
        DirectionM[3] = -Vector3.right;


        ray[0] = new Ray(transform.position, DirectionM[0] * 30);
        ray[1] = new Ray(transform.position, DirectionM[1] * 30);
        ray[2] = new Ray(transform.position, DirectionM[2] * 30);
        ray[3] = new Ray(transform.position, DirectionM[3] * 30);

        ray[1] = new Ray(transform.position, Vector3.right * 30);
        ray[2] = new Ray(transform.position, -Vector3.forward * 30);
        ray[3] = new Ray(transform.position, -Vector3.right * 30);


        var SignedAngle = Vector3.SignedAngle(Vector3.forward, transform.forward, Vector3.up);

       

        if (Mathf.Approximately(SignedAngle, 90))
        {
            Text__info004.text = " SignedAngle right " + SignedAngle.ToString();
            AngleSector = 1;
        }
        else
            if (Mathf.Approximately(SignedAngle, -90))
        {
            Text__info004.text = " SignedAngle left " + SignedAngle.ToString();
            AngleSector = 3;
        }
        else
            if (Mathf.Approximately(SignedAngle, 0))
        {
            Text__info004.text = " SignedAngle forvard " + SignedAngle.ToString();
            AngleSector = 0;

        }
        if (Mathf.Approximately(SignedAngle, 180))
        {
            Text__info004.text = " SignedAngle back  180.000 " + SignedAngle.ToString();
            AngleSector = 2;

        }
        if (Mathf.Approximately(SignedAngle, -180))
        {
            Text__info004.text = " SignedAngle back -180.000 " + SignedAngle.ToString();
            AngleSector = 2;

        }




        
            if (Physics.Raycast(ray[AngleSector], out hit) )
            {
            


                if (hit.collider.gameObject.tag == "Player")
                {
                    

                    Pointer.position = hit.point;

                    Fire(AngleSector);
                }


                else

                {
                 
                    Pointer2.position = hit.point;
                }


            }
        


    }

    void Fire(int i)
    {

        bulletClone = Instantiate(BulletPF, transform.position, transform.rotation);
        
        bulletClone.GetComponent<Rigidbody>().velocity = DirectionM[i] * bulletSpeed;



        Destroy(bulletClone, 5.5f);
        
         

    }


    // Update is called once per frame
    void Update()
    {


    }


}
