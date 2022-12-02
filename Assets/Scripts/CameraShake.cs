using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeMagnitude;
    [SerializeField] float shakeDuration;


    Vector3 initialCamPos;
    //Transform initialCamTransform;
    private void Start()
    {
        initialCamPos = transform.position;
        //initialCamTransform = transform;
        //Debug.Log("initial postion of cam " + transform.position);
    }


    // Update is called once per frame




    public void PlayShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float shakeElapsedTime = 0f;
        Debug.Log("Start of Shake " + Time.time);
        while (shakeElapsedTime < shakeDuration)
        {
            transform.position = initialCamPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            yield return new WaitForEndOfFrame();
            shakeElapsedTime += Time.deltaTime;

        }
        transform.position = initialCamPos;
        Debug.Log("End of Shake " + Time.time);


        //Debug.Log(" no while ");
    }
}
