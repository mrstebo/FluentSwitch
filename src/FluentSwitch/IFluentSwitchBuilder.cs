using System;

namespace FluentSwitch
{   
    public interface IFluentSwitchBuilder<TEnum, TOutput>
    {
        TEnum InputValue { get; }
        TOutput DefaultValue { get; }
        TOutput CurrentValue { get; }
        bool IsComplete { get; }

        void Run(TEnum value, Func<TOutput> func);
    }
}