using System.Collections;
using Common.Interfaces;

namespace Common
{
    public class ModuleRepository : IEnumerable
    {
        private readonly IDictionary<Type, IModule> _modules;
        public ModuleRepository()
        {
            _modules = new Dictionary<Type, IModule>();
        }

        public void Add<TModule>(TModule instance) where TModule : IModule
        {
            _modules[typeof(TModule)] = instance;
        }

        public object Get<TModule>() where TModule : IModule
        {
            foreach (IModule moduleObj in _modules.Values)
            {
                if (moduleObj is TModule module)
                {
                    return module;
                }
            }

            return null!;
        }

        public IEnumerable<TModule> Gets<TModule>() where TModule : IModule
        {
            foreach (IModule moduleObj in _modules.Values)
            {
                if (moduleObj is TModule module)
                {
                    yield return module;
                }
            }
        }

        public IEnumerable<IModule> GetAllNodules()
        {
            foreach (IModule moduleObj in _modules.Values)
            {
                yield return moduleObj;
            }
        }

        public IEnumerator<IModule> GetEnumerator() => _modules.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
