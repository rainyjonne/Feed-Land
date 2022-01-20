using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public AudioClip positiveBonus;
    public AudioClip negativeBonus;
    public GameObject waterBallPrefab;
    private GameObject[] blueMonsters;
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
        if (gameObject.tag.Contains("red")) {
            int blood;
            blood = Random.Range(1, 6);
            int add = 2;
            add = Random.Range(0, 2);
            if (add == 1) {
                print("加血" + blood);
                unicorn.GetComponent<RoleController>().AddBlood(blood);
                audioPlayer.PlayOneShot(positiveBonus);
            } else if (add == 0) {
                print("扣血" + blood);
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
        }
    }
}
