using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatformScript : MonoBehaviour
{
    [SerializeField] private GameObject[] blimps;
    [SerializeField] private GameObject ground;
    [SerializeField] private TMP_Text scoreText;
    private bool startResetTimer;
    private GameObject platform;
    private bool create;
    private float timeCount;
    private float timeToReset;
    private float timeToCreate;
    private bool isStart;
    public static float score;
    void Start() {
        timeCount = 0;
        timeToCreate = 0;
        create = true;
        isStart = true;
        score = 0;
    }

    void Update() {
        timeToCreate += Time.deltaTime;
        timeCount += Time.deltaTime;
        if (timeToCreate > 5 && isStart) {
            Destroy(ground);
            timeToCreate = 0;
            isStart = false;
        }
        if (create) {
            platform = Instantiate(blimps[Random.Range(0, blimps.Length)], new Vector3(Random.Range(-8, 8), Random.Range(-1, 3), 0), Quaternion.identity);
            create = false;
            score++;
            scoreText.text = "Score: " + score;
        }
        if (timeCount >= 5) {
            Destroy(platform);
            timeCount = 0;
            startResetTimer = true;
        }
        if (startResetTimer) {
            timeToReset += Time.deltaTime;
            if (timeToReset >= 1) {
                create = true;
                startResetTimer = false;
                timeToReset = 0;
            }
        }

        if (transform.position.y <= -10) {
            Destroy(gameObject);
        }
    }
}
