using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public Animator anim;
    bool flickering = true;
    public List<string> triggerNames;
    public float minTime, maxTime;

    void Start() {
        StartCoroutine(flickerLights());
    }

    IEnumerator flickerLights() {
        while (flickering == true) {
            float randTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(randTime);
            string name = triggerNames[Random.Range(0, triggerNames.Count)];
            anim.SetTrigger(name);
        }
    }
}
