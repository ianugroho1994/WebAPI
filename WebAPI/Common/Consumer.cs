using Common.Interfaces;
using JetBrains.Annotations;

namespace Common
{
    public class Consumer
    {
        private static Lazy<Consumer> _lazy = null!;
        private readonly ModuleRepository _moduleRepository;

        public Consumer(ModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;

            setInstance(() => this);
        }

        public static Consumer GetInstance() => _lazy.Value;

        [MustUseReturnValue("This method only fetch you only the command, you must invoke the command to have an actual effect")]
        public TModule Get<TModule>() where TModule : IModule => (TModule)_moduleRepository.Get<TModule>();

        [MustUseReturnValue("This method only fetch you only the command, you must invoke the command to have an actual effect")]
        public IEnumerable<TModule> Gets<TModule>() where TModule : IModule => _moduleRepository.Gets<TModule>();

        private static void setInstance(Func<Consumer> factory)
        {
            _lazy = new Lazy<Consumer>(factory);
        }
    }
}
