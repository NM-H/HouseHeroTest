using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleSlot : MonoBehaviour, IDropHandler
{
    public string correctPieceName; 

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        if (dropped == null) return;

        PuzzleDrag puzzleDrag = dropped.GetComponent<PuzzleDrag>();

        if (puzzleDrag == null) return;

        puzzleDrag.parentAfterDrag = transform;
    }
}
