using Common.Interfaces;

namespace Common
{
    public class Producer
    {
        private readonly ModuleRepository _moduleRepository;

        public Producer(ModuleRepository repository)
        {
            _moduleRepository = repository;
        }

        public void RegisterModule<TModule>(TModule module) where TModule : IModule
        {
            _moduleRepository.Add(module);
        }
    }
}