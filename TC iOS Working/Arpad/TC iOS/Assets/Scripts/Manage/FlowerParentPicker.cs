using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class FlowerParentPicker : MonoBehaviour {
	public GameObject PickerFlower;
	public GameObject ParentManager;
	private int FlowerPickerIndex;

	public void ChangeIndex(int indexChange)
	{	
		int flowersLen = Inventory.FlowerList.Count;
		//FlowerPickerIndex += indexChange;
		/*
		if (FlowerPickerIndex < 0) {
			if (flowersLen == 0) {
				FlowerPickerIndex = 0;
			} else {
				FlowerPickerIndex = flowersLen - 1;
			}
		} else if (FlowerPickerIndex > flowersLen - 1) {
			FlowerPickerIndex = 0;
		} */
		if (indexChange == -1) {
			bool done = false;
			while (!done) {
				if (FlowerPickerIndex == 0) {
					FlowerPickerIndex = LastFlower ();
				} else {
					FlowerPickerIndex -= 1;
				}
				if (Inventory.FlowerList [FlowerPickerIndex] != null) {
					done = true;
				}
			}
		} else if (indexChange == 1) {
			bool done = false;
			while (!done) {
				if (FlowerPickerIndex == flowersLen - 1) {
					FlowerPickerIndex = FirstFlower ();
				} else {
					FlowerPickerIndex += 1;
				}
				if (Inventory.FlowerList [FlowerPickerIndex] != null) {
					done = true;
				}
			}
		}

		if (!ParentManager.GetComponent<ParentManager> ().UpdateIndicesOfParentManager (FlowerPickerIndex)) {
			ChangeIndex (indexChange);
		} else {
			UpdateGameObjects ();
		}
	}

	int FirstFlower(){
		for (int i = 0; i < Inventory.FlowerList.Count; i++) {
			if (Inventory.FlowerList [i] != null) {
				print (String.Format ("Firstflower index {0}", i));
				return i;
			}
		}
		print ("Firstflower index by default 0");
		return 0;
	}

	int LastFlower(){
		int flowerLen = Inventory.FlowerList.Count ;
		for (int i = flowerLen - 1; i >= 0; i--) {
			if (Inventory.FlowerList [i] != null) {
				print (String.Format ("lastflower index {0}", i));
				return i;
			}
		}
		print ("lastflower index by default 0");
		return 0;
	}

	public void SetIndexToLinkedParentIndex(int index){
		FlowerPickerIndex = index;
		UpdateGameObjects ();
	}

	void UpdateGameObjects () {
		string[] newGenes = Inventory.GetFlower (FlowerPickerIndex).genes;
		Debug.Log (newGenes);
		UpdatePickerFlower (newGenes);
	}

	void UpdatePickerFlower(string[] newGenes)
	{
		PickerFlower.GetComponent<CreateFlower>().ChangeGenes(newGenes);
	}

	void Awake () {
		FlowerPickerIndex = 0;
	}

	void Start () {
		StartCoroutine(UpdateGameObjectsShortlyAfterStart ());
	}

	IEnumerator UpdateGameObjectsShortlyAfterStart () {
		yield return new WaitForSeconds (0.1F);
		UpdateGameObjects ();
		Debug.Log ("Just to be sure");
		StopCoroutine (UpdateGameObjectsShortlyAfterStart ());
	}
	
	// Update is called once per frame
	void Update () {
	}
}
