using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaColliderBake: MonoBehaviour
{
	private SkinnedMeshRenderer _meshRenderer;
	private MeshCollider _collider;

	private void Start()
	{
		_meshRenderer = GetComponent<SkinnedMeshRenderer>();
		_collider = GetComponent<MeshCollider>();

		
		AtualizarCollider();
	}

	public void AtualizarCollider()
	{
		Vector3 newPos = transform.position;
		newPos.y += 0.1f;
		transform.position = newPos;

		Mesh colliderMesh = new Mesh();
		_meshRenderer.BakeMesh(colliderMesh);
		_collider.sharedMesh = null;
		_collider.sharedMesh = colliderMesh;
	}
}
