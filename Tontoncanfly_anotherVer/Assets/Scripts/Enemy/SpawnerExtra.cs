using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerExtra : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private GameObject spawner;

    void Start()
    {
        StartCoroutine(Spawnerr());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Spawnerr()
    {
        yield return new WaitForSeconds(5);
        Vector3 temp = spawner.transform.position;
        temp.y = Random.Range(-3.29f, -1.9f);
        temp.x = -11f;
        Instantiate(spawner, temp, Quaternion.identity);
        StartCoroutine(Spawnerr());
    }
}
