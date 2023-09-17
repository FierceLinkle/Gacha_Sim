using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gachapon : MonoBehaviour
{
    public GameObject CapsuleToy;

    public GameObject[] capsuleArr;
    public Transform[] displayArr;
    int displayToggle;

    public Animator crankAnim;

    bool inUse = false;
    bool isEmpty = false;

    float delay = 3f;

    int index;

    public TextMeshProUGUI EmptyText;
    public TextMeshProUGUI CapsuleLeftText;
    private int CapsuleLeft;

    public Transform CameraShift;
    bool hasShifted = false;

    // Start is called before the first frame update
    void Start()
    {
        inUse = false;
        displayToggle = 0;
        CapsuleLeft = capsuleArr.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && inUse == false && isEmpty == false)
        {
            inUse = true;
            GameObject cloneC = (GameObject)Instantiate(CapsuleToy);
            //GameObject cloneT = (GameObject)Instantiate(capsuleArr[CapsuleSelect()]);
            //SpawnDisplay();
            StartCoroutine(Buffer());
            Destroy(cloneC, delay);
            //Destroy(cloneT, delay);
            //RemoveCapsuleFromPool();
            //EmptyMachineCheck();
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            CameraMove();
        }

        if(CapsuleLeft <= 0)
        {
            EmptyMachineCheck();
        }

        //EmptyMachineCheck();

        CapsuleLeftText.text = "Capsules Left: " + CapsuleLeft.ToString();
    }

    IEnumerator Buffer()
    {
        crankAnim.SetBool("IsActive", true);
        yield return new WaitForSeconds(0.1f);
        crankAnim.SetBool("IsActive", false);
        yield return new WaitForSeconds(delay - 0.4f);
        GameObject cloneT = (GameObject)Instantiate(capsuleArr[CapsuleSelect()]);
        Destroy(cloneT, delay);
        yield return new WaitForSeconds(delay);
        CapsuleLeft--;
        SpawnDisplay();
        yield return new WaitForSeconds(0.2f);
        inUse = false;
        RemoveCapsuleFromPool();
    }

    private int CapsuleSelect()
    {
        index = Random.Range(0, capsuleArr.Length);

        if (capsuleArr[index] == null)
        {
            CapsuleSelect();
        }

        return index;
    }

    private void RemoveCapsuleFromPool()
    {
        capsuleArr[index] = null;
    }

    private void EmptyMachineCheck()
    {
        isEmpty = true;

        for (int i = 0; i < capsuleArr.Length; i++)
        {
            if (capsuleArr[i] != null)
            {
                isEmpty = false;
            }
        }

        if (isEmpty == true)
        {
            StartCoroutine(EmptyBuffer());
        }
    }

    IEnumerator EmptyBuffer()
    {
        yield return new WaitForSeconds(delay + 0.2f);
        EmptyText.text = "Machine Empty!";
    }

    public void CameraMove()
    {
        if (hasShifted == false)
        {
            CameraShift.position += new Vector3(20, 3, 0);
            CameraShift.rotation = Quaternion.Euler(20, 180, 0);
            hasShifted = true;
        }
        else
        {
            CameraShift.position -= new Vector3(20, 3, 0);
            CameraShift.rotation = Quaternion.Euler(0, 180, 0);
            hasShifted = false;
        }
    }

    public void SpawnDisplay()
    {
        GameObject cloneD = (GameObject)Instantiate(capsuleArr[index], displayArr[displayToggle].position + new Vector3(0, 0.75f, 0), transform.rotation);
        cloneD.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        displayToggle++;
    }

}
