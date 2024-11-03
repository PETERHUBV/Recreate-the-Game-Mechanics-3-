using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSummon : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    public float destroy = 5f;
    public void Start()
    {
       
        Destroy(gameObject, destroy);
    }

    public void Initialize(Transform targetTransform)
    {
        target = targetTransform; 
    }

    public void Update()
    {
        if (target != null)
        {
            
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

           
            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                Debug.Log("Reached target: " + target.gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}