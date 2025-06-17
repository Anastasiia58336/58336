using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    public Text messageText;
    public float messageDuration = 2f;
    private Coroutine currentMessage;

    public void ShowMessage(string message, float duration = -1f)
    {
        if (currentMessage != null)
            StopCoroutine(currentMessage);

        float usedDuration = (duration > 0) ? duration : messageDuration;
        currentMessage = StartCoroutine(ShowMessageRoutine(message, usedDuration));
    }

    private IEnumerator ShowMessageRoutine(string message, float duration)
    {
        messageText.text = message;
        messageText.enabled = true;
        yield return new WaitForSeconds(duration);
        messageText.enabled = false;
    }
}