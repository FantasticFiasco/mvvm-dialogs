#if PRE_NET45
using System;
using System.Runtime;

internal sealed class __DynamicallyInvokableAttribute : Attribute
{
    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public __DynamicallyInvokableAttribute()
    {
    }
}
#endif