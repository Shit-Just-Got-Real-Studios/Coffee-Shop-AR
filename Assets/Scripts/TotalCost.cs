using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class TotalCost : MonoBehaviour {

	private Text text;
	public GameObject billingObject;

	void Awake() {
		text = GetComponent<Text>();
	}

	void Update() {
		BillingScript bs = billingObject.GetComponent<BillingScript> ();
		text.text = "Total Cost: Rs. " + bs.totalCost;
	}
}
