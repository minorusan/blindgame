using System.Collections;
using Core;
using UnityEngine.EventSystems;
using UnityEngine;

public enum EMoveDirection
{
    Up, Down, Left, Right
}

public class UIInputBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public EMoveDirection direction;
    public KeyCode key;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            StartCoroutine(WalkRoutine());
        }

        if (Input.GetKeyUp(key))
        {
            StopAllCoroutines();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(WalkRoutine());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
    }

    private IEnumerator WalkRoutine()
    {
        var waitHandle = new WaitForSeconds(0.5f);
        while (true)
        {
            ServiceProvider.GetService<CommandExecutor>().EnqueueCommand(new MoveCommand(direction));
            yield return waitHandle;
        }
    }
}
