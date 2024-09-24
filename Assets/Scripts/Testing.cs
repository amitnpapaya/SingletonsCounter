using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Testing
{
    private readonly List<string> _stringsList = new List<string>();
    
    public void Test()
    {
        foreach (var stringMember in _stringsList.ToList())
        {
            Debug.Log(stringMember);
        }
    }      
}