using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleSlot : MonoBehaviour, IDropHandler
{
    public string correctPieceName;

    public void OnDrop(PointerEventData eventData)
    {
        PuzzleDrag drag = eventData.pointerDrag.GetComponent<PuzzleDrag>();
        if (drag != null)
        {
            drag.parentAfterDrag = transform;
        }
    }
}
