namespace EE.Core {
    public interface IHasComponents {
        T GetComponent<T>();
        T[] GetComponents<T>();
        
        bool TryGetComponent<T>(out T component);

        T GetComponentInChildren<T>();

    }
}
