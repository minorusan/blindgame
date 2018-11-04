using Core;
using UnityEngine;

public class UpdateBehaviour : MonoBehaviour
{
    private UpdateController _updateController;

    void Start()
    {
        _updateController = ServiceProvider.GetService<UpdateController>();
        _updateController.AddUpdatable(ServiceProvider.GetService<CommandExecutor>());

        ServiceProvider.GetService<CommandExecutor>().EnqueueCommand(
            new LogCommand("UpdateBehaviour:: All core components initialized.", ELogType.Log));
    }

    void Update()
    {
        _updateController.Update();
    }
}