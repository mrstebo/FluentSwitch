using System;

namespace FluentSwitch
{
    public static class FluentSwitchExtensions
    {
        public static IFluentSwitchBuilder<TEnum> Switch<TEnum>(this TEnum value)
        {
            return new FluentSwitchInitialBuilder<TEnum>(value);
        }
        
        public static IFluentSwitchBuilder<TEnum, TOutput> When<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum> builder, TEnum value, Func<TOutput> func)
        {
            var newBuilder = new FluentSwitchValueBuilder<TEnum, TOutput>(builder.InputValue);
            
            newBuilder.Run(value, func);
            
            return newBuilder;
        }

        public static IFluentSwitchBuilder<TEnum, TOutput> When<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum, TOutput> builder, TEnum value, Func<TOutput> func)
        {
            if (!builder.IsComplete) builder.Run(value, func);
            
            return builder;
        }
        
        public static IFluentSwitchBuilder<TEnum, TOutput> Default<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum> builder, TOutput defaultValue)
        {
            return new FluentSwitchValueBuilder<TEnum, TOutput>(builder.InputValue, defaultValue);
        }
        
        public static IFluentSwitchBuilder<TEnum, TOutput> Default<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum, TOutput> builder, TOutput defaultValue)
        {
            return !builder.IsComplete ? new FluentSwitchValueBuilder<TEnum, TOutput>(builder.InputValue, defaultValue) : builder;
        }
        
        public static TOutput Value<TEnum, TOutput>(this IFluentSwitchBuilder<TEnum, TOutput> builder)
        {
            return builder.IsComplete ? builder.CurrentValue : builder.DefaultValue;
        }
    }
}