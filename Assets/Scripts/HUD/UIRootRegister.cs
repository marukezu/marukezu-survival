using UnityEngine;

// Essa classe é responsável por "Apontar" O local padrão para instanciar Containers/Paineis,
// Toda Scene deve ter um script desse anexado ao canvas para que ele aponte onde é o "Canvas" padrão para instanciar novos paineis/containers.

public sealed class UIRootRegister : MonoBehaviour
{
    [SerializeField] private GameObject containersRoot; // arrasta UIRoot_Tooltips aqui

    private void OnEnable()
    {
        // registra o root dessa cena como destino padrão
        ContainerManager.Instance.SetDefaultRoot(containersRoot);
    }
}