using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{

    [SerializeField] MeshFilter _meshFilter;
    [SerializeField] MeshCollider _meshCollider;

    [SerializeField] float _radius, _moveSpeed;
    [SerializeField] Transform _holeCenter;

    [SerializeField] Vector2 _moveLimits;

    Mesh _mesh;

    List<int> _holeVertices;

    List<Vector3> _offsets;

    int _holeVerticesCount;

    float _x, _y;

    Vector3 _touch, _targetPos;

    void Start()
    {

        Game.isMoving = false;
        Game.isGameOver = false;

        _holeVertices = new List<int>();
        _offsets = new List<Vector3>();

        _mesh = _meshFilter.mesh;

        FindHoleVertices();

    }

    void Update()
    {
        Game.isMoving = Input.GetMouseButton(0);

        if (!Game.isGameOver && Game.isMoving)
        {
            MoveHole();

            UpdateHoleVerticesPosition();
        }

    }

    void MoveHole()
    {
        _x = Input.GetAxis("Mouse X");
        _y = Input.GetAxis("Mouse Y");

        _touch = Vector3.Lerp(_holeCenter.position, _holeCenter.position + new Vector3(_x, 0f, _y), _moveSpeed * Time.deltaTime);

        _targetPos = new Vector3(
            Mathf.Clamp(_touch.x, -_moveLimits.x, _moveLimits.x),
            _touch.y,
            Mathf.Clamp(_touch.z, -_moveLimits.y, _moveLimits.y)
            );

        _holeCenter.position = _targetPos;
    }

    void UpdateHoleVerticesPosition()
    {
        Vector3[] vertices = _mesh.vertices;
        for (int i = 0; i < _holeVerticesCount; i++)
        {
            vertices[_holeVertices[i]] = _holeCenter.position + _offsets[i];
        }

        _mesh.vertices = vertices;
        _meshFilter.mesh = _mesh;
        _meshCollider.sharedMesh = _mesh;

    }

    void FindHoleVertices()
    {
        for (int i = 0; i < _mesh.vertices.Length; i++)
        {
            float distance = Vector3.Distance(_holeCenter.position, _mesh.vertices[i]);

            if (distance < _radius)
            {
                _holeVertices.Add(i);
                _offsets.Add(_mesh.vertices[i] - _holeCenter.position);
            }
        }

        _holeVerticesCount = _holeVertices.Count;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_holeCenter.position, _radius);
    }

}
