using System;

namespace FluentSwitch
{
    internal class FluentSwitchValueBuilder<TEnum, TOutput> : IFluentSwitchBuilder<TEnum, TOutput>
    {
        public FluentSwitchValueBuilder(TEnum inputValue, TOutput defaultValue = default(TOutput))
        {
            InputValue = inputValue;
            DefaultValue = defaultValue;
        }
        
        public TEnum InputValue { get; }

        public TOutput DefaultValue { get; }
        
        public TOutput CurrentValue { get; private set; }

        public bool IsComplete { get; private set; }
        
        public void Run(TEnum value, Func<TOutput> func)
        {
            if (value.Equals(InputValue))
            {
                CurrentValue = func.Invoke();
                IsComplete = true;
            }
        }
    }
}