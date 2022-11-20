using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

class PatrulMove1 : MonoBehaviour
{
    [SerializeField] Transform target;
    

    [SerializeField] AnimationCurve curve;
    [SerializeField] float speed = 3.7f;
    [SerializeField] float timemove = 7.0f;



    float elapsedTime;
     Vector3 startPosition;
     Vector3 finishPosition;
    

    public void ResetObject()
    {
        elapsedTime = 0.0f;
        target.position = startPosition;
    }

    void Start()
    {
        
        startPosition = transform.position;
        finishPosition = target.position;
        
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        transform.position = Vector3.Lerp(startPosition, finishPosition, curve.Evaluate(elapsedTime / timemove));
        
    

    }

    

}