using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{
    private static T _instance;
    public static T Instance => _instance;
    //private BasePanel() { }

    private void Awake()
    {
        _instance = this as T;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }
    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}
