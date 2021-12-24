using System.Collections.Generic;

namespace BLL.Services.HelperClasses
{
    public class Composite : Component
    {
        private List<Component> components = new List<Component>();

        public IReadOnlyCollection<Component> Components => components;

        public override void Add(Component component)
        {
            components.Add(component);
        }
 
        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public Component GetComponentByName(string name)
        {
            foreach (var component in components)
            {
                if (component.Name.Equals(name))
                {
                    return component;
                }
            }

            return null;
        }
    }
}