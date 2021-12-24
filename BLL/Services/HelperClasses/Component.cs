namespace BLL.Services.HelperClasses
{
    public abstract class Component
    {
        public string Name { get; set; }

        protected Component()
        {
            Name = GetType().ToString();
        }

        public virtual void Add(Component component)
        {
        }

        public virtual void Remove(Component component)
        {
        }
    }
}