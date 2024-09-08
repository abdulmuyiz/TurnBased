using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //TODO: Add properties for grid sizes, hex size and hex prefab
    [field:SerializeField] public hexOrientation orientation {  get; private set; }
    [field:SerializeField] public int width {  get; private set; }
    [field:SerializeField] public int height { get; private set; }
    [field:SerializeField] public float hexSize { get; private set; }
    [field:SerializeField] public GameObject hexPrefab { get; private set; }
    //TODO: Create a grid of hexes
    //TODO: Store the individual tiles in an array
    //TODO: Methods to get a hex at a given position
    //TODO: Gizmo for draeing the grid in the editor

    private void OnDrawGizmos()
    {
        for (int z =0; z <height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 centerPosition = HexMetrix.Center(hexSize,x,z, orientation) + transform.position;
                for(int s = 0; s < HexMetrix.Corners(hexSize, orientation).Length; s++)
                {
                    Gizmos.DrawLine(
                        centerPosition + HexMetrix.Corners(hexSize, orientation)[s % 6],
                        centerPosition + HexMetrix.Corners(hexSize, orientation)[(s+1) % 6]
                        );
                }
            }
        }
    }

    public enum hexOrientation
    {
        flatTop,
        pointTop
    }
}
