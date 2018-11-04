using System.Collections;
using UnityEngine;

public class Routiner : MonoBehaviour
{
    private static Routiner _instance;

    public static void Go(IEnumerator routine)
    {
        if (_instance == null)
        {
            var routiner = new GameObject("Routiner");
            DontDestroyOnLoad(routiner);
            _instance = routiner.AddComponent<Routiner>();
        }

        _instance.StartCoroutine(routine);
    }

    public static void StopAll()
    {
        _instance.StopAllCoroutines();
    }
}
