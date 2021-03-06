﻿using UnityEngine;
using System.Collections;

public class LurkInOutlawCampState : State<JesseOutlaw>
{
	private static readonly LurkInOutlawCampState instance = new LurkInOutlawCampState();
	private LurkInOutlawCampState() {
		// private constructor to prevent instantiation.
	}

	public static LurkInOutlawCampState Instance {
		get {
			return instance;
		}
	}
	public override void Enter (JesseOutlaw outlaw) {

		if (outlaw.GetLocation () != JesseOutlaw.Location.OutlawCamp) {
			Debug.Log ("Jesse: ohoh,Arrive sweet home"); 
			outlaw.ChangeLocation (JesseOutlaw.Location.OutlawCamp);
		} else {
			Debug.Log ("Jesse: ohoh, Sweet home"); 
		}
	}

	public override void Execute (JesseOutlaw outlaw) {

		 
			outlaw.RandomValue ();
			Debug.Log ("Jesse: Let's find a opportunity!");

			if (outlaw.EndLukIn ()) {
				outlaw.ChangeState (LurkInCemeteryState.Instance);
			    outlaw.InitialValue ();
		    } else if(outlaw.RobBank()){
			outlaw.ChangeState (RobBankState.Instance);
     		}else{
				outlaw.LukIn ();
			}

	}

	public override void Exit(JesseOutlaw outlaw) {

		Debug.Log ("Jess: Leaving in the camp");
	}

}

