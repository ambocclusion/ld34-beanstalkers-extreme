﻿using UnityEngine;
using System.Collections;

public class MinigameBehavior : MainBehaviour {

	private MinigameManager _minigameManager;
	public GameObject[] NecessaryObjects;
	public GameObject NextGame;
	public GameObject Tutorial;
	protected bool _finishedTutorial = false;

	void Awake(){
		if(Tutorial != null)	Tutorial.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		if (NextGame == null) {
			Debug.Log("Warning: No next game set");
		}
	}


	public virtual void Disable() {
		// disable all the things!
		this.gameObject.SetActive(false);
		foreach (GameObject o in NecessaryObjects) {
			o.SetActive(false);
		}
	}

	public virtual void Enable() {
		// reenable all the things!
		this.gameObject.SetActive(true);
		foreach (GameObject o in NecessaryObjects) {
			o.SetActive(true);
		}

		if(Tutorial != null){
			Tutorial.SetActive(true);
			MinigameManager.Instance.TutorialShowing = true;
			StateManager.Instance.SetState(GameStates.PAUSED);
		}

	}

	public void EndTutorial(){
		if(Tutorial != null){
			Tutorial.SetActive(false);
			MinigameManager.Instance.TutorialShowing = false;
			StateManager.Instance.SetState(GameStates.RUNNING);
		}
	}

	public void ProceedNextGame() {
		if (NextGame == null) {
			Debug.Log("ProceedNextGame, but no next game set");
		} else {
			//_minigameManager.SetMinigame(NextGame);
			MinigameManager.Instance.SetMinigame(NextGame);
		}
	}
}
