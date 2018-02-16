using System;

namespace FluentSwitch
{
    public static class FluentSwitchExtensions
    {   
        public static IFluentSwitchBuilder<TEnum, TOutput> Switch<TEnum, TOutput>(this TEnum value)
        {
            return new FluentSwitchBuilder<TEnum, TOutput>(value);
        }

        public static IFluentSwitchBuilder<TEnum, TOutput> When<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum, TOutput> builder, TEnum value, Func<TOutput> func)
        {
            if (!builder.IsComplete) builder.Run(value, func);
            
            return builder;
        }
        
        public static IFluentSwitchBuilder<TEnum, TOutput> Default<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum, TOutput> builder, TOutput defaultValue)
        {
            if (!builder.IsComplete) return new FluentSwitchBuilder<TEnum, TOutput>(builder.InputValue, defaultValue);
            
            return builder;
        }
        
        public static TOutput Value<TEnum, TOutput>(this IFluentSwitchBuilder<TEnum, TOutput> builder)
        {
            return builder.IsComplete ? builder.CurrentValue : builder.DefaultValue;
        }
    }
}