using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.Rendering.DebugUI;

public class FishingGameMechanic : MonoBehaviour
{
    public HapticFeedback hapticInput;

    public TMP_Text scoreText;
    private int score;

    public GameObject water;
    public GameObject FishV1;
    public GameObject FishV2;
    public GameObject FishV3;
    public GameObject FishV4;
    public GameObject Shark;

    public GameObject trophy1;
    public GameObject trophy2;
    public GameObject trophy3;
    public GameObject trophy4;
    public GameObject trophy5;
    public GameObject trophy6;
    public GameObject trophy7;
    public GameObject trophy8;
    public GameObject trophy9;
    public GameObject trophy10;

    private GameObject fish;
    private float timeleft = 10;
    private bool hasFish = false;

    private int fishCaught = 0;

    // fish and their respective chance weights
    private Dictionary<string, int> fishies = new Dictionary<string, int>()
    {
        {"fish1", 60},  // 30% chance
        {"fish2", 50},  // 50% chance
        {"fish3", 30},  // 30% chance
        {"fish4", 15},  // 15% chance
        {"shark", 1},  // 1% chance
    };

    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < water.transform.position.y)
        {
            if (hasFish == false)
            {
                timeleft -= Time.deltaTime;
                if (timeleft < 0)
                {
                    SelectSwitch();
                    hapticInput.ActivateListener();
                    fishCaught++;
                }
            }
        }

        if (hasFish == true)
        {
            if (gameObject.transform.position.y > water.transform.position.y)
            {
                timeleft -= Time.deltaTime;
                if (timeleft < 0)
                {
                    AssignPoints();
                    hasFish = false;
                }
            }
        }
    }

    public void SelectSwitch() 
    {
        string selectedOption = SelectOption();

        switch (selectedOption)
        {
            case "fish1":
                fish = Instantiate(FishV1, gameObject.transform.position, gameObject.transform.rotation);
                checkPosition(FishV1);
                score += 10;
                scoreText.text = "SCORE: " + score;
                break;
            case "fish2":
                fish = Instantiate(FishV2, gameObject.transform.position, gameObject.transform.rotation);
                checkPosition(FishV2);
                score += 15;
                scoreText.text = "SCORE: " + score;
                break;
            case "fish3":
                fish = Instantiate(FishV3, gameObject.transform.position, gameObject.transform.rotation);
                checkPosition(FishV3);
                score += 25;
                scoreText.text = "SCORE: " + score;
                break;
            case "fish4":
                fish = Instantiate(FishV4, gameObject.transform.position, gameObject.transform.rotation);
                checkPosition(FishV4);
                score += 50;
                scoreText.text = "SCORE: " + score;
                break;
            case "shark":
                fish = Instantiate(Shark, gameObject.transform.position, gameObject.transform.rotation);
                checkPosition(Shark);
                score += 500;
                scoreText.text = "SCORE: " + score;
                break;

        }
        //GameObject FishL1 = Instantiate(FishV1, gameObject.transform.position, gameObject.transform.rotation);
        fish.transform.parent = gameObject.transform;
        hasFish = true;
        timeleft = 10;
    }

    public string SelectOption()
    {
        int totalWeight = 0;

        // Calculate the total weight
        foreach (var option in fishies)
        {
            totalWeight += option.Value;
        }

        // Generate a random number between 0 and the total weight
        int randomNumber = random.Next(0, totalWeight);

        // Iterate through the options and find the one that corresponds to the random number
        foreach (var option in fishies)
        {
            if (randomNumber < option.Value)
            {
                return option.Key;
            }

            randomNumber -= option.Value;
        }

        // This should never happen, but just in case
        Debug.LogError("Failed to select an option.");
        return null;
    }

    private void AssignPoints()
    {
        Destroy(fish);
        timeleft = 5;
    }

    private void checkPosition(GameObject thisFish)
    {
        if (trophy1.activeSelf == true)
        {
            GameObject fish1 = Instantiate(thisFish, trophy1.transform.position, trophy1.transform.rotation);
            trophy1.SetActive(false);
            return;
        }
        if (trophy2.activeSelf == true)
        {
            GameObject fish1 = Instantiate(thisFish, trophy2.transform.position, trophy2.transform.rotation);
            trophy2.SetActive(false);
            return;
        }
        if (trophy3.activeSelf)
        {
            GameObject fish1 = Instantiate(thisFish, trophy3.transform.position, trophy3.transform.rotation);
            trophy3.SetActive(false);
            return;
        }
        if (trophy4.activeSelf)
        {
            GameObject fish1 = Instantiate(thisFish, trophy4.transform.position, trophy4.transform.rotation);
            trophy4.SetActive(false);
            return;
        }
        if (trophy5.activeSelf)
        {
            GameObject fish1 = Instantiate(thisFish, trophy5.transform.position, trophy5.transform.rotation);
            trophy5.SetActive(false);
            return;
        }
        if (trophy6.activeSelf)
        {
            GameObject fish1 = Instantiate(thisFish, trophy6.transform.position, trophy6.transform.rotation);
            trophy6.SetActive(false);
            return;
        }
        if (trophy7.activeSelf)
        {
            GameObject fish1 = Instantiate(thisFish, trophy7.transform.position, trophy7.transform.rotation);
            trophy7.SetActive(false);
            return;
        }
        if (trophy8.activeSelf)
        {
            GameObject fish1 = Instantiate(thisFish, trophy8.transform.position, trophy8.transform.rotation);
            trophy8.SetActive(false);
            return;
        }
        if (trophy9.activeSelf)
        {
            GameObject fish1 = Instantiate(thisFish, trophy9.transform.position, trophy9.transform.rotation);
            trophy9.SetActive(false);
            return;
        }
        if (trophy10.activeSelf)
        {
            GameObject fish1 = Instantiate(thisFish, trophy9.transform.position, trophy9.transform.rotation);
            trophy10.SetActive(false);
            return;
        }
    }

}
