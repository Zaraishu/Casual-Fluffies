using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{
    public List<Output> Inputs;
    public bool SingleInput;
    public bool HasInput;
    public bool Signal;

    private void Start()
    {
        Inputs = new List<Output>();
    }

    private void Update()
    {
        Inputs.RemoveAll(item => item == null);
    }
}