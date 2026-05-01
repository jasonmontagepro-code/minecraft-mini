using UnityEngine;

public class EndPortal : MonoBehaviour
{
    [SerializeField] private int eyeCount = 12;
    private int eyesPlaced = 0;
    private bool portalActivated = false;

    public void PlaceEye()
    {
        if (eyesPlaced < eyeCount)
        {
            eyesPlaced++;
            
            if (eyesPlaced >= eyeCount)
            {
                ActivatePortal();
            }
        }
    }

    private void ActivatePortal()
    {
        if (!portalActivated)
        {
            portalActivated = true;
            Debug.Log("Le Portail de l'End est activé ! Vous pouvez entrer dans l'End.");
            // Ajouter des effets visuels ici
        }
    }

    public bool IsActive()
    {
        return portalActivated;
    }

    public int GetEyesPlaced()
    {
        return eyesPlaced;
    }
}
