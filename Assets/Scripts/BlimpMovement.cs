using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlimpMovement : MonoBehaviour
{
    [SerializeField] private float speedY;
    private float yPosition;
    private float timeCount;
    private Animator anim;
    void Start()
    {
        yPosition = transform.position.y;
        timeCount = 0;
        anim = GetComponent<Animator>();
        anim.SetBool("IsFade", false);
    }

    void Update()
    {
        timeCount += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, (yPosition + (Mathf.Sin(Time.time) * speedY)), transform.position.z);
        if (timeCount >= 4) {
            anim.SetBool("IsFade", true);
            if (timeCount >= 5) {
                Destroy(gameObject);
                timeCount = 0;
                PlatformScript.startResetTimer = true;
            }
        }
    }
}
