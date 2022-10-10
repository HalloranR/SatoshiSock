using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictimScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    bool hit = false;

    public AudioClip clip0;
    public AudioClip clip1;
    public AudioClip clip2;

    public GameController gameController;

    public TextMeshProUGUI canvas;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Stick")
        {
            if (!hit)
            {
                int randInt = Random.Range(0, 2);
                if (randInt == 0)
                {
                    audioSource.clip = clip0;
                    audioSource.Play();
                }
                else if (randInt == 1)
                {
                    audioSource.clip = clip2;
                    audioSource.Play();
                }
                else { Debug.Log("Not right random"); }

                Vector3 newRotation = new Vector3(0, 0, 90);
                transform.eulerAngles = newRotation;

                //this.GetComponent<Rigidbody>().freezeRotation.

                gameController.AddToHit(this.gameObject);

                hit = true;

                Destroy(canvas);

                Debug.Log("Hit");
            }
        }
    }
}
