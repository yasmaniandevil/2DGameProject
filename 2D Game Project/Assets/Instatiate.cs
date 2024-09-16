using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instatiate : MonoBehaviour
{
    public GameObject objectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {

            //Vector3 randomPos = new Vector3(Random.Range(-6, 6), Random.Range(-3, 3));
            //Vector3 randomScale = new Vector3(Random.Range(.5f, 2), Random.Range(2, .5f), 1);
            InstantiateSpawn(new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));


            //InstantiateSpawn(randomPos, randomScale);
        }
    }

    private void InstantiateSpawn(Vector3 position, Vector3 scale)
    {
        GameObject newObj = Instantiate(objectPrefab, position, Quaternion.identity);
        newObj.transform.localScale = scale;
    }
}
