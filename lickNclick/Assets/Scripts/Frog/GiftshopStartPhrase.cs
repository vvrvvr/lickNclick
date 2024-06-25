using UnityEngine;

public class GiftshopStartPhrase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (false)
            {
                DialogueManager.instance.FrogSay("start");
            }
            else
            {
                DialogueManager.instance.FrogSay("startAgain");
            }
            Destroy(gameObject);
        }
    }
}
