using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float degreesPerSecond = 45;
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        transform.RotateAround(target.transform.position, Vector3.forward, degreesPerSecond * Time.deltaTime);

        }
}

