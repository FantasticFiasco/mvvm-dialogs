﻿#nullable disable
#if PRE_NET45
namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Allows you to obtain the line number in the source file at which the method is called.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    [__DynamicallyInvokable]
    public sealed class CallerLineNumberAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallerLineNumberAttribute"/> class.
        /// </summary>
        [__DynamicallyInvokable]
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public CallerLineNumberAttribute()
        {
        }
    }
}
#endif
