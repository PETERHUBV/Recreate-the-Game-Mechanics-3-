using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastULT : MonoBehaviour
{
    public float rotationSpeed = 5f;
    private Transform Target; 

    void Update()
    {
        AimAtTarget();
    }

    private void AimAtTarget()
    {
        if (Target != null)
        {
            
            Vector3 direction = Target.position - transform.position;
            direction.y = 0; 

           
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
           Target = other.transform; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            Target = null; 
        }
    }
}