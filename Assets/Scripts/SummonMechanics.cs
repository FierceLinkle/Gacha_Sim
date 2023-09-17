using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SummonMechanics : MonoBehaviour
{
    public Image SummonResult;
    public Button SummonButton;
    public TextMeshProUGUI Results;
    public TextMeshProUGUI SlotCount;
    public GameObject Full;
    public GameObject MaxExpands;

    private float Value;
    public string[] ResultsDisplay;
    private string ResultsValue;
    private int ResultsIndex = 0;

    public int InitialtotalSlots = 5;
    public int TotalSlots = 5;
    private int SummonNumber = 0;
    public int MaxTotalSlots = 12;

    public GameObject[] InventoryDisplay;


    // Start is called before the first frame update
    void Start()
    {
        Results.text = "Results:" + "\n";
        SlotCount.text = "Total Slots: " + TotalSlots.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space))){
            ResetGame();
        }

        SlotCount.text = "Total Slots: " + TotalSlots.ToString();
    }

    public void SummonSequence()
    {
        if (ResultsIndex < TotalSlots)
        {
            Value = Random.Range(0f, 1f);

            if (Value <= 0.2f)
            {
                SummonResult.color = Color.green;
                ResultsValue = "Green";
            }
            else if (Value > 0.2f && Value <= 0.4f)
            {
                SummonResult.color = Color.red;
                ResultsValue = "Red";
            }
            else if (Value > 0.4f && Value <= 0.6f)
            {
                SummonResult.color = Color.blue;
                ResultsValue = "Blue";
            }
            else if (Value > 0.6f && Value <= 0.8f)
            {
                SummonResult.color = Color.yellow;
                ResultsValue = "Yellow";
            }
            else
            {
                SummonResult.color = Color.cyan;
                ResultsValue = "Cyan";
            }

            ResultsDisplay[ResultsIndex] = ResultsValue;
            ResultsIndex++;

            DisplayResults(SummonNumber);
            SummonNumber++;

        } else
        {
            if(TotalSlots < MaxTotalSlots)
            {
                Full.SetActive(true);
            }
        }

    }

    private string DisplayResults(int DisplayOrder)
    {
        return Results.text += ResultsDisplay[DisplayOrder] + "\n";
    }

    public void ResetGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Results.text = "Results: " + "\n";
        SummonResult.color = Color.white;
        ResultsIndex = 0;
        SummonNumber = 0;
        Full.SetActive(false);
        MaxExpands.SetActive(false);

        //Make an option when reseting
        TotalSlots = InitialtotalSlots;
    }

    public void ExpandSlots()
    {
        if(TotalSlots >= MaxTotalSlots)
        {
            MaxExpands.SetActive(true);
        } else
        {
            TotalSlots++;
            Full.SetActive(false);
        }
    }
}
