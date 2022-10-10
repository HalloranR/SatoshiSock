using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int quota;

    public bool worldState = true;

    public Light worldLight;

    public List<GameObject> hitList;

    public int numLeft;

    public TextMeshProUGUI textBox;

    public Material blood;

    public GameObject barrier;

    private void Start()
    {
        numLeft = quota;

        textBox.text = "Quota: " + numLeft.ToString();
    }

    public void AddToHit(GameObject victim)
    {
        hitList.Add(victim);

        numLeft--;

        textBox.text = "Quota: " + numLeft.ToString();


        if(hitList.Count >= quota)
        {
            ChangeState();
        }
    }

    public void ChangeState()
    {
        worldLight.intensity = 0;

        foreach(GameObject victim in hitList)
        {
            victim.GetComponent<MeshRenderer>().material = blood;
        }

        Destroy(barrier);

        textBox.text = "Good Job, Return to Base";
    }
}
