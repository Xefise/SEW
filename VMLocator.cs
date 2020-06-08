using SEW.ViewModels;

namespace SEW
{
    public class VMLocator
    {
        public MainVM MainVM => Ioc.Resolve<MainVM>();
        public RememberVM RememberVM => Ioc.Resolve<RememberVM>();
        public CategoryVM CategoryVM => Ioc.Resolve<CategoryVM>();
        public WordVM WordVM => Ioc.Resolve<WordVM>();
        public ExampleVM ExampleVM => Ioc.Resolve<ExampleVM>();
        public WordSearchVM WordSearchVM => Ioc.Resolve<WordSearchVM>();
        public SettingsVM SettingsVM => Ioc.Resolve<SettingsVM>();
    }
}
