using System;

namespace FluentSwitch
{
    public static class FluentSwitchFactoryExtensions
    {
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
        
        public static IFluentSwitchBuilder<TEnum, TOutput> Else<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum> builder, Func<TOutput> defaultValueFunc)
        {
            return new FluentSwitchValueBuilder<TEnum, TOutput>(builder.InputValue, defaultValueFunc());
        }
        
        public static IFluentSwitchBuilder<TEnum, TOutput> Else<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum, TOutput> builder, Func<TOutput> defaultValueFunc)
        {
            return !builder.IsComplete ? new FluentSwitchValueBuilder<TEnum, TOutput>(builder.InputValue, defaultValueFunc()) : builder;
        }
    }
}