using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackARImages : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;
    public GameObject thingToInstantiate;
    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            GameObject g = Instantiate(thingToInstantiate, newImage.transform);
            Debug.Log("name of item " + newImage.referenceImage.name);
            // Handle added event
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            GameObject g = updatedImage.transform.GetChild(0).gameObject;
            g.transform.SetParent(updatedImage.transform, false);
            g.transform.localPosition = updatedImage.transform.localPosition;
            g.transform.localRotation = updatedImage.transform.localRotation;
        }

        foreach (var removedImage in eventArgs.removed)
        {
            GameObject g = removedImage.transform.GetChild(0).gameObject;
            Destroy(g);
            // Handle removed event
        }
    }
}
