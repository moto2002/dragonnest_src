using System;
using UnityEngine;

[ExecuteInEditMode]
public class ControlParticle : MonoBehaviour
{
	public int renderQueue = 3500;

	public bool runOnlyOnce;

	public bool autoFindWidget;

	public UIWidget widget;

	public int renderQueueOffset;

	[NonSerialized]
	private UIPanel panel;

	[NonSerialized]
	private Material matCache;

	[NonSerialized]
	private Renderer renderCache;

	private void Awake()
	{
		this.renderCache = base.renderer;
		if (Application.isPlaying && this.renderCache != null)
		{
			this.matCache = base.renderer.material;
			if (this.matCache != null)
			{
				this.matCache.renderQueue = 3500;
			}
		}
	}

	private void Start()
	{
		if (this.autoFindWidget)
		{
			this.widget = null;
		}
		if (this.autoFindWidget && this.widget == null)
		{
			Transform transform = base.transform;
			while (transform != null)
			{
				UIWidget component = transform.GetComponent<UIWidget>();
				if (component != null)
				{
					this.widget = component;
					break;
				}
				transform = transform.parent;
			}
		}
	}

	private void InnerUpdate(Material mat)
	{
		if (mat != null)
		{
			this.renderQueue = ((!(this.widget == null) && !(this.widget.drawCall == null)) ? this.widget.drawCall.renderQueue : this.renderQueue);
			if (mat.renderQueue != this.renderQueue)
			{
				mat.renderQueue = this.renderQueue + this.renderQueueOffset;
				this.renderQueue = mat.renderQueue;
			}
			UIPanel uIPanel = (!(this.widget != null)) ? null : this.widget.panel;
			if (uIPanel != null && this.panel != uIPanel)
			{
				this.panel = uIPanel;
				if (this.panel.root != null && this.panel.clipping != UIDrawCall.Clipping.None)
				{
					Vector4 finalClipRegion = this.panel.finalClipRegion;
					Vector3 vector = this.panel.root.transform.InverseTransformPoint(this.panel.transform.position);
					finalClipRegion.x += vector.x;
					finalClipRegion.y += vector.y;
					float x = (finalClipRegion.x - finalClipRegion.z * 0.5f) / 568f;
					float z = (finalClipRegion.x + finalClipRegion.z * 0.5f) / 568f;
					float w = (finalClipRegion.y + finalClipRegion.w * 0.5f) / 320f;
					float y = (finalClipRegion.y - finalClipRegion.w * 0.5f) / 320f;
					mat.SetVector("_ClipRange0", new Vector4(x, y, z, w));
				}
				else
				{
					mat.SetVector("_ClipRange0", new Vector4(-1f, -1f, 1f, 1f));
				}
			}
		}
	}

	private void Update()
	{
		if (this.renderCache != null)
		{
			if (Application.isPlaying)
			{
				this.InnerUpdate(this.matCache);
			}
			else
			{
				this.InnerUpdate(this.renderCache.sharedMaterial);
			}
		}
		if (this.runOnlyOnce && Application.isPlaying)
		{
			base.enabled = false;
		}
	}
}
