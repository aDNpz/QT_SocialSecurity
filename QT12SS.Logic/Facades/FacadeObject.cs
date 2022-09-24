//@CodeCopy
//MdStart

using QT12SS.Logic.Controllers;

namespace QT12SS.Logic.Facades
{
    public abstract partial class FacadeObject
    {
        internal ControllerObject ControllerObject { get; private set; }

        protected FacadeObject(ControllerObject controllerObject)
        {
            ControllerObject = controllerObject;
        }
    }
}

//MdEnd
