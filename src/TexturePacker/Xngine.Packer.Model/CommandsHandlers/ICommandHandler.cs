using System;
using System.Collections.Generic;
using System.Text;

namespace Xngine.Packer.Model.CommandsHandlers
{
    interface ICommand { }

    interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
