using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetraSpawner : MonoBehaviour
{
    public GameObject tetra;
    private BlockController currentTetra;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newTetra = Instantiate(tetra, transform.position, transform.rotation);
        currentTetra = newTetra.GetComponent<BlockController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTetra.disconnected) {
            Vector3 position = new(transform.position.x + Random.Range(-10, 10), transform.position.y, 0);
            GameObject newTetra = Instantiate(tetra, position, transform.rotation);
            currentTetra = newTetra.GetComponent<BlockController>();
        }
    }
}
