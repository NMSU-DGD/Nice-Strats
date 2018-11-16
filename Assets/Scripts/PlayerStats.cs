using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Currency;
	public static int Energy;
	public int startingCurrency;
	public int startingEnergy;

	// Use this for initialization
	void Start () {
		Currency = startingCurrency;
		Energy = startingEnergy;
	}
	
}
