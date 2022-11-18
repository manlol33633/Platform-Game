using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlimpMovement : MonoBehaviour
{
    [SerializeField] private float speedY;
    private float yPosition;
    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        Debug.Log(Mathf.Sin(Time.time) * speedY);
        transform.position = new Vector3(transform.position.x, (yPosition + (Mathf.Sin(Time.time) * speedY)), transform.position.z);
    }
}
