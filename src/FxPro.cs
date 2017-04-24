using FxProNS;
using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Image Effects/FxPro™"), ExecuteInEditMode, RequireComponent(typeof(Camera))]
public class FxPro : MonoBehaviour
{
	private const bool VisualizeLensCurvature = false;

	public EffectsQuality Quality = EffectsQuality.Normal;

	private static Material _mat;

	private static Material _tapMat;

	public bool BloomEnabled = true;

	public BloomHelperParams BloomParams = new BloomHelperParams();

	public bool VisualizeBloom;

	public Texture2D LensDirtTexture;

	[Range(0f, 2f)]
	public float LensDirtIntensity = 1f;

	public bool ChromaticAberration;

	public bool ChromaticAberrationPrecise;

	[Range(1f, 2.5f)]
	public float ChromaticAberrationOffset = 1f;

	[Range(0f, 1f)]
	public float SCurveIntensity = 0.5f;

	public bool LensCurvatureEnabled;

	[Range(1f, 2f)]
	public float LensCurvaturePower = 1.1f;

	public bool LensCurvaturePrecise;

	[Range(0f, 1f)]
	public float FilmGrainIntensity = 0.15f;

	[Range(1f, 10f)]
	public float FilmGrainTiling = 4f;

	[Range(0f, 1f)]
	public float VignettingIntensity = 0.5f;

	private List<Texture2D> _filmGrainTextures;

	public bool ColorEffectsEnabled = true;

	public Color CloseTint = new Color(1f, 0.5f, 0f, 1f);

	public Color FarTint = new Color(0f, 0f, 1f, 1f);

	[Range(0f, 1f)]
	public float CloseTintStrength;

	[Range(0f, 1f)]
	public float FarTintStrength;

	[Range(0f, 2f)]
	public float DesaturateDarksStrength;

	[Range(0f, 1f)]
	public float DesaturateFarObjsStrength = 0.5f;

	public Color FogTint = Color.white;

	[Range(0f, 1f)]
	public float FogStrength = 0.5f;

	public static Material Mat
	{
		get
		{
			if (null == FxPro._mat)
			{
				FxPro._mat = new Material(Shader.Find("Hidden/FxPro"))
				{
					hideFlags = HideFlags.HideAndDontSave
				};
			}
			return FxPro._mat;
		}
	}

	private static Material TapMat
	{
		get
		{
			if (null == FxPro._tapMat)
			{
				FxPro._tapMat = new Material(Shader.Find("Hidden/FxProTap"))
				{
					hideFlags = HideFlags.HideAndDontSave
				};
			}
			return FxPro._tapMat;
		}
	}
}
