using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buying : MonoBehaviour {
	
    public void purchase()
    {
        string currentPrice = GetComponentInChildren<GUIText>().text;
        print(currentPrice);
    }
}
