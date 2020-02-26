using System;

namespace Modules.Level.Input
{
    public interface IChangeWeaponInput
    {
        event Action<int> OnChangeWeaponButtonClicked;
    }
}
