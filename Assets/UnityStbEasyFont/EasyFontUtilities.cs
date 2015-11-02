// port of stb_easy_font.h into Unity/C# - public domain
// Aras Pranckevicius, 2015 November

using UnityEngine;
using System.Collections.Generic;

public class EasyFontUtilities
{
	public const float kScaleFactor = 0.12f;

	public static void UpdateMesh(ref Mesh mesh, string text, Color32 color)
	{
		if (mesh != null)
			mesh.Clear();
		if (mesh == null)
		{
			mesh = new Mesh();
			mesh.hideFlags = HideFlags.HideAndDontSave;
		}
		List<Vector3> vertices = new List<Vector3>();
		List<Color32> colors = new List<Color32>();
		StbEasyFont.GenerateMesh(0, 0, text, color, vertices, colors);
		mesh.vertices = vertices.ToArray();
		mesh.colors32 = colors.ToArray();
		mesh.subMeshCount = 1;
		var indices = new int[vertices.Count];
		for (var i = 0; i < indices.Length; ++i)
			indices[i] = i;
		mesh.SetIndices(indices, MeshTopology.Quads, 0);
	}

	public static Material CreateFontMaterial()
	{
		var shader = Shader.Find ("Hidden/Internal-Colored");
		var mat = new Material (shader);
		mat.hideFlags = HideFlags.HideAndDontSave;
		// Turn on alpha blending
		mat.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
		mat.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
		// Turn backface culling off
		mat.SetInt ("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
		// Turn off depth writes and depth testing
		mat.SetInt ("_ZWrite", 0);
		mat.SetInt ("_ZTest", (int)UnityEngine.Rendering.CompareFunction.Always);
		return mat;
	}

	public static Vector3 CalcAnchorOffset(Mesh mesh, TextAnchor anchor)
	{
		var bounds = mesh.bounds;
		var dx = bounds.extents.x;
		var dy = bounds.extents.y + 1;
		var offset = Vector3.zero;
		// horizontal
		switch (anchor)
		{
		case TextAnchor.LowerCenter:
		case TextAnchor.MiddleCenter:
		case TextAnchor.UpperCenter:
			offset.x -= dx;
			break;		
		case TextAnchor.LowerRight:
		case TextAnchor.MiddleRight:
		case TextAnchor.UpperRight:
			offset.x -= dx * 2f;
			break;
		default:
			break;
		}

		// vertical
		switch (anchor)
		{
		case TextAnchor.MiddleLeft:
		case TextAnchor.MiddleRight:
		case TextAnchor.MiddleCenter:
			offset.y += dy;
			break;
		case TextAnchor.LowerLeft:
		case TextAnchor.LowerRight:
		case TextAnchor.LowerCenter:
			offset.y += dy * 2f;
			break;		
		default:
			break;
		}
		return offset;
	}

	#if UNITY_EDITOR
	public static void SelectAndMoveToView(GameObject go)
	{
		var view = UnityEditor.SceneView.lastActiveSceneView;
		if (view != null)
			view.MoveToView(go.transform);
		UnityEditor.Selection.activeGameObject = go;
	}
	#endif
}
