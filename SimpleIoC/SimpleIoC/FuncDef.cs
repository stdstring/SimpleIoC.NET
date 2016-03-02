namespace SimpleIoC
{
    public delegate T CreateFunc<out T>(IServiceContainer container) where T : class;
}
