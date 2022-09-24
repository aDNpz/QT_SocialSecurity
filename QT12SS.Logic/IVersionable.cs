//@CodeCopy
//MdStart

namespace QT12SS.Logic
{
    public partial interface IVersionable : IIdentifyable
    {
        byte[]? RowVersion { get; }
    }
}
//MdEnd
