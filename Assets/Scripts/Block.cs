using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyBlockEffect;

    private MeshRenderer _meshRenderer;

    public event UnityAction<Block> BulletHit;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
    public void Break()
    {
        BulletHit?.Invoke(this);
        ParticleSystemRenderer renderer = Instantiate(_destroyBlockEffect, transform.position, _destroyBlockEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        renderer.material.color = _meshRenderer.material.color;

        Destroy(gameObject);
    }
}
