using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject[] generators = new GameObject[3];

    public GameObject package;
    Coroutine generator;

    public static float timeDifference = 4f;


    void Start()
    {
        StartCoroutine(Spawn());
    }


    void OnDestroy()
    {

        StopCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            int pick = (int)Random.Range(0, 29) / 10;
            GameObject temp = Instantiate(package, generators[pick].transform.position + Vector3.right * 1.1f, Quaternion.identity);
            temp.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
            yield return new WaitForSeconds(timeDifference + Random.Range(-0.4f, 0.4f));
        }
    }


}
