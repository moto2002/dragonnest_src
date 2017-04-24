using System;

public enum XQTEState
{
	None,
	HitBackPresent,
	HitBackStraight,
	HitBackGetup,
	HitFlyPresent,
	HitFlyLand,
	HitFlyStraight,
	HitFlyGetup,
	HitRollPresent,
	HitRollStraight,
	HitRollGetup,
	CanDash = 20,
	DashState,
	ChargeState,
	DashAttackState,
	StayInAir,
	firedash,
	onelight,
	Any = 1000
}
