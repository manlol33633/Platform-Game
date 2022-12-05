using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatformScript : MonoBehaviour
{
    [SerializeField] private GameObject[] blimps;
    [SerializeField] private GameObject ground;
    [SerializeField] private TMP_Text scoreText;
    private GameObject platform;
    public static bool create;
    private float timeCount;
    private bool isStart;
    public static float score;
    public static bool startResetTimer;
    private float timeToReset;
    void Start() {
        timeCount = 0;
        create = true;
        isStart = true;
        score = 0;
        startResetTimer = false;
        timeToReset = 0;
    }

    void Update() {
        timeCount += Time.deltaTime;
        if (timeCount >= 5 && isStart) {
            Destroy(ground);
            isStart = false;
        }
        if (create) {
            platform = Instantiate(blimps[Random.Range(0, blimps.Length)], new Vector3(Random.Range(-8, 8), Random.Range(-1, 3), 0), Quaternion.identity);
            score++;
            scoreText.text = "Score: " + score;
            create = false;
        }

        if (startResetTimer) {
            timeToReset += Time.deltaTime;
            if (timeToReset >= 1) {
                timeToReset = 0;
                create = true;
                startResetTimer = false;
            }
        }
    }
}
