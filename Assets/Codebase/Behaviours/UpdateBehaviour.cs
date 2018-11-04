using Core;
using UnityEngine;

public class UpdateBehaviour : MonoBehaviour
{
    private UpdateController _updateController;

    private void Start()
    {
        _updateController = ServiceProvider.GetService<UpdateController>();
        _updateController.AddUpdatable(ServiceProvider.GetService<CommandExecutor>());
        _updateController.AddUpdatable(ServiceProvider.GetService<PlayerMovement>());

        ServiceProvider.GetService<CommandExecutor>().EnqueueCommand(
            new LogCommand("UpdateBehaviour:: All core components initialized.", ELogType.Log));
    }

    private void Update()
    {
        _updateController.Update();
    }

    private void OnDisable()
    {
        _updateController.Dispose();
    }
}