using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SummonMechanics : MonoBehaviour
{
    public Image SummonResult;
    public Button SummonButton;
    public TextMeshProUGUI Results;
    public GameObject Full;

    private float Value;
    public string[] ResultsDisplay;
    private string ResultsValue;
    private int ResultsIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        Results.text = "Results:" + "\n" + ResultsDisplay[0] + "\n" + ResultsDisplay[1] + "\n" + ResultsDisplay[02] + "\n" + ResultsDisplay[3] + "\n" + ResultsDisplay[4] + "\n" + ResultsDisplay[5];
    }

    // Update is called once per frame
    void Update()
    {
        Results.text = "Results:" + "\n" + ResultsDisplay[0] + "\n" + ResultsDisplay[1] + "\n" + ResultsDisplay[02] + "\n" + ResultsDisplay[3] + "\n" + ResultsDisplay[4] + "\n" + ResultsDisplay[5];
    }

    public void SummonSequence()
    {
        if (ResultsIndex < 5)
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
        } else
        {
            Full.SetActive(true);
        }       

    }
}
