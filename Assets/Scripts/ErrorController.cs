using System.Collections;
using UnityEngine;

public class ErrorController : MonoBehaviour
{
    [SerializeField] private Canvas _errorCanvas;
    [SerializeField] private Transform _container;
    [SerializeField] private ErrorCard _card;
    private static Transform Container;
    private static ErrorCard Card;
    private static Canvas ErrorCanvas;

    private void Start()
    {
        Container = _container;
        Card = _card;
        ErrorCanvas = _errorCanvas;
    }

    public static void ShowError(string message)
    {
        PlayerCamera.Singleton.StopCoroutine(nameof(Cshow));
        PlayerCamera.Singleton.StartCoroutine(Cshow(message));
    }
       
    private static IEnumerator Cshow(string message)
    {
        ErrorCanvas.enabled = true; 
        var card = Instantiate(Card, Container);
        if (Container.childCount > 3) Container.transform.position += new Vector3(0, 2);
        card.Render("Системное сообщение : " + message);
        yield return new WaitForSeconds(5);
        ErrorCanvas.enabled = false;
    }
}
