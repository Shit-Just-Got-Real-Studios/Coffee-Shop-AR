using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BillingScript : MonoBehaviour {
	private int index = 0;
	public int totalCost = 0;
	public GameObject receipt;

	public GameObject currentItem;
	public List<GameObject> boughtItems;
	public List<Text> itemInfo;
	public Text t1, t2, t3, rft;
	public Transform canvasTransform;
	public List<Text> textPrefabs;
	public void AddQuantity() {
		ItemScript item = currentItem.GetComponent<ItemScript> ();
		item.itemQuantity += 1;
		totalCost += item.itemCost;
	}

	public void DecreaseQuantity() {
		ItemScript item = currentItem.GetComponent<ItemScript> ();
		item.itemQuantity -= 1;
		totalCost -= item.itemCost;
	}
		
	public void showReceipt() {
		receipt.SetActive (true);
		int j = 0;
		int i = 0;
		while (i < boughtItems.Count * 3) {
			ItemScript tempitem = boughtItems[j].GetComponent<ItemScript> ();
			itemInfo [i].transform.position = new Vector3 (rft.transform.position.x - 50, rft.transform.position.y - (j) * 30, rft.transform.position.z);
			itemInfo [i].text = "" + tempitem.itemName;
			itemInfo [i + 1].transform.position = new Vector3 (rft.transform.position.x + 200, rft.transform.position.y - (j) * 30, rft.transform.position.z);
			itemInfo [i + 1].text = "" + tempitem.itemQuantity;
			itemInfo [i + 2].transform.position = new Vector3 (rft.transform.position.x + 400, rft.transform.position.y - (j) * 30 , rft.transform.position.z);
			itemInfo [i + 2].text = "" + tempitem.itemCost;
			j++;
			i += 3;
		}
	}

	void Update () {
		ItemScript item = currentItem.GetComponent<ItemScript> ();
		if (item.itemQuantity >= 1 && !boughtItems.Contains(currentItem)) {
			boughtItems.Add (currentItem);
			for (int i = 0; i < 18; i++) {
				itemInfo.Add (textPrefabs [i]);
			}
			index++;
		}

	}
}
