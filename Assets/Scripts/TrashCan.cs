using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(InsideTrash);
    }

    public void InsideTrash(GameObject trash)
    {
        trash.SetActive(false);
    }
}
