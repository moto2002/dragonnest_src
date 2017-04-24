using System;
using UnityEngine;

public class TestLuaDelegate : MonoBehaviour
{
	public delegate void VoidDelegate(GameObject go);

	public TestLuaDelegate.VoidDelegate onClick;
}
