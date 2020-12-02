using System;
using System.Collections.Generic;
using UnityEngine;

public class Verbiage: MonoBehaviour
{
    [SerializeField]
    private int _state = 0;

    public int State
    {
        get { return _state; }
        set { _state = Mathf.Clamp(value, 0, collection.Length); }
    }

    [SerializeField]
    private PhraseCollection[] collection;


    [Serializable]
    public struct PhraseCollection
    {
        public bool random;
        public string[] Phrases;
    }
}
