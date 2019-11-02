using UnityEngine;
using UnityEditor;

public class ActionNames
{
    private ActionNames(string value) { Value = value; }

    public string Value { get; set; }

    public static ActionNames JumpPressAction { get { return new ActionNames("jumpPressAction"); } }
    public static ActionNames JumpReleaseAction { get { return new ActionNames("jumpReleaseAction"); } }
    public static ActionNames ShootPressAction { get { return new ActionNames("shootPressAction"); } }
    public static ActionNames ShootReleaseAction { get { return new ActionNames("shootReleaseAction"); } }
    public static ActionNames MoveInputAxisAction { get { return new ActionNames("moveInputAxisAction"); } }
    public static ActionNames PlayerHitstunEnterAction { get { return new ActionNames("playerHitstunEnterAction"); } }
}