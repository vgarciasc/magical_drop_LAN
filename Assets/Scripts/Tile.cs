﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine;

public enum BallColor {
	GRAY,
	GREEN,
	NONE
}

public class Tile : NetworkBehaviour {
	public int tile_ID = -1;
	public Grid grid;

	[Header("Ball")]
	[SerializeField]
	Image ballSprite;

	[SyncVar]
	public BallColor ballColor;
	[SyncVar]
	public bool hasBall = false;

	void Start() {
		Deactivate_Ball();
	}

	void Update() {
		Color aux = Color.white;
		switch (ballColor) {

			case BallColor.GRAY:
				aux = Color.gray;
				break;	

			case BallColor.GREEN:
				aux = Color.green;
				break;	
		}

		ballSprite.enabled = hasBall;
		ballSprite.color = aux;
	}

	public void Activate_Ball(BallColor color) {
		ballColor = color;
		hasBall = true;

		Color aux = Color.white;
		switch (color) {
			case BallColor.GRAY:
				aux = Color.gray;
				break;	
			case BallColor.GREEN:
				aux = Color.green;
				break;	
		}

		ballSprite.enabled = true;
		ballSprite.color = aux;
	}

	public void Deactivate_Ball() {
		hasBall = false;
		ballSprite.color = Color.white;
		ballSprite.enabled = false;
	}

	public void Move_Down() {
		if (hasBall) {
			Deactivate_Ball();
			Tile down = grid.Get_Tile_Down(this);

			if (down != null) {
				down.Activate_Ball(ballColor);
			}
		}
	}
}