namespace FluentSwitch
{
    public static class FluentSwitchValueExtensions
    {
        public static IFluentSwitchBuilder<TEnum> Switch<TEnum>(this TEnum value)
        {
            return new FluentSwitchInitialBuilder<TEnum>(value);
        }
        
        public static IFluentSwitchBuilder<TEnum, TOutput> When<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum> builder, TEnum value, TOutput outputValue)
        {
            return new FluentSwitchValueBuilder<TEnum, TOutput>(builder.InputValue).When(value, outputValue);
        }
        
        public static IFluentSwitchBuilder<TEnum, TOutput> When<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum, TOutput> builder, TEnum value, TOutput outputValue)
        {
            return builder.When(value, () => outputValue);
        }
        
        public static IFluentSwitchBuilder<TEnum, TOutput> Else<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum> builder, TOutput defaultValue)
        {
            return new FluentSwitchValueBuilder<TEnum, TOutput>(builder.InputValue).Else(defaultValue);
        }
        
        public static IFluentSwitchBuilder<TEnum, TOutput> Else<TEnum, TOutput>(
            this IFluentSwitchBuilder<TEnum, TOutput> builder, TOutput defaultValue)
        {
            return builder.Else(() => defaultValue);
        }
        
        public static TOutput Value<TEnum, TOutput>(this IFluentSwitchBuilder<TEnum, TOutput> builder)
        {
            return builder.IsComplete ? builder.CurrentValue : builder.DefaultValue;
        }
    }
}