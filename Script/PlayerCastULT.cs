using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastULT : MonoBehaviour
{
    public GameObject objectToSummon; 
    public float detectionRadius = 10f; 
    public Transform currentTarget; 

    void Update()
    {
        AimAtTarget(); 

     
        if (Input.GetKeyDown(KeyCode.R) && currentTarget != null)
        {
            SummonObject();
        }
    }

    public void AimAtTarget()
    {

        Collider[] targets = Physics.OverlapSphere(transform.position, detectionRadius);
        currentTarget = null;

        foreach (var target in targets)
        {
            if (target.CompareTag("Object"))
            {
                currentTarget = target.transform;
                break;
            }
        }


        if (currentTarget != null)
        {
            Vector3 direction = currentTarget.position - transform.position;
            direction.y = 0;

            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
        }
    
   public void SummonObject()
    {
       
        GameObject summonedObject = Instantiate(objectToSummon, transform.position + transform.forward, Quaternion.identity);

       
       PlayerSummon summonedScript = summonedObject.GetComponent<PlayerSummon>();
        if (summonedScript != null)
        {
            summonedScript.Initialize(currentTarget);
            summonedScript.destroy = 5f;
        }

        Debug.Log("Summoned  object towards: " + currentTarget.gameObject.name);
    }
}