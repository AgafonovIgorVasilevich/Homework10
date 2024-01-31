using UnityEngine;

[RequireComponent (typeof(Collider))]

public class ProtectedArea : MonoBehaviour
{
    [SerializeField] private Alarmer _alarmer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>() != null)
            _alarmer.ChangeStatus(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Thief>() != null)
            _alarmer.ChangeStatus(false);
    }
}
