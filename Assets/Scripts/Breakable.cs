using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    public List<GameObject> brokenPieces;
    public float TimeToBreak = 2;
    private float timer = 0;
    public UnityEvent OnBreak;

    void Start()
    {
        foreach (GameObject piece in brokenPieces)
        {
            piece.SetActive(false);
        }
    }

    public void Break()
    {
        timer += Time.deltaTime;

        if(timer > TimeToBreak) {
            foreach (GameObject piece in brokenPieces) {
                piece.SetActive(true);
                piece.transform.parent = null;
            }
            OnBreak.Invoke();
            gameObject.SetActive(false);
        }
    }
}
