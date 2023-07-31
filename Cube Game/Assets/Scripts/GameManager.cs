using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject hazardPrefab;
    [SerializeField] private int maxHazardToSpawn = 3;
    [SerializeField] private float maxDrag = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHazards());
    }

    private IEnumerator SpawnHazards()
    {
        var hazardToSpawn = Random.Range(1, maxHazardToSpawn);

        for (int i = 0; i < hazardToSpawn; i++) { 
            var X = Random.Range(-7, 7);
            var drag = Random.Range(0f, maxDrag);

            var hazard = Instantiate(hazardPrefab, new Vector3(X, 12.28f, -1.16f), Quaternion.identity);
            hazard.GetComponent<Rigidbody>().drag = drag;
        }

        var timeToWait = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(timeToWait);

        yield return SpawnHazards();
    }
}
