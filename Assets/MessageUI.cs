using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class MessageUI : MonoBehaviour
{
    public Text messageText;
    public float messageDuration = 2f;
    private Coroutine currentMessage;
    public void ShowMessage(string message)
    {
        if (currentMessage != null)
            StopCoroutine(currentMessage);
        currentMessage = StartCoroutine(ShowMessageRoutine(message));
    }
    private IEnumerator ShowMessageRoutine(string message)
    {
        messageText.text = message;
        messageText.enabled = true;
        yield return new WaitForSeconds(messageDuration);
        messageText.enabled = false;
    }
}