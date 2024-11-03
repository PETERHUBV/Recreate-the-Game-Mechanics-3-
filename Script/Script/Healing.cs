using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public float HealingAmount = 20f;
    public GameObject HealingPrefab;
    public Transform target;
    public float Distance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CastHealing();
        }
    }
         public void CastHealing()
        {
        if (target != null)
        {
            Vector3 CastPosition = target.position + Vector3.up * Distance;
            //var targetHealth = target.GetComponent<>();
            GameObject Healing = Instantiate(HealingPrefab, CastPosition, Quaternion.identity);
            Destroy(Healing, 5f);



        }

        }

    }

