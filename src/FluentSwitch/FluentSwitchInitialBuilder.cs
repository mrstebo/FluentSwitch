namespace FluentSwitch
{
    internal class FluentSwitchInitialBuilder<TEnum> : IFluentSwitchBuilder<TEnum>
    {
        public FluentSwitchInitialBuilder(TEnum inputValue)
        {
            InputValue = inputValue;
        }
        
        public TEnum InputValue { get; }
    }
}