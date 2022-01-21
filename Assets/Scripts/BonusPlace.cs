using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPlace : MonoBehaviour
{
    public GameObject needlePrefab;
    public GameObject waterBallCanvasPrefab;
    public GameObject greenPotionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConstructSurprise(string type)
    {
        // construct random surprises based on bonus type
        if (type == "red") {
            Instantiate(needlePrefab, gameObject.transform.position, Quaternion.identity);
        } else if (type == "blue") {
            Instantiate(waterBallCanvasPrefab, gameObject.transform.position, Quaternion.identity);
        } else if (type == "green") {
            Instantiate(greenPotionPrefab, gameObject.transform.position, Quaternion.identity);
        }
        

    }
}
