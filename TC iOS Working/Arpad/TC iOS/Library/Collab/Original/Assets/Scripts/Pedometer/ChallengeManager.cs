﻿// reducing updates code from https://answers.unity.com/questions/17131/execute-code-every-x-seconds-with-update.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChallengeManager : MonoBehaviour {
	public List<Text> Challenges;
	public static bool isWC1Completed;
	public static bool isWC2Completed;
	public static bool isWC3Completed;
	public Button ClaimReward1;
	public Button ClaimReward2;
	public Button ClaimReward3;
	public GameObject Panel1;
	public GameObject Panel2;
	public GameObject Panel3;

	private float nextActionTime = 0.0f;
	public float period = 0.1f;

	void Update() {
		if (Time.time > nextActionTime) {
			nextActionTime += period;
			Inventory.evaluateChallenges ();
			if (isWC1Completed == true) {
				Debug.Log ("Complete WC1");
				//Challenges [0].text += ": Done";
				Panel1.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("ChallengeSceneAssets/1x/challenge-scene-done-panel");
				ClaimReward1.interactable = true;
			}
			if (isWC2Completed == true) {
				//Challenges[1].text += ": Done";
				Panel2.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("ChallengeSceneAssets/1x/challenge-scene-done-panel");
				ClaimReward2.interactable = true;
				Debug.Log ("Complete WC2");
			}
			if (isWC3Completed == true) {
				//Challenges[1].text += ": Done";
				Panel3.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("ChallengeSceneAssets/1x/challenge-scene-done-panel");
				ClaimReward3.interactable = true;
				Debug.Log ("Complete WC3");
			}

			Text text = Panel3.GetComponent<Text> ();
			text.text = Inventory.Goal.GetGoalString ();
		}
	}

	public void addRewardToInventory(int rewardNumber) {
		//if 1 add knox teacup, if 2 add polka dot, if 3 add heart teacup
		//call this function from Claim button OnClick()
	}
}