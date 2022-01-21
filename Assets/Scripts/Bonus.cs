using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public AudioClip positiveBonus;
    public AudioClip negativeBonus;
    public GameObject waterBallPrefab;
    public GameObject watermelonPrefab;
    public GameObject bananaPrefab;
    private GameObject[] blueMonsters;
    private GameObject[] greenMonsters;
    private AudioSource audioPlayer;
    private GameObject unicorn;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
        unicorn = GameObject.Find("Unicorn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        int add = 2;
        add = Random.Range(0, 2);
        if (gameObject.tag.Contains("red")) {
            int blood;
            blood = Random.Range(1, 6);
            if (add == 1) {
                unicorn.GetComponent<RoleController>().AddBlood(blood);
                audioPlayer.PlayOneShot(positiveBonus);
            } else if (add == 0) {
                unicorn.GetComponent<RoleController>().TakeDamage(blood);
                audioPlayer.PlayOneShot(negativeBonus);
            }
            Destroy(gameObject, 1f);
        } else if (gameObject.tag.Contains("blue")) {
            audioPlayer.PlayOneShot(positiveBonus);
            blueMonsters = GameObject.FindGameObjectsWithTag("blue_monster");
            foreach (GameObject blueMonster in blueMonsters) {
                Vector3 waterBallPosition;
                waterBallPosition = blueMonster.transform.Find("WaterBallPosition").position;
                GameObject waterBall;
                waterBall = Instantiate(waterBallPrefab, waterBallPosition, Quaternion.identity);
                Destroy(waterBall, 3.5f);
            }
            Destroy(gameObject, 1f);
        } else if (gameObject.tag.Contains("green")) {
            greenMonsters = GameObject.FindGameObjectsWithTag("green_monster");
            foreach (GameObject greenMonster in greenMonsters) {
                Vector3 greenFoodPosition;
                greenFoodPosition = greenMonster.transform.Find("GreenFoodPosition").position;
                GameObject greenFood;
                if (add == 1) {
                    audioPlayer.PlayOneShot(positiveBonus);
                    greenFood = Instantiate(watermelonPrefab, greenFoodPosition, Quaternion.identity);
                    Destroy(greenFood, 3.5f);
                } else if (add == 0) {
                    audioPlayer.PlayOneShot(negativeBonus);
                    greenFood = Instantiate(bananaPrefab, greenFoodPosition, Quaternion.identity);
                    Destroy(greenFood, 3.5f);
                }
            }
            Destroy(gameObject, 1f);
        }
    }
}
